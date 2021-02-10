using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class CommitmentsInnerApiRestClient : InnerApiRestClient
    {
        public CommitmentsInnerApiRestClient(AuthTokenApiRestClient manageIdentityApiRestClient) : base(manageIdentityApiRestClient)
        {

        }

        protected override string Inner_ApiBaseUrl => UrlConfig.Inner_CommitmentsApiBaseUrl;

        public void PerformHeathCheck(string endpoint)
        {
            CreateRestRequest(RestSharp.Method.GET, endpoint, string.Empty);
        }

    }
}
