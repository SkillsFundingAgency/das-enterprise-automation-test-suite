using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.StandardsVersioning.APITests
{
    public class CoursesInnerApiRestClient : InnerApiRestClient
    {
        public CoursesInnerApiRestClient(ManageIdentityApiRestClient manageIdentityApiRestClient) : base(manageIdentityApiRestClient)
        {

        }

        protected override string Inner_ApiBaseUrl => UrlConfig.Inner_CoursesApiBaseUrl;

        public void PerformHeathCheck(string endpoint)
        {
            CreateRestRequest(RestSharp.Method.GET, endpoint, string.Empty);
        }

    }
}
