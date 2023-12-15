using RestSharp;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_ApprenticeCommitmentsApiRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config)
    {
        protected override string ApiName => "/apprenticecommitments";

        public RestResponse CreateApprovalsCreatedEvent(ApprovalsCreated payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.Post, $"/approvals", payload, expectedResponse);
        }

        public RestResponse CreateApprenticeship(CreateApprenticeshipFromRegistration payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.Post, $"/apprenticeships", payload, expectedResponse);
        }

        public RestResponse GetApprenticeships(string apprenticeId, HttpStatusCode expectedResponse)
        {
            return Execute($"/apprentices/{apprenticeId}/apprenticeships", expectedResponse);
        }

        public RestResponse GetApprenticeship(string apprenticeId, string commitmentsApprenticeshipId, HttpStatusCode expectedResponse)
        {
            return Execute($"/apprentices/{apprenticeId}/apprenticeships/{long.Parse(commitmentsApprenticeshipId)}", expectedResponse);
        }
    }
}
