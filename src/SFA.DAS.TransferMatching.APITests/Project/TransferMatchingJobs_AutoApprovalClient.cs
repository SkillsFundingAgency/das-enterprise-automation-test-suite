using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;
using System.Net;

namespace SFA.DAS.TransferMatching.APITests.Project
{
    public class TransferMatchingJobs_AutoApprovalClient(ObjectContext objectContext, TransferMatchingJobsConfig config) : OuterJobs_BaseApiRestClient(objectContext, config.ApplicationsWithAutomaticApproval_Code)
    {
        protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.LevyTransferMatchingJobs_BaseUrl;

        public RestResponse ApplicationsWithAutomaticApprovalJob(HttpStatusCode expectedResponse)
        {
            return Execute($"/ApplicationsWithAutomaticApproval", expectedResponse);
        }
    }
}
