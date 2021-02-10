using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Inner_CommitmentsApiRestClient : Inner_BaseApiRestClient
    {
        public Inner_CommitmentsApiRestClient(Inner_ApiAuthTokenRestClient manageIdentityApiRestClient) : base(manageIdentityApiRestClient)
        {

        }

        protected override string Inner_ApiBaseUrl => UrlConfig.Inner_CommitmentsApiBaseUrl;

        public void PerformHeathCheck(string endpoint)
        {
            CreateRestRequest(RestSharp.Method.GET, endpoint, string.Empty);
        }

        public void GetApprenticeship(long app)
        {
            CreateRestRequest(RestSharp.Method.GET, $"/api/apprenticeships/{app}", string.Empty);
        }
    }
}
