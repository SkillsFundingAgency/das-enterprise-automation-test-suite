using Mailosaur;
using Mailosaur.Models;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailosaurAPI.Service.Project.Helpers;

public class MailosaurApiHelper(ScenarioContext context)
{
    private readonly FrameworkList<MailosaurApiConfig> mailosaurApiUsers = context.Get<FrameworkList<MailosaurApiConfig>>();

    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    private readonly DateTime dateTime = DateTime.Now;

    public string GetLinkBySubject(string email, string subject, string linkText)
    {
        _objectContext.SetDebugInformation($"Check email received to '{email}' using subject '{subject}' and link text '{linkText}' after {dateTime:HH:mm:ss}");

        var mailosaurAPIUser = GetMailosaurAPIUser(email);

        var mailosaur = new MailosaurClient(mailosaurAPIUser.ApiToken);

        var criteria = new SearchCriteria()
        {
            SentTo = email,
            Subject = subject
        };

        var message = mailosaur.Messages.GetAsync(mailosaurAPIUser.ServerId, criteria, timeout: 20000, receivedAfter: dateTime).Result;

        _objectContext.SetDebugInformation($"Message found with ID '{message?.Id}' at {message?.Received:HH:mm:ss}");

        foreach (var linkFound in message.Html.Links)
        {
            _objectContext.SetDebugInformation($"Message links found with text '{linkFound.Text}', href {linkFound.Href}");
        }

        var link = message.Html.Links.FirstOrDefault(x => x.Href.ContainsCompareCaseInsensitive("https://") && (linkText == string.Empty || x.Text.ContainsCompareCaseInsensitive(linkText)));

        return link.Href;
    }

    public bool ValidateEmailBodyContainsText(string email, string subject, string emailText)
    {
        _objectContext.SetDebugInformation($"Check email received to '{email}' using subject '{subject}' and contains text '{emailText}' after {dateTime:HH:mm:ss}");

        var mailosaurAPIUser = GetMailosaurAPIUser(email);

        var mailosaur = new MailosaurClient(mailosaurAPIUser.ApiToken);

        _objectContext.SetDebugInformation($"Mailosaur details used are, Token: {mailosaurAPIUser.ApiToken}, serverName: {mailosaurAPIUser.ServerName}, serverId: {mailosaurAPIUser.ServerId}");

        var criteria = new SearchCriteria()
        {
            SentTo = email,
            Subject = subject
        };

        try
        {
            var message = mailosaur.Messages.GetAsync(mailosaurAPIUser.ServerId, criteria, timeout: 20000, receivedAfter: dateTime).Result;
            if (message.Text.Body.Contains(emailText))
            {
                _objectContext.SetDebugInformation($"Text found in the email body");
                return true;
            }
            else
            {
                _objectContext.SetDebugInformation($"Text not found in the email body");
                return false;
            }
        }
        catch (Exception ex)
        {
            _objectContext.SetDebugInformation($"Error retrieving email: {ex.Message}");
            return false;
        }
    }

    internal async Task DeleteInbox()
    {
        var inboxToDelete = context.Get<MailosaurUser>().GetEmailList();

        foreach (var (Email, ReceviedAfter) in inboxToDelete)
        {
            _objectContext.SetDebugInformation($"Deleting emails received to {Email} after {ReceviedAfter:HH:mm:ss}");

            var mailosaurAPIUser = GetMailosaurAPIUser(Email);

            var mailosaur = new MailosaurClient(mailosaurAPIUser.ApiToken);

            var criteria = new SearchCriteria()
            {
                SentTo = Email,
            };

            var messageresult = await mailosaur.Messages.SearchAsync(mailosaurAPIUser.ServerId, criteria, timeout: 10000, receivedAfter: ReceviedAfter, errorOnTimeout: false);

            foreach (var message in messageresult.Items)
            {
                _objectContext.SetDebugInformation($"Deleting emails received to {Email} at {message.Received:HH:mm:ss} with subject {message.Subject}");

                await mailosaur.Messages.DeleteAsync(message.Id);
            }
        }
    }

    private MailosaurApiConfig GetMailosaurAPIUser(string email)
    {
        var serveId = email.Split('@')[1].Split(".")[0];

        _objectContext.SetDebugInformation($" Pipeline ServerId: ${mailosaurApiUsers.First().ServerId} ");

        return mailosaurApiUsers.Single(x => x.ServerId == serveId);
    }
}