using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerRequestedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Change of employer requested";

        public ChangeOfEmployerRequestedPage(ScenarioContext context) : base(context) { }

        public ChangeOfEmployerRequestedPage VerifyChangeOfEmployerHasBeenRequested()
        {
            return this;
        }
    }
}
