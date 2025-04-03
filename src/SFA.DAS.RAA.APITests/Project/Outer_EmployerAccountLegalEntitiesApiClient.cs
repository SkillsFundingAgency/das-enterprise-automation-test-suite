namespace SFA.DAS.RAA.APITests.Project;

public class Outer_RecruitApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config, string apiBaseUrl) : Outer_BaseApiRestClient(objectContext, config)
{
    private readonly string _apiBaseUrl = apiBaseUrl;
    protected override string ApiName => "";

    protected override string ApiBaseUrl => _apiBaseUrl;

    public new void CreateRestRequest(Method method, string resource, string payload)
    {
        base.CreateRestRequest(method, resource, payload);

        restRequest.RequestFormat = DataFormat.Json;

        Addheader("Content-Type", "application/json");

        Addheader("Accept", "application/json");

    }
}
