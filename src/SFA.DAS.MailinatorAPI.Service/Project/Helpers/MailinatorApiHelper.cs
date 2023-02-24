using mailinator_csharp_client;
using mailinator_csharp_client.Models.Domains.Responses;
using mailinator_csharp_client.Models.Messages.Entities;
using mailinator_csharp_client.Models.Messages.Requests;
using mailinator_csharp_client.Models.Responses;
using NUnit.Framework;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport;
using System;
using System.Linq;
using System.Text.RegularExpressions;
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

    public string GetData(string email, string expected)
    {
        string data = string.Empty;

        (string inbox, string domain) = GetEmail(email);

        _assertHelper.RetryOnNUnitException(() =>
        {
            FetchMessageResponse fetchMessageResponse = FetchMessage(inbox, domain);

            var body = fetchMessageResponse.Parts.FirstOrDefault(x => x.Headers.Any(h => h.Key == "content-type" && h.Value.ToString().Contains("text/plain;")) && x.Body.Contains(expected))?.Body;

            Assert.IsNotNull(body, $"No body found with content - {expected}");

            _objectContext.SetDebugInformation($"Actual message received {Environment.NewLine}{body}");

            var match = Regex.Match(body, $"{@expected}.*", RegexOptions.IgnoreCase);

            data = match.Groups[0].Value;
        });

        return data;

    }

    public void VerifyEmail(string email, string expected)
    {
        (string inbox, string domain) = GetEmail(email);

        _assertHelper.RetryOnNUnitExceptionWithLongerTimeOut(() =>
        {
            FetchMessageResponse fetchMessageResponse = FetchMessage(inbox, domain);

            Assert.That(fetchMessageResponse.Parts.Any(x => x.Body.Contains(expected)), Is.True, $"{email} did not contain '{expected}'");

            var actual = fetchMessageResponse.Parts.FirstOrDefault(x => x.Body.Contains(expected))?.Body;

            _objectContext.SetDebugInformation($"Actual message received {Environment.NewLine}{actual}");
        });
    }

    private static (string inbox, string domain) GetEmail(string email)
    {
        var emailSplit = email.Split('@');

        return (emailSplit[0], emailSplit[1]);
    }

    private FetchMessageResponse FetchMessage(string inbox, string domain)
    {
        _objectContext.SetDebugInformation($"FetchInboxRequest using domain - {domain}, Inbox - {inbox}");

        //Fetch Inbox
        FetchInboxRequest fetchInboxRequest = new() { Domain = domain, Inbox = inbox, Skip = 0, Limit = 20, Sort = Sort.asc };

        FetchInboxResponse fetchInboxResponse = mailinatorClient.MessagesClient.FetchInboxAsync(fetchInboxRequest).Result;

        var messageId = fetchInboxResponse.Messages.FirstOrDefault()?.Id;

        Assert.IsNotNull(messageId, $"No new email - {inbox}@{domain}");

        _objectContext.SetDebugInformation($"FetchMessageRequest using domain - {domain}, Inbox - {inbox} and message id - {messageId}");

        //Fetch Message
        FetchMessageRequest fetchMessageRequest = new() { Domain = domain, Inbox = inbox, MessageId = messageId };

        FetchMessageResponse fetchMessageResponse = mailinatorClient.MessagesClient.FetchMessageAsync(fetchMessageRequest).Result;

        _objectContext.SetMessage((domain, inbox, messageId));

        return fetchMessageResponse;
    }
}