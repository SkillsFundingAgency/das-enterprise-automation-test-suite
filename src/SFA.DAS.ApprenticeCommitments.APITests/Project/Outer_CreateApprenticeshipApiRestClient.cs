using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_CreateApprenticeshipApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_CreateApprenticeshipApiRestClient(ApprenticeCommitmentsJobsAuthTokenConfig config) : base(config.Code) { }

        protected override string ApiName => "/api";

        protected override string ApiBaseUrl => UrlConfig.ApprenticeCommitmentsJobs_BaseUrl;

        public IRestResponse CreateApprenticeship(CreateApprenticeship payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/test-apprenticeship-created-event", payload, expectedResponse);
        }

        protected override void AddAuthHeaders() { }

        protected override void AddParameter() => restRequest.AddParameter("code", ApiAuthKey, ParameterType.QueryString);
    }
}
