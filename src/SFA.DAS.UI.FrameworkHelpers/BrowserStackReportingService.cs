using System;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class BrowserStackReportingService
    {
        private readonly BrowserStackSetting _options;

        public BrowserStackReportingService(BrowserStackSetting options) => _options = options;

        public void UpdateTestName(string sessionId, string name) => Execute(sessionId, UpdateNameJSonBody($"{_options.Name}-{name}"));

        public void MarkTestAsFailed(string sessionId, string message)
        {
            var response = Execute(sessionId, JSonBody(message));

            if (IsNotSucess(response)) throw new Exception(response.Content, response.ErrorException);
        }

        private IRestResponse Execute(string sessionId, object jsonObj)
        {
            var request = Request(sessionId, jsonObj);

            var response = Client(_options).Put(request);

            if (IsNotSucess(response)) NUnit.Framework.TestContext.Progress.WriteLine($"{response.StatusCode} - {response.Content}");

            return response;
        }

        private bool IsNotSucess(IRestResponse response) => response.StatusCode != HttpStatusCode.OK;

        private static string JSonBody(string exceptionmessage) => JsonConvert.SerializeObject(new { status = "failed", reason = exceptionmessage });

        private static string UpdateNameJSonBody(string newname) => JsonConvert.SerializeObject(new { name = $"{newname}", });

        private static IRestRequest Request(string sessionId, object jsonObj) => Request(sessionId).AddJsonBody(jsonObj);

        private static RestRequest Request(string sessionId) => new RestRequest($"{sessionId}.json", Method.PUT) { RequestFormat = DataFormat.Json };

        private static RestClient Client(BrowserStackSetting options) => new RestClient(options.AutomateSessions) { Authenticator = new HttpBasicAuthenticator(options.User, options.Key) };
    }
}
