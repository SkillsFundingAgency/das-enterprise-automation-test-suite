using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerFinance.APITests.Project
{
    public class Outer_EmployerFinanceHealthApiRestClient(ObjectContext objectContext) : Outer_HealthApiRestClient(objectContext, UrlConfig.OuterApiUrlConfig.Outer_EmployerFinanceHealthBaseUrl)
    {
    }
}
