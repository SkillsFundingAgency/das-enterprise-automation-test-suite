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

        private string AccountSearchHint => "Enter account name, account ID or PAYE scheme";
        private string UserSearchHint => "Enter name or email address";

        public SearchHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AccountOverviewPage SearchByAccountIdAndViewAccount() => SearchAndViewAccount(config.AccountId);
        
        public AccountOverviewPage SearchByAccountNameAndViewAccount() => SearchAndViewAccount(config.AccountName);

        public AccountOverviewPage SearchByPayeSchemeAndViewAccount() => SearchAndViewAccount(config.PayeScheme);

        private AccountOverviewPage SearchAndViewAccount(string criteria)
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(AccountsRadioButton, "AccountSearchType");
            pageInteractionHelper.WaitForElementToChange(SearchTextBox, "placeholder", AccountSearchHint);
            formCompletionHelper.EnterText(SearchTextBox, criteria);
            formCompletionHelper.Click(SearchButton);
            tableRowHelper.SelectRowFromTable("view", config.AccountId);
            return new AccountOverviewPage(_context);
        }
    }
}