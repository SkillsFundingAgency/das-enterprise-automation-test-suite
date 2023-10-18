using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace SFA.DAS.API.Framework.RestClients;

public abstract class Inner_BaseApiRestClient : BaseApiRestClient
{
    protected readonly Inner_ApiFrameworkConfig config;

    protected abstract string AppServiceName { get; }

    public Inner_BaseApiRestClient(ObjectContext objectContext, Inner_ApiFrameworkConfig config) : base(objectContext)
    {
        this.config = config;

        var options = GetClientOptions();

        options.Authenticator = GetAuthenticator();

        restClient = new(options);
    }

    protected override void AddResource(string resource) => restRequest.Resource = resource;

    protected override void AddAuthHeaders() { }

    private IAuthenticator GetAuthenticator() 
    {
        (string tokenType, string accessToken) = config.IsVstsExecution ? GetOAuthToken() : GetAADAuthToken();

        return new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, tokenType);
    } 

    private (string tokenType, string accessToken) GetAADAuthToken() => new Inner_ApiAuthUsingMI(config).GetAuthToken(AppServiceName);

    private (string tokenType, string accessToken) GetOAuthToken() => new Inner_ApiAuthUsingOAuth(config, objectContext).GetAuthToken(AppServiceName);
}
