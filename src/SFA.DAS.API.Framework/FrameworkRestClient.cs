using RestSharp;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework
{
    public abstract class FrameworkRestClient
    {
        private RestClient _restClient;

        private RestRequest _restRequest;

        protected abstract string ApiEndpoint { get; }

        public FrameworkRestClient(string subscriptionkey) => CreateRestClient(subscriptionkey);

        public void CreateRestRequest(Method method, string resource, string payload)
        {
            _restRequest.Method = method;

            _restRequest.Resource = resource.Contains(ApiEndpoint) ? resource : $"{ApiEndpoint}{resource}";

            if (!string.IsNullOrEmpty(payload)) { _restRequest.AddJsonBody(JsonFileHelper.ReadAllText(payload)); }
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

        private void CreateRestClient(string subscriptionkey)
        {
            _restClient = new RestClient(UrlConfig.ApiBaseUrl);

            _restRequest = new RestRequest();

            AddAuthHeaders(subscriptionkey);
        }
    }
}
