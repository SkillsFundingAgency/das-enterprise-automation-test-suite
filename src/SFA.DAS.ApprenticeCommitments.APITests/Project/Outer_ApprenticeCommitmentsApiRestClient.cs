using RestSharp;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_ApprenticeCommitmentsApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_ApprenticeCommitmentsApiRestClient(Outer_ApiAuthTokenConfig config) : base(config) { }

        protected override string ApiName => "/apprenticecommitments";

        protected override string ApiSubscriptionKey => config.ApprenticeCommitmentsApiSubscriptionKey;

        public IRestResponse CreateApprenticeship(CreateApprenticeship payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/apprenticeships", payload, expectedResponse);
        }

        public IRestResponse VerifyRegistration(VerifyIdentityRegistrationCommand payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/registrations", payload, expectedResponse);
        }

        public IRestResponse ChangeApprenticeEmailAddress(long apprenticeId, ApprenticeEmailAddressRequest payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/apprentices/{apprenticeId}/email", payload, expectedResponse);
        }
    }
}
