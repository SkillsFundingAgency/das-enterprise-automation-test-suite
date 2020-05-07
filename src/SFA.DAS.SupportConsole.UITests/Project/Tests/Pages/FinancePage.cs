using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class FinancePage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Finance";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LevyDeclarationsViewLink => By.LinkText("view");

        private By TransactionsViewLink => By.LinkText("Transactions");

        private By CurrentBalance => By.CssSelector(".data__purple-block");

        public FinancePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public LevyDeclarationsPage ViewLevyDeclarations()
        {
            _formCompletionHelper.Click(LevyDeclarationsViewLink);
            return new LevyDeclarationsPage(_context);
        }

        public void ViewTransactions()
        {
            _formCompletionHelper.Click(TransactionsViewLink);
            _pageInteractionHelper.VerifyText(CurrentBalance, "Current balance");
        }

    }
}