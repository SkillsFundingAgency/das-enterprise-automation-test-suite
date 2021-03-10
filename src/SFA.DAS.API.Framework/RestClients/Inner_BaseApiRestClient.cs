using RestSharp;
using SFA.DAS.API.Framework.Configs;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class Inner_BaseApiRestClient : BaseApiRestClient
    {
        private readonly Inner_ApiAuthTokenConfig _config;

        protected abstract string Inner_ApiBaseUrl { get; }

        public Inner_BaseApiRestClient(Inner_ApiAuthTokenConfig config)
        {
            _config = config;

            CreateInnerApiRestClient();
        }

        protected override void AddResource(string resource) => restRequest.Resource = resource;

        protected override void AddAuthHeaders()
        {
            var restClient = new Inner_ApiAuthTokenRestClient(_config);

            (string tokenType, string accessToken) = restClient.GetAuthToken();

            Addheader("Authorization", $"{tokenType} {accessToken}");
        }

        private void CreateInnerApiRestClient()
        {
            restClient = new RestClient(Inner_ApiBaseUrl);

            restRequest = new RestRequest();
        }
    }
}
