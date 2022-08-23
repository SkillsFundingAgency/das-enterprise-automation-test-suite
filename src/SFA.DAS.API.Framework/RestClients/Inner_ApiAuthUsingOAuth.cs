
namespace SFA.DAS.API.Framework.RestClients;

public class Inner_ApiAuthUsingOAuth : IInner_ApiGetAuthToken
{
    private RestClient _restClient;

    private RestRequest _restRequest;

    private readonly Configs.Inner_ApiAuthConfigUsingOAuth _config;

    public Inner_ApiAuthUsingOAuth(Configs.Inner_ApiAuthConfigUsingOAuth config)
    {
        _config = config;

        CreateInnerApiAuthTokenRestClient();
    }

    public (string tokenType, string accessToken) GetAuthToken()
    {
        _restRequest.Method = Method.POST;

        _restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");

        _restRequest.AddParameter("application/x-www-form-urlencoded", $"client_id={_config.ClientId}&client_secret={_config.ClientSecrets}&grant_type={Configs.Inner_ApiAuthConfigUsingOAuth.GrantType}&resource={_config.GetResource()}", ParameterType.RequestBody);

        IRestResponse response = _restClient.Execute(_restRequest);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new System.Exception($"Failed to get auth token.{Environment.NewLine} {response.Content}", response.ErrorException);
        }

        AuthTokenResponse authToken = JsonConvert.DeserializeObject<AuthTokenResponse>(response.Content);

        return (authToken.Token_type, authToken.Access_token);
    }

    private void CreateInnerApiAuthTokenRestClient()
    {
        _restClient = new RestClient(UrlConfig.InnerApiUrlConfig.MangeIdentitybaseUrl(_config.Tenant));

        _restRequest = new RestRequest();
    }
}
