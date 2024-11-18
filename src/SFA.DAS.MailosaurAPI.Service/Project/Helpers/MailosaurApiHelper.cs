using Mailosaur;
using Mailosaur.Models;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailosaurAPI.Service.Project.Helpers;

public class MailosaurApiHelper(ScenarioContext context)
{
    private readonly DateTime dateTime = DateTime.Now;

    public string GetLinkFromMessage(Message message, string linkText)
    {
        foreach (var linkFound in message.Html.Links)
        {
            SetDebugInformation($"Message links found with text '{linkFound.Text}', href {linkFound.Href}");
        }

        var link = message.Html.Links.FirstOrDefault(x => x.Href.ContainsCompareCaseInsensitive("https://") && (linkText == string.Empty || x.Text.ContainsCompareCaseInsensitive(linkText)));

        return link.Href;
    }

    public Message GetEmailBody(string email, string subject, string emailText)
    {
        SetDebugInformation($"Check email received to '{email}' using subject '{subject}' and contains text '{emailText}' after {dateTime:HH:mm:ss}");

        var mailosaurAPIUser = GetMailosaurAPIUser(email);

        var mailosaur = new MailosaurClient(mailosaurAPIUser.ApiToken);

        var criteria = new SearchCriteria()
        {
            SentTo = email,
            Subject = subject
        };

        var message = mailosaur.Messages.GetAsync(mailosaurAPIUser.ServerId, criteria, timeout: 20000, receivedAfter: dateTime).Result;

        SetDebugInformation($"Message found with ID '{message?.Id}' at {message?.Received:HH:mm:ss} with body {Environment.NewLine}{message.Text.Body}");

        return message;
    }

    internal async Task DeleteInbox()
    {
        var inboxToDelete = context.Get<MailosaurUser>().GetEmailList();

        foreach (var (Email, ReceviedAfter) in inboxToDelete)
        {
            SetDebugInformation($"Deleting emails received to {Email} after {ReceviedAfter:HH:mm:ss}");

            var mailosaurAPIUser = GetMailosaurAPIUser(Email);

            var mailosaur = new MailosaurClient(mailosaurAPIUser.ApiToken);

            var criteria = new SearchCriteria()
            {
                SentTo = Email,
            };

            var messageresult = await mailosaur.Messages.SearchAsync(mailosaurAPIUser.ServerId, criteria, timeout: 10000, receivedAfter: ReceviedAfter, errorOnTimeout: false);

            foreach (var message in messageresult.Items)
            {
                SetDebugInformation($"Deleting emails received to {Email} at {message.Received:HH:mm:ss} with subject {message.Subject}");

                await mailosaur.Messages.DeleteAsync(message.Id);
            }
        }
    }

    private MailosaurApiConfig GetMailosaurAPIUser(string email)
    {
        var serveId = email.Split('@')[1].Split(".")[0];

        return context.Get<FrameworkList<MailosaurApiConfig>>().Single(x => x.ServerId == serveId);
    }

    private void SetDebugInformation(string message) => context.Get<ObjectContext>().SetDebugInformation(message);
}