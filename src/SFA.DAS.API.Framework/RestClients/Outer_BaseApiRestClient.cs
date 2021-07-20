using RestSharp;
using SFA.DAS.API.Framework.Configs;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class Outer_BaseApiRestClient : BaseApiRestClient
    {
        protected readonly string _authKey;

        protected abstract string ApiName { get; }

        protected virtual string ApiAuthKey => _authKey;

        protected virtual string ApiBaseUrl => UrlConfig.Outer_ApiBaseUrl;

        public Outer_BaseApiRestClient(Outer_ApiAuthTokenConfig config) : this(config.Apim_SubscriptionKey) { }

        public Outer_BaseApiRestClient(string authKey)
        {
            _authKey = authKey;

            CreateOuterApiRestClient();
        }

        protected override void AddResource(string resource) => restRequest.Resource = resource.Contains(ApiName) ? resource : $"{ApiName}{resource}";

        protected override void AddAuthHeaders()
        {
            Addheaders(
                new Dictionary<string, string>
                {
                    { "X-Version", "1" },
                    { "Ocp-Apim-Subscription-Key", ApiAuthKey}
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
