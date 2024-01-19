namespace SFA.DAS.RAA_V2.APITests.Project;

public class Outer_RecruitApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config)
{
    protected override string ApiName => "recruit";

    protected override string ApiBaseUrl => UrlConfig.OuterApiUrlConfig.Outer_ApiBaseUrl;

    public new void CreateRestRequest(Method method, string resource, string payload)
    {
        base.CreateRestRequest(method, resource, payload);

        restRequest.RequestFormat = DataFormat.Json;

        Addheader("Content-Type", "application/json");

        Addheader("Accept", "application/json");

    }
}
