using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmploymentChecks.APITests.Project;

public class Outer_EmploymentCheckApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config)
{
    protected override string ApiName => "employmentcheck";
}
