
namespace SFA.DAS.RAA_V2.APITests.Project;

public class Outer_EmployerAccountLegalEntitiesApiClient : Outer_BaseApiRestClient
{
    public Outer_EmployerAccountLegalEntitiesApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : base(objectContext, config) { }

    protected override string ApiName => "";

    protected override string ApiBaseUrl => UrlConfig.OuterApiUrlConfig.Outer_RAAV2ApiBaseUrl;

    public new void CreateRestRequest(Method method, string resource, string payload)
    {
        base.CreateRestRequest(method, resource, payload);

        restRequest.RequestFormat = DataFormat.Json;

        Addheader("Content-Type", "application/json");

        Addheader("Accept", "application/json");

    }
}
