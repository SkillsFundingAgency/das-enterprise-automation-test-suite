using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class CommitmentsInnerApiRestClient : InnerApiRestClient
    {
        public CommitmentsInnerApiRestClient(ManageIdentityApiRestClient manageIdentityApiRestClient) : base(manageIdentityApiRestClient)
        {

        }

        protected override string Inner_ApiBaseUrl => UrlConfig.Inner_CommitmentsApiBaseUrl;

        public void PerformHeathCheck()
        {
            CreateRestRequest(RestSharp.Method.GET, "/ping", string.Empty);
        }

    }
}
