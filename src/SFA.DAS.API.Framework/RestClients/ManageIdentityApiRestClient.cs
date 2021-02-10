using Newtonsoft.Json;
using RestSharp;
using SFA.DAS.API.Framework.Configs;
using System.Net;

namespace SFA.DAS.API.Framework.RestClients
{
    public class ManageIdentityApiRestClient
    {
        private RestClient _restClient;

        private RestRequest _restRequest;

        private readonly ManageIdentityOathTokenConfig _config;

        public ManageIdentityApiRestClient(ManageIdentityOathTokenConfig config)
        {
            _config = config;

            CreateManageIdentityApiRestClient();
        }

        private void CreateManageIdentityApiRestClient()
        {
            _restClient = new RestClient(UrlConfig.MangeIdentitybaseUrl(_config.Tenant));

            _restRequest = new RestRequest();
        }

        public (string tokenType, string accessToken) GetAuthToken()
        {
            _restRequest.Method = Method.POST;

            _restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");

            _restRequest.AddParameter("application/x-www-form-urlencoded", $"client_id={_config.ClientId}&client_secret={_config.ClientSecrets}&grant_type={_config.GrantType}&resource={_config.Resource}", ParameterType.RequestBody);

            IRestResponse response = _restClient.Execute(_restRequest);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return (string.Empty, string.Empty);
            }

            AuthTokenResponse authToken = JsonConvert.DeserializeObject<AuthTokenResponse>(response.Content);

            return (authToken.Token_type, authToken.Access_token);
        }
    }
}
