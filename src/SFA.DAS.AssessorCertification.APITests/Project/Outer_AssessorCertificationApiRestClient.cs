using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.Helpers;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.AssessorCertification.APITests.Project
{
    public class Outer_AssessorCertificationApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_AssessorCertificationApiRestClient(Outer_ApiAuthTokenConfig config) : base(config) { }

        protected override string ApiName => $"/assessor-service-api-{EnvironmentConfig.EnvironmentName}";
        protected override string ApiBaseUrl => UrlConfig.Outer_AssessorCertificationApiBaseUrl;

    }
}

   