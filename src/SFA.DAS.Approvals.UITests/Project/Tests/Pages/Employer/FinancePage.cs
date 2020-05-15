using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class FinancePage : InterimEmployerBasePage
    {
        protected override string Linktext => "Finance";

        protected override string PageTitle => "Finance";

        private ScenarioContext _context;

        private By TransferLink => By.LinkText("Transfers");

        public FinancePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            VerifyPage();
        }

        internal TransfersPage OpenTransfers()
        {
            formCompletionHelper.ClickElement(TransferLink);
            return new TransfersPage(_context);
        }
    }
}