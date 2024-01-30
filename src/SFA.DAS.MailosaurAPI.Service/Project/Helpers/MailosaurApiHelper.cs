using Mailosaur;
using Mailosaur.Models;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailosaurAPI.Service.Project.Helpers;

public class MailosaurApiHelper
{
    private readonly FrameworkList<MailosaurApiUser> mailosaurAPIUsers;

    private readonly ObjectContext _objectContext;

    private readonly string domainName;

    private readonly HashSet<string> inboxToDelete = [];

    private readonly DateTime dateTime;

    public MailosaurApiHelper(ScenarioContext context)
    {
        mailosaurAPIUsers = context.Get<FrameworkList<MailosaurApiUser>>();

        _objectContext = context.Get<ObjectContext>();

        var mailosaurAPIUser = Configurator.IsAzureExecution ? mailosaurAPIUsers.Single(x => x.ServerName == "azure") : mailosaurAPIUsers.Single(x => x.ServerName == "local");

        domainName = $"{mailosaurAPIUser.ServerId}.mailosaur.net";

        dateTime = DateTime.Now;
    }

    public string GetDomainName() => domainName;

    public void UpdateInboxToDelete(string email) => inboxToDelete.Add(email);

    public string GetLinkBySubject(string email, string subject)
    {
        _objectContext.SetDebugInformation($"Check email received to '{email}' using subject '{subject}'");

        var mailosaurAPIUser = GetMailosaurAPIUser(email);

        var mailosaur = new MailosaurClient(mailosaurAPIUser.ApiToken);

        var criteria = new SearchCriteria()
        {
            SentTo = email,
            Subject = subject
        };

        var message = mailosaur.Messages.GetAsync(mailosaurAPIUser.ServerId, criteria, receivedAfter: dateTime).Result;

        var link = message.Text.Links.FirstOrDefault(x => x.Href.ContainsCompareCaseInsensitive("https://"));

        return link.Href;
    }

    internal void DeleteInbox()
    {
        foreach (var inbox in inboxToDelete)
        {
            _objectContext.SetDebugInformation($"Deleting emails received to {inbox}");

            var mailosaurAPIUser = GetMailosaurAPIUser(inbox);

            var mailosaur = new MailosaurClient(mailosaurAPIUser.ApiToken);

            var criteria = new SearchCriteria()
            {
                SentTo = inbox,
            };

            var messageList = mailosaur.Messages.ListAsync(mailosaurAPIUser.ServerId).Result.Items.Where(x => x.Received >= dateTime && x.To.Any(i => i.Email == inbox)).ToList();

            foreach (var message in messageList)
            {
                _objectContext.SetDebugInformation($"Deleting emails received to {inbox} using messege id {message.Id}");

                mailosaur.Messages.DeleteAsync(message.Id).Wait();
            }
        }
    }

    private MailosaurApiUser GetMailosaurAPIUser(string email)
    {
        var serveId = email.Split('@')[1].Split(".")[0];

        return mailosaurAPIUsers.Single(x => x.ServerId == serveId);
    }
}