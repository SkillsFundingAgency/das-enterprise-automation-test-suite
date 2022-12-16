using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class ApprenticeCommitmentsJobs_CreateApprenticeshipClient : Outer_BaseApiRestClient
    {
        public ApprenticeCommitmentsJobs_CreateApprenticeshipClient(ObjectContext objectContext, ApprenticeCommitmentsJobsAuthTokenConfig config) : base(objectContext, config.Code) { }

        protected override string ApiName => "/api";

        protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.ApprenticeCommitmentsJobs_BaseUrl;

        public RestResponse CreateApprenticeshipViaCommitmentsJob(CreateApprenticeshipViaCommitmentsJob payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.Post, $"/test-apprenticeship-created-event", payload, expectedResponse);
        }

        protected override void AddAuthHeaders() { }

        protected override void AddParameter() => restRequest.AddParameter("code", ApiAuthKey, ParameterType.QueryString);
    }
}
