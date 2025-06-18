using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersProviderStepsHelper(ScenarioContext context) : ProviderStepsHelper(context)
    {
        private readonly ProviderEditStepsHelper _providerEditStepsHelper = new(context);

        public void ApprovesTheCohortsAndSendsToEmployer() => EditApprentice().SubmitApprove();

        public ProviderApproveApprenticeDetailsPage EditApprentice() => _providerEditStepsHelper.EditApprentice();
    }
}