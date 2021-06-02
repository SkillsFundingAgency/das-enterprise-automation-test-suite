using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using System.Net;

namespace SFA.DAS.Courses.APITests.Project
{
    public class Inner_CoursesApiRestClient : Inner_BaseApiRestClient
    {
        public Inner_CoursesApiRestClient(Inner_ApiAuthTokenConfig config) : base(config) { }

        protected override string Inner_ApiBaseUrl => UrlConfig.Inner_CoursesApiBaseUrl;

        public void PerformHeathCheck(string endpoint, HttpStatusCode expectedResponse)
        {
            Execute(RestSharp.Method.GET, endpoint, string.Empty, expectedResponse);
        }
    }
}
