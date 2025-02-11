using System.Net;
using RestSharp;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.APITests.Project.Helpers
{
    public class TransferMatchingJobsHelper
    {
        private readonly TransferMatchingJobs_AutoApprovalClient _transferMatchingJobs_AutoApprovalClient;
        private readonly TransferMatchingJobs_AutoRejectionClient _transferMatchingJobs_AutoRejectionClient;
        private readonly ObjectContext _objectContext;

        public TransferMatchingJobsHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();

            _transferMatchingJobs_AutoApprovalClient = new TransferMatchingJobs_AutoApprovalClient(_objectContext, context.GetTransferMatchingJobsConfig<TransferMatchingJobsConfig>());
            _transferMatchingJobs_AutoRejectionClient = new TransferMatchingJobs_AutoRejectionClient(_objectContext, context.GetTransferMatchingJobsConfig<TransferMatchingJobsConfig>());
        }

        public RestResponse RunApplicationsWithAutomaticApprovalJob()
        {
            return _transferMatchingJobs_AutoApprovalClient.ApplicationsWithAutomaticApprovalJob(HttpStatusCode.OK);
        }

        public RestResponse RunApplicationsWithAutomaticRejectionJob()
        {
            return _transferMatchingJobs_AutoRejectionClient.ApplicationsWithAutomaticRejectionJob(HttpStatusCode.OK);
        }
    }
}