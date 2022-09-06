using RestSharp.Authenticators;

namespace SFA.DAS.API.Framework.RestClients;

public abstract class Inner_BaseApiRestClient : BaseApiRestClient
{
    protected readonly Inner_ApiFrameworkConfig config;

    protected abstract string AppServiceName { get; }

    public Inner_BaseApiRestClient(ObjectContext objectContext, Inner_ApiFrameworkConfig config) : base(objectContext) => this.config = config;

    protected override void AddResource(string resource) => restRequest.Resource = resource;

    protected override void AddAuthHeaders()
        => AddAuthenticator(config.IsVstsExecution ? GetOAuthToken() : GetAADAuthToken());

    private void AddAuthenticator((string tokenType, string accessToken) token)
        => restClient.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token.accessToken, token.tokenType);

    private (string tokenType, string accessToken) GetAADAuthToken() => new Inner_ApiAuthUsingMI(config).GetAuthToken(AppServiceName);

    private (string tokenType, string accessToken) GetOAuthToken() => new Inner_ApiAuthUsingOAuth(config, objectContext).GetAuthToken(AppServiceName);
}
