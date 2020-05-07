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

        private By ViewlevyDeclarations = By.LinkText("view");

        public FinancePage(ScenarioContext context, bool navigate = false) : base(context)
        {
            _context = context;
            if (navigate)
            {
                ClickFinanceMenuLink();
            }
            VerifyPage();
        }
    }
}