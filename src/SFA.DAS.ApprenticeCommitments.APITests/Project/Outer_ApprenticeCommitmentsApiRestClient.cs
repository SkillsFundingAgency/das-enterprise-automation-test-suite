using RestSharp;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_ApprenticeCommitmentsApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_ApprenticeCommitmentsApiRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : base(objectContext, config) { }

        protected override string ApiName => "/apprenticecommitments";

        public IRestResponse CreateApprovalsCreatedEvent(ApprovalsCreated payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/approvals", payload, expectedResponse);
        }

        public IRestResponse CreateApprentice(Apprentice payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/apprentices", payload, expectedResponse);
        }

        public IRestResponse CreateApprenticeship(CreateApprenticeshipFromRegistration payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/apprenticeships", payload, expectedResponse);
        }

        public IRestResponse GetApprenticeships(string apprenticeId, HttpStatusCode expectedResponse)
        {
            return Execute($"/apprentices/{apprenticeId}/apprenticeships", expectedResponse);
        }

        public IRestResponse GetApprenticeship(string apprenticeId, string commitmentsApprenticeshipId, HttpStatusCode expectedResponse)
        {
            return Execute($"/apprentices/{apprenticeId}/apprenticeships/{long.Parse(commitmentsApprenticeshipId)}", expectedResponse);
        }
    }
}
