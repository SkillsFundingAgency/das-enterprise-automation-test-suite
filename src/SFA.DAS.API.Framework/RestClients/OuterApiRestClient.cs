using RestSharp;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class OuterApiRestClient : BaseApiRestClient
    {
        protected abstract string ApiName { get; }

        public OuterApiRestClient(string subscriptionkey) => CreateOuterApiRestClient(subscriptionkey);

        public override void CreateRestRequest(Method method, string resource, string payload)
        {
            _restRequest.Method = method;

            _restRequest.Resource = resource.Contains(ApiName) ? resource : $"{ApiName}{resource}";

            AddPayload(payload);
        }

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
