using RestSharp;
using SFA.DAS.ConfigurationBuilder;

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

        _restRequest.AddParameter("application/x-www-form-urlencoded", $@"client_id={_config.config.ClientId}&client_secret={_config.config.ClientSecrets}&grant_type=client_credentials&resource={_config.GetResource(appServiceName)}", ParameterType.RequestBody);

        var response = new AssertHelper(_objectContext).ExecuteAndAssertResponse(HttpStatusCode.OK, _restClient, _restRequest);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to get auth token.{Environment.NewLine} {response.Content}", response.ErrorException);
        }

        AuthTokenResponse authToken = JsonConvert.DeserializeObject<AuthTokenResponse>(response.Content);

        return (authToken.Token_type, authToken.Access_token);
    }

    private void CreateInnerApiAuthTokenRestClient()
    {
        _restClient = new RestClient(UrlConfig.InnerApiUrlConfig.MangeIdentitybaseUrl(_config.config.TenantId));

        _restRequest = new RestRequest();
    }
}
