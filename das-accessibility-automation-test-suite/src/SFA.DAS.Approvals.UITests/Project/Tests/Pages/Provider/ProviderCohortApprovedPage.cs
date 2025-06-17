using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortApprovedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Cohort approved";

        protected override bool TakeFullScreenShot => false;
    }
}
