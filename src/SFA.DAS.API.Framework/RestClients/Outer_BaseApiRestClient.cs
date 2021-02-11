using RestSharp;
using SFA.DAS.API.Framework.Configs;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class Outer_BaseApiRestClient : BaseApiRestClient
    {
        protected readonly Outer_ApiAuthTokenConfig config;

        protected abstract string ApiName { get; }

        protected abstract string ApiSubscriptionKey { get; }

        public Outer_BaseApiRestClient(Outer_ApiAuthTokenConfig config)
        {
            this.config = config;

            CreateOuterApiRestClient();
        }

        public override void CreateRestRequest(Method method, string resource, string payload)
        {
            _restRequest.Method = method;

            _restRequest.Resource = resource.Contains(ApiName) ? resource : $"{ApiName}{resource}";

            AddPayload(payload);
        }

        private void CreateOuterApiRestClient()
        {
            _restClient = new RestClient(UrlConfig.Outer_ApiBaseUrl);

            _restRequest = new RestRequest();

            AddAuthHeaders();
        }

        private void AddAuthHeaders()
        {
            Addheaders(
                new Dictionary<string, string>
                {
                    { "X-Version", "1" },
                    { "Ocp-Apim-Subscription-Key", ApiSubscriptionKey}
                });
        }
    }
}
