namespace SFA.DAS.API.Framework.RestClients;

public class Inner_ApiAuthUsingOAuth : IInner_ApiGetAuthToken
{
    private RestClient _restClient;

    private RestRequest _restRequest;

    private readonly Inner_ApiFrameworkConfig _config;

    private readonly ObjectContext _objectContext;

    public Inner_ApiAuthUsingOAuth(Inner_ApiFrameworkConfig config, ObjectContext objectContext) { _config = config; _objectContext = objectContext; }

    public (string tokenType, string accessToken) GetAuthToken(string appServiceName)
    {
        CreateInnerApiAuthTokenRestClient();

        _restRequest.Method = Method.POST;

        _restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");

        var authParameter = new InnerApiOAuthModel(_config.config.ClientId, _config.config.ClientSecrets, _config.GetResource(appServiceName));

        _restRequest.AddParameter("application/x-www-form-urlencoded", authParameter.ToString(), ParameterType.RequestBody);

        var response = new ApiAssertHelper(_objectContext).ExecuteAuthTokenAndAssertResponse(_restClient, _restRequest);

        AuthTokenResponse authToken = JsonConvert.DeserializeObject<AuthTokenResponse>(response.Content);

        return (authToken.Token_type, authToken.Access_token);
    }

    private void CreateInnerApiAuthTokenRestClient()
    {
        _restClient = new RestClient(UrlConfig.InnerApiUrlConfig.MangeIdentitybaseUrl(_config.config.TenantId));

        _restRequest = new RestRequest();
    }
}
