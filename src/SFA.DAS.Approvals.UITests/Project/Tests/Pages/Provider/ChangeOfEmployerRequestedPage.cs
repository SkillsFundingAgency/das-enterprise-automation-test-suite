using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerRequestedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Change of employer requested";

        protected override bool TakeFullScreenShot => false;

        public ChangeOfEmployerRequestedPage(ScenarioContext context) : base(context) { }

        public ChangeOfEmployerRequestedPage VerifyChangeOfEmployerHasBeenRequested() => this;
    }
}
