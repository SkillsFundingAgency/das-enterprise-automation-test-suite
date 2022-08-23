using RestSharp.Authenticators;

namespace SFA.DAS.API.Framework.RestClients;

public abstract class Inner_BaseApiRestClientUsingMI : Inner_BaseApiRestClient
{
    public Inner_BaseApiRestClientUsingMI(ObjectContext objectContext, IInner_ApiGetAuthToken apiAuthToken) : base(objectContext, apiAuthToken)
    {

    }

    protected override void AddAuthHeaders()
    {
        (string tokenType, string accessToken) = _apiAuthToken.GetAuthToken();

        restClient.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, tokenType);
    }
}
