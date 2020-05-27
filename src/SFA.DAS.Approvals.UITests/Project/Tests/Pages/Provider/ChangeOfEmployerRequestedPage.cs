using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerRequestedPage : BasePage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Change of employer requested";
        public ChangeOfEmployerRequestedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ChangeOfEmployerRequestedPage VerifyChangeOfEmployerHasBeenRequested()
        {
            return this;
        }
    }
}
