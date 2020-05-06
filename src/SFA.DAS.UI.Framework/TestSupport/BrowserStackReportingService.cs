using System;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class BrowserStackReportingService
    {
        private readonly BrowserStackSetting _options;

        private readonly RestClient _restClient;

        public BrowserStackReportingService(BrowserStackSetting options)
        {
            _options = options;
            _restClient = Client(options);
        }

        public void UpdateTestName(string sessionId, string name)
        {
            var request = Request(sessionId);

            request.AddJsonBody(UpdateNameJSonBody($"{_options.Name}-{name}"));

            var response = _restClient.Put(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                NUnit.Framework.TestContext.Progress.WriteLine($"{response.StatusCode} - {response.Content}");
            }
        }

        public void MarkTestAsFailed(string sessionId, string message)
        {
            var request = Request(sessionId);

            request.AddJsonBody(JSonBody(message));

            var response = _restClient.Put(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                NUnit.Framework.TestContext.Progress.WriteLine($"{response.StatusCode} - {response.Content}");

                throw new Exception(response.Content, response.ErrorException);
            }
        }

        private static RestClient Client(BrowserStackSetting options)
        {
            return new RestClient(options.AutomateSessions)
            {
                Authenticator = new HttpBasicAuthenticator(options.User, options.Key)
            };
        }

        private static RestRequest Request(string sessionId)
        {
            return new RestRequest($"{sessionId}.json", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
        }

        private static string JSonBody(string exceptionmessage)
        {
            return JsonConvert.SerializeObject(new { status = "failed", reason = exceptionmessage });
        }

        private static string UpdateNameJSonBody(string newname)
        {
            return JsonConvert.SerializeObject(new { name = $"{newname}", });
        }
    }
}
