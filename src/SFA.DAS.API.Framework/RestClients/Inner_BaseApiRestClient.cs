using RestSharp.Authenticators;

namespace SFA.DAS.API.Framework.RestClients;

public abstract class Inner_BaseApiRestClient : BaseApiRestClient
{
    protected readonly Inner_ApiFrameworkConfig config;

    protected abstract string AppServiceName { get; }

    public Inner_BaseApiRestClient(ObjectContext objectContext, Inner_ApiFrameworkConfig config) : base(objectContext) => this.config = config;

    protected override void AddResource(string resource) => restRequest.Resource = resource;

    protected override void AddAuthHeaders()
    {
        if (config.IsVstsExecution) AddOAuthHeaders();

        else AddMIAuthHeaders();
    }

    private void AddMIAuthHeaders()
    {
        (string tokenType, string accessToken) = new Inner_ApiAuthUsingMI(config).GetAuthToken(AppServiceName);

        restClient.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, tokenType);
    }

    private void AddOAuthHeaders()
    {
        (string tokenType, string accessToken) = new Inner_ApiAuthUsingOAuth(config).GetAuthToken(AppServiceName);

        Addheader("Authorization", $"{tokenType} {accessToken}");
    }
}
