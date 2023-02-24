using mailinator_csharp_client;
using mailinator_csharp_client.Models.Domains.Responses;
using mailinator_csharp_client.Models.Messages.Entities;
using mailinator_csharp_client.Models.Messages.Requests;
using mailinator_csharp_client.Models.Responses;
using NUnit.Framework;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.MailinatorAPI.Service.Project.Helpers;

public class MailinatorApiHelper
{
    private readonly MailinatorClient mailinatorClient;
    
    private readonly RetryAssertHelper _assertHelper;
    
    private readonly ObjectContext _objectContext;

    private static readonly HashSet<string> mailers = new();

    public MailinatorApiHelper(ScenarioContext context)
    {
        mailinatorClient = new(context.Get<MailinatorConfig>().ApiToken);

        _assertHelper = context.Get<RetryAssertHelper>();

        _objectContext = context.Get<ObjectContext>();
    }

    internal void DeleteInbox()
    {
        foreach (var email in mailers)
        {
            (string inbox, string domain) = GetEmail(email);

            //Delete Message
            DeleteAllInboxMessagesRequest deleteMessageRequest = new() { Domain = domain, Inbox = inbox };

            _ = mailinatorClient.MessagesClient.DeleteAllInboxMessagesAsync(deleteMessageRequest).Result;
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
        string link = "https://";

        string body = VerifyEmail(email, expected);

        var match = Regex.Match(body, $"{link}.*", RegexOptions.IgnoreCase);

        return match.Groups[0].Value;
    }

    public string VerifyEmail(string email, string expected)
    {
        Func<Part, bool> Partsfunc() => (x) => IsItHtmlMessage(x) && x.Body.Contains(expected);

        Func<FetchMessageResponse, bool> func() => (x) => x.Parts.Any(x => Partsfunc().Invoke(x));

        string body = string.Empty;

        (string inbox, string domain) = GetEmail(email);

        _assertHelper.RetryOnNUnitExceptionWithLongerTimeOut(() =>
        {
            FetchMessageResponse fetchMessageResponse = FetchMessage(inbox, domain, func());

            Assert.That(func().Invoke(fetchMessageResponse), Is.True, $"{email} did not contain '{expected}'");

            body = fetchMessageResponse.Parts.FirstOrDefault(x => Partsfunc().Invoke(x))?.Body;

            _objectContext.SetDebugInformation($"Actual message received {Environment.NewLine}{body}");
        });

        return body;
    }

    private static (string inbox, string domain) GetEmail(string email)
    {
        mailers.Add(email);

        var emailSplit = email.Split('@');

        return (emailSplit[0], emailSplit[1]);
    }

    private FetchMessageResponse FetchMessage(string inbox, string domain, Func<FetchMessageResponse, bool> func)
    {
        _objectContext.SetDebugInformation($"FetchInboxRequest using domain - {domain}, Inbox - {inbox}");

        //Fetch Inbox
        FetchInboxRequest fetchInboxRequest = new() { Domain = domain, Inbox = inbox, Skip = 0, Limit = 20, Sort = Sort.asc };

        FetchInboxResponse fetchInboxResponse = mailinatorClient.MessagesClient.FetchInboxAsync(fetchInboxRequest).Result;

        var messageId = fetchInboxResponse.Messages.FirstOrDefault(x => func(FetchMessage(inbox, domain, x.Id)))?.Id;

        Assert.IsNotNull(messageId, $"No new email - {inbox}@{domain}");

        //Fetch Message

        return FetchMessage(inbox, domain, messageId);
    }

    private FetchMessageResponse FetchMessage(string inbox, string domain, string messageId)
    {
        //Fetch Message

        _objectContext.SetDebugInformation($"FetchMessageRequest using domain - {domain}, Inbox - {inbox} and message id - {messageId}");

        FetchMessageRequest fetchMessageRequest = new() { Domain = domain, Inbox = inbox, MessageId = messageId };

        FetchMessageResponse fetchMessageResponse = mailinatorClient.MessagesClient.FetchMessageAsync(fetchMessageRequest).Result;

        foreach (var item in fetchMessageResponse.Parts)
        {
            if (IsItHtmlMessage(item))
            {
                var body = item.Body;

                _objectContext.SetDebugInformation($"Actual message received {Environment.NewLine}{body}");
            }

        }
        return fetchMessageResponse;
    }

    private static bool IsItHtmlMessage(Part p) => p.Headers.Any(h => h.Key == "content-type" && h.Value.ToString().Contains("text/plain;"));
}