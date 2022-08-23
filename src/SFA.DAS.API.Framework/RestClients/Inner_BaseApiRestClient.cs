namespace SFA.DAS.API.Framework.RestClients;

public abstract class Inner_BaseApiRestClient : BaseApiRestClient
{
    protected readonly IInner_ApiGetAuthToken _apiAuthToken;

    protected abstract string Inner_ApiBaseUrl { get; }

    public Inner_BaseApiRestClient(ObjectContext objectContext, IInner_ApiGetAuthToken apiAuthToken) : base(objectContext)
    {
        _apiAuthToken = apiAuthToken;

        CreateInnerApiRestClient();
    }

    protected override void AddResource(string resource) => restRequest.Resource = resource;

    protected override void AddAuthHeaders()
    {
        (string tokenType, string accessToken) = _apiAuthToken.GetAuthToken();

        Addheader("Authorization", $"{tokenType} {accessToken}");
    }

    private void CreateInnerApiRestClient()
    {
        restClient = new RestClient(Inner_ApiBaseUrl);

        restRequest = new RestRequest();
    }
}
