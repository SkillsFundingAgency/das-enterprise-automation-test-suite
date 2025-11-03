using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Inner_ApprenticeAccountsApiRestClient(ObjectContext objectContext, Inner_ApiFrameworkConfig config) : Inner_BaseApiRestClient(objectContext, config)
    {
        protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.Inner_ApprenticeAccountsApiBaseUrl;

        protected override string AppServiceName => config.config.ApprenticeAccountsAppServiceName;

        public RestResponse CreateApprentice(Apprentice payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.Post, $"/apprentices", payload, expectedResponse);
        }
    }
}
