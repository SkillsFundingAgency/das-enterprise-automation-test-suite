using mailinator_csharp_client;
using mailinator_csharp_client.Models.Domains.Responses;
using mailinator_csharp_client.Models.Messages.Entities;
using mailinator_csharp_client.Models.Messages.Requests;
using mailinator_csharp_client.Models.Responses;
using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailinatorAPI.Service.Project.Helpers;

public class MailinatorApiHelper
{
    private readonly MailinatorClient mailinatorClient;
    private readonly RetryAssertHelper _assertHelper;
    private readonly ObjectContext _objectContext;

    public MailinatorApiHelper(ScenarioContext context)
    {
        mailinatorClient = new(context.Get<MailinatorConfig>().ApiToken);
        _assertHelper = context.Get<RetryAssertHelper>();
        _objectContext = context.Get<ObjectContext>();
    }

    internal void DeleteMessages()
    {
        var messages = _objectContext.GetMessageList();

        foreach (var (domain, inbox, id) in messages)
        {
            //Delete Message
            DeleteMessageRequest deleteMessageRequest = new() { Domain = domain, Inbox = inbox, MessageId = id};

            _ = mailinatorClient.MessagesClient.DeleteMessageAsync(deleteMessageRequest).Result;
        }
    }

    public string GetDomain()
    {
        //Get All Domains
        GetAllDomainsResponse getAllDomainsResponse = mailinatorClient.DomainsClient.GetAllDomainsAsync().Result;

        _objectContext.SetMessageList();

        return getAllDomainsResponse.Domains.FirstOrDefault().Name;
    }

    public void VerifyEmail(string email, string expected)
    {
        var emailSplit = email.Split('@');

        string inbox = emailSplit[0];

        string domain = emailSplit[1];

        _assertHelper.RetryOnNUnitException(() =>
        {
            _objectContext.SetDebugInformation($"FetchInboxRequest using domain - {domain}, Inbox - {inbox}");

            //Fetch Inbox
            FetchInboxRequest fetchInboxRequest = new() { Domain = domain, Inbox = inbox, Skip = 0, Limit = 20, Sort = Sort.asc };

            FetchInboxResponse fetchInboxResponse = mailinatorClient.MessagesClient.FetchInboxAsync(fetchInboxRequest).Result;

            var messageId = fetchInboxResponse.Messages.FirstOrDefault()?.Id;

            Assert.IsNotNull(messageId, $"No new email - {email}");

            _objectContext.SetDebugInformation($"FetchMessageRequest using domain - {domain}, Inbox - {inbox} and message id - {messageId}");

            //Fetch Message
            FetchMessageRequest fetchMessageRequest = new() { Domain = domain, Inbox = inbox, MessageId = messageId };

            FetchMessageResponse fetchMessageResponse = mailinatorClient.MessagesClient.FetchMessageAsync(fetchMessageRequest).Result;

            _objectContext.SetMessage((domain, inbox, messageId));

            Assert.That(fetchMessageResponse.Parts.Any(x => x.Body.Contains(expected)), Is.True, $"{email} did not contain '{expected}'");

            var actual = fetchMessageResponse.Parts.FirstOrDefault(x => x.Body.Contains(expected))?.Body;

            _objectContext.SetDebugInformation($"Actual message received {Environment.NewLine}{actual}");
        });
    }
}
