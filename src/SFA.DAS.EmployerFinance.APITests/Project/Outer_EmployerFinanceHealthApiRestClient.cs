using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerFinance.APITests.Project
{
    public class Outer_EmployerFinanceHealthApiRestClient : Outer_HealthApiRestClient
    {
        public Outer_EmployerFinanceHealthApiRestClient(ObjectContext objectContext) : base(objectContext, UrlConfig.OuterApiUrlConfig.Outer_EmployerFinanceHealthBaseUrl) { }
    }
}
