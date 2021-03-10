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
            restClient = new RestClient(UrlConfig.Outer_ApiBaseUrl);

            restRequest = new RestRequest();

            AddAuthHeaders();
        }
    }
}
