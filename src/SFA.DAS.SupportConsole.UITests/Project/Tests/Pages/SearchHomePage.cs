using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class SearchHomePage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Search";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        protected override By PageHeader => By.CssSelector(".heading-large");
        private By AccountsRadioButton => By.CssSelector("label");
        private By SearchButton => By.Id("searchButton");
        private By SearchTextBox => By.Id("search-main");
        #endregion

        public SearchHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AccountOverviewPage SearchAndViewAccount()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(AccountsRadioButton, "AccountSearchType");
            formCompletionHelper.EnterText(SearchTextBox, config.AccountId);
            formCompletionHelper.Click(SearchButton);
            tableRowHelper.SelectRowFromTable("view", config.AccountId);
            return new AccountOverviewPage(_context);
        }
    }
}