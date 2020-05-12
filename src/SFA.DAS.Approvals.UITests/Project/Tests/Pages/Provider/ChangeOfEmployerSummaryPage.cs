using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerSummaryPage : BasePage
    {
        private readonly ScenarioContext _context;
        public ChangeOfEmployerSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        protected override string PageTitle => "Confirm the information before sending your request";

        public ChangeOfEmployerRequestedPage VerifyAndSubmitChangeOfEmployerRequest()
        {
            VerifyPage();
            //Verify values in hidden fields


            Continue();
            return new ChangeOfEmployerRequestedPage(_context);
        }
    }
}
