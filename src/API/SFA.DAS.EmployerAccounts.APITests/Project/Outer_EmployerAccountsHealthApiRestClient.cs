using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerAccounts.APITests.Project
{
    public class Outer_EmployerAccountsHealthApiRestClient(ObjectContext objectContext) : Outer_HealthApiRestClient(objectContext, UrlConfig.OuterApiUrlConfig.Outer_EmployerAccountsHealthBaseUrl)
    {
    }
}
