namespace SFA.DAS.RAA.APITests.Project
{
    public abstract class Recruit_BaseApiRestClient(ObjectContext objectContext, string authKey) : BaseApiRestClient(objectContext)
    {
        protected readonly string _authKey = authKey;

        protected abstract string ApiName { get; }

        protected virtual string ApiAuthKey => _authKey;

        protected override string ApiBaseUrl => UrlConfig.OuterApiUrlConfig.Outer_ApiBaseUrl;

        public Recruit_BaseApiRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : this(objectContext, config.EmployerRecruit_ApiKey) { }

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
}
