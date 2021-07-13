using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_ApprenticeCommitmentsApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_ApprenticeCommitmentsApiRestClient(Outer_ApprenticeCommitmentsApiAuthTokenConfig config) : base(config.Code) { }

        protected override string ApiName => "/api";

        protected override string ApiBaseUrl => UrlConfig.Outer_ApprenticeCommitmentsApiBaseUrl;

        public IRestResponse CreateApprenticeship(CreateApprenticeship payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/test-apprenticeship-created-event", payload, expectedResponse);
        }

        public IRestResponse VerifyIdentity(VerifyIdentityRegistrationCommand payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/registrations", payload, expectedResponse);
        }

        public IRestResponse ChangeApprenticeEmailAddress(string apprenticeId, ApprenticeEmailAddressRequest payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/apprentices/{apprenticeId}/email", payload, expectedResponse);
        }

        public IRestResponse GetApprenticeships(string apprenticeId, HttpStatusCode expectedResponse)
        {
            return Execute($"/apprentices/{apprenticeId}/apprenticeships", expectedResponse);
        }

        public IRestResponse GetApprenticeship(string apprenticeId, string commitmentsApprenticeshipId, HttpStatusCode expectedResponse)
        {
            return Execute($"/apprentices/{apprenticeId}/apprenticeships/{long.Parse(commitmentsApprenticeshipId)}", expectedResponse);
        }

        protected override void AddAuthHeaders() { }

        protected override void AddParameter() => restRequest.AddParameter("code", ApiAuthKey, ParameterType.QueryString);
    }
}
