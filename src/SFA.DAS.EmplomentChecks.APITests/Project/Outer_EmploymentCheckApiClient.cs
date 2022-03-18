using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.EmploymentChecks.APITests
{
    public class Outer_EmploymentCheckApiClient : Outer_BaseApiRestClient
    {
        public Outer_EmploymentCheckApiClient(Outer_ApiAuthTokenConfig config) : base(config) { }

        protected override string ApiName => "employmentcheck";

        protected override string ApiBaseUrl => UrlConfig.Outer_ApiBaseUrl;
    }
}
