using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersProviderStepsHelper : ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        public TransfersProviderStepsHelper(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public void ApprovesTheCohortsAndSendsToEmployer()
        {
            EditApprentice()
                .SelectContinueToApproval()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }
    }
}