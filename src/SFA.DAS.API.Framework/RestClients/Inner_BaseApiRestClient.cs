using RestSharp;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class Inner_BaseApiRestClient : BaseApiRestClient
    {
        private readonly Inner_ApiAuthTokenRestClient _manageIdentityApiRestClient;

        protected abstract string Inner_ApiBaseUrl { get; }

        public Inner_BaseApiRestClient(Inner_ApiAuthTokenRestClient manageIdentityApiRestClient)
        {
            _manageIdentityApiRestClient = manageIdentityApiRestClient;

            CreateInnerApiRestClient();
        }

        public override void CreateRestRequest(Method method, string resource, string payload)
        {
            AddAuthHeaders();

            AddPayload(payload);
        }

        private void AddAuthHeaders()
        {
            (string tokenType, string accessToken) = _manageIdentityApiRestClient.GetAuthToken();

            Addheader("Authorization", $"{tokenType} {accessToken}");
        }

        private void CreateInnerApiRestClient()
        {
            _restClient = new RestClient(Inner_ApiBaseUrl);

            _restRequest = new RestRequest();
        }
    }
}
