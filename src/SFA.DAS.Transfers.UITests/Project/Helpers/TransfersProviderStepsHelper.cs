using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersProviderStepsHelper : ProviderStepsHelper
    {
        public TransfersProviderStepsHelper(ScenarioContext context) : base(context) { }

        public void ApprovesTheCohortsAndSendsToEmployer() => EditApprentice().SubmitApprove();
    }
}