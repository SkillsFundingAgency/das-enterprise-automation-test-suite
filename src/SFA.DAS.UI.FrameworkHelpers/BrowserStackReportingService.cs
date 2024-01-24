using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;

namespace SFA.DAS.UI.FrameworkHelpers;

public class BrowserStackReportingService(BrowserStackSetting options)
{
    public void UpdateTestName(string sessionId, string name) => Execute(sessionId, UpdateNameJSonBody($"{options.Name}-{name}"));

    public void MarkTestStatus(string sessionId, bool testStatus, string message)
    {
        var response = Execute(sessionId, JSonBody(testStatus, message));

        if (IsNotSucess(response)) throw new Exception(response.Content, response.ErrorException);
    }

    private RestResponse Execute(string sessionId, object jsonObj)
    {
        var request = Request(sessionId, jsonObj);

        var response = Client(options).Put(request);

        if (IsNotSucess(response)) NUnit.Framework.TestContext.Progress.WriteLine($"{response.StatusCode} - {response.Content}");

        return response;
    }

    private static bool IsNotSucess(RestResponse response) => response.StatusCode != HttpStatusCode.OK;

    private static string JSonBody(bool testStatus, string exceptionmessage)
    {
        object obj;

        if (testStatus) obj = new { status = "passed" };

        else obj = new { status = "failed", reason = exceptionmessage };

        return JsonConvert.SerializeObject(obj);
    }
    private static string UpdateNameJSonBody(string newname) => JsonConvert.SerializeObject(new { name = $"{newname}", });

    private static RestRequest Request(string sessionId, object jsonObj) => Request(sessionId).AddJsonBody(jsonObj);

    private static RestRequest Request(string sessionId) => new($"{sessionId}.json", Method.Put) { RequestFormat = DataFormat.Json };

    private static RestClient Client(BrowserStackSetting options) => new(new RestClientOptions { BaseUrl = new Uri(BrowserStackSetting.AutomateSessions), Authenticator = new HttpBasicAuthenticator(options.User, options.Key) });
}
