using RestSharp;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework
{
    public class FrameworkRestClient
    {
        private RestClient _restClient;

        private RestRequest _restRequest;

        public FrameworkRestClient(string baseurl) => CreateRestClient(baseurl);

        public void CreateRestRequest(Method method, string resource, string payload)
        {
            _restRequest.Method = method;
            
            _restRequest.Resource = resource;

            if (!(string.IsNullOrEmpty(payload))) { _restRequest.AddJsonBody(JsonFileHelper.ReadAllText(payload)); }
        }

        public void Addheaders(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                _restRequest.AddHeader(item.Key, item.Value);
            }
        }

        public void AddAuthHeaders(string subscriptionkey)
        {
            Addheaders(
                new Dictionary<string, string>
    {
                    { "X-Version", "1" },
                    { "Ocp-Apim-Subscription-Key", subscriptionkey}
                });
        }

        public IRestResponse Execute() => _restClient.Execute(_restRequest);

        private void CreateRestClient(string baseurl)
        {
            _restClient = new RestClient(baseurl);

            _restRequest = new RestRequest();
        }
    }
}
