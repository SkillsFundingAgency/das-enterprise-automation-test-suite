using RestSharp;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TransferMatching.APITests.Project.Helpers;
using System.Net;

namespace SFA.DAS.TransferMatching.APITests.Project
{
    public class TransferMatchingJobs_AutoApprovalClient : TransferMatchingJobsBaseRestClient
    {
        public TransferMatchingJobs_AutoApprovalClient(ObjectContext objectContext, TransferMatchingJobsConfig config) : base(objectContext, config.ApplicationsWithAutomaticApproval_Code) { }

        protected override string ApiName => "/api";

        public RestResponse ApplicationsWithAutomaticApprovalJob(HttpStatusCode expectedResponse)
        {
            return Execute($"/ApplicationsWithAutomaticApproval", expectedResponse);
        }

        protected override void AddAuthHeaders() { }

        protected override void AddParameter() => restRequest.AddParameter("code", Code, ParameterType.QueryString);


    }
}
