using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Inner_CommitmentsApiRestClient(ObjectContext objectContext, API.Framework.Configs.Inner_ApiFrameworkConfig config) : Inner_BaseApiRestClient(objectContext, config)
    {
        protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.Inner_CommitmentsApiBaseUrl;

        protected override string AppServiceName => config.config.CommitmentsAppServiceName;

        public void GetApprenticeship(long app, HttpStatusCode expectedResponse) => Execute(Method.Get, $"/api/apprenticeships/{app}", string.Empty, expectedResponse);
    }
}
