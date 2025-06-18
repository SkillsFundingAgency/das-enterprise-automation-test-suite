using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoERequestedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Change of employer requested";

        protected override bool TakeFullScreenShot => false;

        public ProviderCoERequestedPage VerifyChangeOfEmployerHasBeenRequested() => this;
    }
}
