namespace SFA.DAS.RAA.APITests.Project;

public class Outer_ManageVacancyApiClient(ObjectContext objectContext, string authKey) : Outer_BaseApiRestClient(objectContext, authKey)
{
    protected override string ApiName => "managevacancies";

    protected override string ApiBaseUrl => UrlConfig.OuterApiUrlConfig.Outer_ApiBaseUrl;

    //public new void CreateRestRequest(Method method, string resource, string payload)
    //{
    //    base.CreateRestRequest(method, resource, payload);

    //    restRequest.RequestFormat = DataFormat.Json;

    //    Addheader("Content-Type", "application/json");

    //    Addheader("Accept", "application/json");
    //}
}
