using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;


namespace SFA.DAS.RAA_V2.APITests.Project
{
    public class Outer_EmployerAccountLegalEntitiesApiClient : Outer_BaseApiRestClient
    {

        public Outer_EmployerAccountLegalEntitiesApiClient(Outer_ApiAuthTokenConfig config) : base(config) { }

        protected override string ApiName => "";

        protected override string ApiBaseUrl => UrlConfig.Outer_ApiBaseUrl;
    }
}
