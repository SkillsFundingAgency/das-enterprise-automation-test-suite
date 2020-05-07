using DnsClient.Protocol;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class FinancePage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Finanace";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LevyDeclarationsViewLink => By.LinkText("view");

        private By TransactionsViewLink => By.LinkText("Transactions");

        private By CurrentBalance => By.CssSelector(".data__purple-block");

        public FinancePage(ScenarioContext context, bool navigate = false) : base(context)
        {
            _context = context;
            if (navigate)
            {
                ClickFinanceMenuLink();
            }
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

    public class LevyDeclarationsPage : SupportConsoleBasePage
    {

        protected override string PageTitle => "Levy declarations";

        protected override By PageHeader => By.CssSelector(".heading-large");

        public LevyDeclarationsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }

    public class TeamMembersPage : SupportConsoleBasePage
    {

        protected override string PageTitle => "Team members";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        public TeamMembersPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}