using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.AssessorCertification.APITests.Project
{
    public class Outer_AssessorCertificationApiRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config.NAS_Apim_SubscriptionKey)
    {
        readonly string environment = EnvironmentConfig.IsPPEnvironment ? "preprod" : EnvironmentConfig.EnvironmentName;
        
        protected override string ApiName => $"/assessor-service-api-{environment}";

        protected override string ApiBaseUrl => UrlConfig.OuterApiUrlConfig.Outer_AssessorCertificationApiBaseUrl;
    }
}

   