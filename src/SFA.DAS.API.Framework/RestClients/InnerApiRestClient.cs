using RestSharp;
using System.Collections.Generic;

namespace SFA.DAS.API.Framework.RestClients
{
    public abstract class InnerApiRestClient : BaseApiRestClient
    {
        private readonly ManageIdentityApiRestClient _manageIdentityApiRestClient;

        protected abstract string Inner_ApiBaseUrl { get; }

        public InnerApiRestClient(ManageIdentityApiRestClient manageIdentityApiRestClient)
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

            Addheaders(
                new Dictionary<string, string>
                {
                    { "Authorization", $"{tokenType} {accessToken}" }
                });
        }

        private void CreateInnerApiRestClient()
        {
            _restClient = new RestClient(Inner_ApiBaseUrl);

            _restRequest = new RestRequest();
        }
    }
}
