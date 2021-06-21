using RestSharp;
using SFA.DAS.API.Framework.Configs;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class Outer_BaseApiRestClient : BaseApiRestClient
    {
        protected readonly Outer_ApiAuthTokenConfig config;

        protected abstract string ApiName { get; }

        protected virtual string ApiSubscriptionKey => config.Apim_SubscriptionKey;

        protected virtual string ApiBaseUrl => UrlConfig.Outer_ApiBaseUrl;

        public Outer_BaseApiRestClient(Outer_ApiAuthTokenConfig config)
        {
            this.config = config;

            CreateOuterApiRestClient();
        }

        protected override void AddResource(string resource) => restRequest.Resource = resource.Contains(ApiName) ? resource : $"{ApiName}{resource}";

        protected override void AddAuthHeaders()
        {
            Addheaders(
                new Dictionary<string, string>
                {
                    { "X-Version", "1" },
                    { "Ocp-Apim-Subscription-Key", ApiSubscriptionKey}
                });
        }

        private void CreateOuterApiRestClient()
        {
            restClient = new RestClient(ApiBaseUrl);

            restRequest = new RestRequest();

            AddAuthHeaders();
        }
    }
}
