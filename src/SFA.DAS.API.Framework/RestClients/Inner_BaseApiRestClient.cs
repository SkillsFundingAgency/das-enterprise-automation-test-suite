using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace SFA.DAS.API.Framework.RestClients;

public abstract class Inner_BaseApiRestClient(ObjectContext objectContext, Inner_ApiFrameworkConfig config) : BaseApiRestClient(objectContext)
{
    protected readonly Inner_ApiFrameworkConfig config = config;

    protected abstract string AppServiceName { get; }

    protected override void AddResource(string resource) => restRequest.Resource = resource;

    protected override void AddAuthHeaders() 
    {
        var options = GetClientOptions();

        options.Authenticator = GetAuthenticator();

        restClient = new(options);
    }

    private OAuth2AuthorizationRequestHeaderAuthenticator GetAuthenticator() 
    {
        (string tokenType, string accessToken) = config.IsVstsExecution ? GetOAuthToken() : GetAADAuthToken();

        return new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, tokenType);
    } 

    private (string tokenType, string accessToken) GetAADAuthToken() => new Inner_ApiAuthUsingMI(config).GetAuthToken(AppServiceName);

    private (string tokenType, string accessToken) GetOAuthToken() => new Inner_ApiAuthUsingOAuth(config, objectContext).GetAuthToken(AppServiceName);
}
