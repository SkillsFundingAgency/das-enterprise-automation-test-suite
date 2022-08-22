
namespace SFA.DAS.RAA_V2.APITests.Project;

public class Outer_EmployerAccountLegalEntitiesApiClient : Outer_BaseApiRestClient
{
    public Outer_EmployerAccountLegalEntitiesApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : base(objectContext, config) { }

    protected override string ApiName => "";

    protected override string ApiBaseUrl => UrlConfig.Outer_ApiBaseUrl;
}
