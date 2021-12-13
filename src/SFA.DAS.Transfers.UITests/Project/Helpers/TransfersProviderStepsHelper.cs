using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersProviderStepsHelper : ProviderStepsHelper
    {
        private readonly ScenarioContext context;
        public TransfersProviderStepsHelper(ScenarioContext context) : base(context)
        {
            context = context;
        }

        public void ApprovesTheCohortsAndSendsToEmployer()
        {
            EditApprentice().SubmitApprove();
        }
    }
}