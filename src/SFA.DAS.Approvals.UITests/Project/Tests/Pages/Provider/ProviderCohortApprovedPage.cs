using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortApprovedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Cohort approved";

        protected override bool TakeFullScreenShot => false;

        public ProviderCohortApprovedPage(ScenarioContext context) : base(context) { }       
    }
}
