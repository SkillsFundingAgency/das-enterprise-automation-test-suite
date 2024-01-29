using Mailosaur;
using Mailosaur.Models;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailosaurAPI.Service;

public class MailosaurApiHelper
{
    private readonly FrameworkList<MailosaurApiUser> mailosaurAPIUsers;

    private readonly string domainName;

    public MailosaurApiHelper(ScenarioContext context)
    {
        mailosaurAPIUsers = context.Get<FrameworkList<MailosaurApiUser>>();

        var mailosaurAPIUser = Configurator.IsAzureExecution ? mailosaurAPIUsers.Single(x => x.ServerName == "azure") : mailosaurAPIUsers.Single(x => x.ServerName == "local");

        domainName = $"{mailosaurAPIUser.ServerId}.mailosaur.net";
    }

    public string GetDomainName() => domainName;

    public string GetLinkBySubject(string email, string subject)
    {
        var mailosaurAPIUser = GetMailosaurAPIUser(email);

        var mailosaur = new MailosaurClient(mailosaurAPIUser.ApiToken);

        var criteria = new SearchCriteria()
        {
            SentTo = email,
            Subject = subject
        };

        var message = mailosaur.Messages.Get(mailosaurAPIUser.ServerId, criteria);

        var link = message.Text.Links.FirstOrDefault(x => x.Href.ContainsCompareCaseInsensitive("https://"));

        return link.Href;
    }

    private MailosaurApiUser GetMailosaurAPIUser(string email)
    {
        var serveId = email.Split('@')[1].Split(".")[0];

        return mailosaurAPIUsers.Single(x => x.ServerId == serveId);
    }
}