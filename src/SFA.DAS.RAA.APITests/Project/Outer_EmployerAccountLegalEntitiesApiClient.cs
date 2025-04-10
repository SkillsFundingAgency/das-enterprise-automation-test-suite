namespace SFA.DAS.RAA.APITests.Project;

public class Outer_RecruitApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config)
{
    protected override string ApiName => "recruit";
}
