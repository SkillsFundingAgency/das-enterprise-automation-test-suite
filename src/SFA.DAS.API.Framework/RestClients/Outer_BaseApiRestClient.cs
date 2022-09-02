namespace SFA.DAS.API.Framework.RestClients;

public abstract class Outer_BaseApiRestClient : BaseApiRestClient
{
    protected readonly string _authKey;

    protected abstract string ApiName { get; }

    protected virtual string ApiAuthKey => _authKey;

    protected override string ApiBaseUrl => UrlConfig.OuterApiUrlConfig.Outer_ApiBaseUrl;

    public Outer_BaseApiRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : this(objectContext, config.Apim_SubscriptionKey) { }

    public Outer_BaseApiRestClient(ObjectContext objectContext, string authKey) : base(objectContext) => _authKey = authKey;

    protected override void AddResource(string resource) => restRequest.Resource = resource.Contains(ApiName) ? resource : $"{ApiName}{resource}";

    protected override void AddAuthHeaders()
    {
        Addheaders(
            new Dictionary<string, string>
            {
                { "X-Version", "1" },
                { "Ocp-Apim-Subscription-Key", ApiAuthKey}
            });
    }
}
