using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmploymentChecks.APITests
{
    public class Outer_EmploymentCheckApiClient : Outer_BaseApiRestClient
    {
        public Outer_EmploymentCheckApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : base(objectContext, config) { }

        protected override string ApiName => "employmentcheck";
    }
}
