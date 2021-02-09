using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework
{
    public abstract class OuterApiRestClient
    {
        private RestClient _restClient;

        private RestRequest _restRequest;

        protected abstract string ApiEndpoint { get; }

        public OuterApiRestClient(string subscriptionkey) => CreateOuterApiRestClient(subscriptionkey);

        public void CreateRestRequest(Method method, string resource, string payload)
        {
            _restRequest.Method = method;

            _restRequest.Resource = resource.Contains(ApiEndpoint) ? resource : $"{ApiEndpoint}{resource}";

            if (!string.IsNullOrEmpty(payload)) 
            {
                if (payload.EndsWith(".json")) { _restRequest.AddJsonBody(JsonFileHelper.ReadAllText(payload)); }

                else { _restRequest.AddJsonBody(payload); }
            }
        }

        public void Addheaders(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                _restRequest.AddHeader(item.Key, item.Value);
            }
        }

        public IRestResponse Execute() => _restClient.Execute(_restRequest);

        private void CreateOuterApiRestClient(string subscriptionkey)
        {
            _restClient = new RestClient(UrlConfig.OuterApiBaseUrl);

            _restRequest = new RestRequest();

            AddAuthHeaders(subscriptionkey);
        }

        private void AddAuthHeaders(string subscriptionkey)
        {
            Addheaders(
                new Dictionary<string, string>
                {
                    { "X-Version", "1" },
                    { "Ocp-Apim-Subscription-Key", subscriptionkey}
                });
        }
    }
}
