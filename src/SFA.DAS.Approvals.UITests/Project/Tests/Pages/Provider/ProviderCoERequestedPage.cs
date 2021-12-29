using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoERequestedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Change of employer requested";

        protected override bool TakeFullScreenShot => false;

        public ProviderCoERequestedPage(ScenarioContext context) : base(context) { }

        public ProviderCoERequestedPage VerifyChangeOfEmployerHasBeenRequested() => this;
    }
}
