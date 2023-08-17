using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Helpers
{
    public class TransfersProviderStepsHelper : ProviderStepsHelper
    {
        private readonly ProviderEditStepsHelper _providerEditStepsHelper;

        public TransfersProviderStepsHelper(ScenarioContext context) : base(context) => _providerEditStepsHelper = new ProviderEditStepsHelper(context);

        public void ApprovesTheCohortsAndSendsToEmployer() => EditApprentice().SubmitApprove();

        public new ProviderApproveApprenticeDetailsPage EditApprentice() => _providerEditStepsHelper.EditApprentice();
    }
}