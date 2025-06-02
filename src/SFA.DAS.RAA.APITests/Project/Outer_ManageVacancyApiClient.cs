namespace SFA.DAS.RAA.APITests.Project;

public class Outer_ManageVacancyApiClient(ObjectContext objectContext, string authKey) : Outer_BaseApiRestClient(objectContext, authKey)
{
    protected override string ApiName => "managevacancies";
}
