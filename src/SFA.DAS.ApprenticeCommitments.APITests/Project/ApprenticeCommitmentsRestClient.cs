using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class ApprenticeCommitmentsRestClient : Outer_BaseApiRestClient
    {
        public ApprenticeCommitmentsRestClient(string subscriptionkey) : base(subscriptionkey) { }

        protected override string ApiName => "/apprenticecommitments";

        public void CreateApprenticeship(CreateApprenticeship createApprenticeship)
        {
            var payload = JsonHelper.Serialize(createApprenticeship);

            CreateRestRequest(Method.POST, "/apprenticeships", payload);
        }
    }
}
