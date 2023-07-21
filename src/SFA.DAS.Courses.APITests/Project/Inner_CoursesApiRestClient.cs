using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;
using System.Net;

namespace SFA.DAS.Courses.APITests.Project
{
    public class Inner_CoursesApiRestClient : Inner_BaseApiRestClient
    {
        public Inner_CoursesApiRestClient(ObjectContext objectContext, API.Framework.Configs.Inner_ApiFrameworkConfig config) : base(objectContext, (config)) { }

        protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.Inner_CoursesApiBaseUrl;

        protected override string AppServiceName => config.config.CoursesAppServiceName;

        public void PerformHeathCheck(string endpoint, HttpStatusCode expectedResponse)
        {
            Execute(RestSharp.Method.Get, endpoint, string.Empty, expectedResponse);
        }
    }
}
