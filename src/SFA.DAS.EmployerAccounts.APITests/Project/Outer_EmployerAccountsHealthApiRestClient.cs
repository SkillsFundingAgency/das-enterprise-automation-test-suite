using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerAccounts.APITests.Project
{
    public class Outer_EmployerAccountsHealthApiRestClient : Outer_HealthApiRestClient
    {
        public Outer_EmployerAccountsHealthApiRestClient(ObjectContext objectContext) : base(objectContext, UrlConfig.OuterApiUrlConfig.Outer_EmployerAccountsHealthBaseUrl) { }
    }
}
