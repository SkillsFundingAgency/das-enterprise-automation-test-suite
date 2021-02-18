using RestSharp;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.Helpers;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_ApprenticeCommitmentsApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_ApprenticeCommitmentsApiRestClient(Outer_ApiAuthTokenConfig config) : base(config) { }

        protected override string ApiName => "/apprenticecommitments";

        protected override string ApiSubscriptionKey => config.ApprenticeCommitmentsApiSubscriptionKey;

        public void CreateApprenticeship(CreateApprenticeship createApprenticeship)
        {
            var payload = JsonHelper.Serialize(createApprenticeship);

            CreateRestRequest(Method.POST, "/apprenticeships", payload);
        }
    }
}
