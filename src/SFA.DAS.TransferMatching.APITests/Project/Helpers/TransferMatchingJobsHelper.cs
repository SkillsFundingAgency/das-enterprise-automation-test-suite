using RestSharp;
using SFA.DAS.FrameworkHelpers;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.APITests.Project.Helpers
{
    public class TransferMatchingJobsHelper
    {
        private readonly TransferMatchingJobs_AutoApprovalClient _transferMatchingJobs_AutoApprovalClient;       
        private readonly ObjectContext _objectContext;
        protected readonly FrameworkHelpers.RetryAssertHelper _assertHelper;

        public TransferMatchingJobsHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<FrameworkHelpers.RetryAssertHelper>();            
            _transferMatchingJobs_AutoApprovalClient = new TransferMatchingJobs_AutoApprovalClient(_objectContext, context.GetTransferMatchingJobsConfig<TransferMatchingJobsConfig>());
  
        }
     
        public RestResponse RunApplicationsWithAutomaticApprovalJob()
        {         
            return _transferMatchingJobs_AutoApprovalClient.ApplicationsWithAutomaticApprovalJob(HttpStatusCode.OK);
        }   
    }
}