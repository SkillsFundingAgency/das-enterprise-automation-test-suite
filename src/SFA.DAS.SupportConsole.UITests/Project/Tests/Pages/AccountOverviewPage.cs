using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class AccountOverviewPage : SupportConsoleBasePage
    {
        protected override string PageTitle => config.AccountName;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        protected override By PageHeader => By.CssSelector(".heading-large");
        private By PageHeaderWithAccountDetails => By.CssSelector(".heading-secondary");
        #endregion

        public AccountOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            RefreshPage(); //Doing this to refresh the page as the Header dissappears at times - known issue
            VerifyPage();
            VerifyPage(PageHeaderWithAccountDetails, config.AccountDetails);
        }

        public TeamMembersPage ClickTeamMembersLink()
        {
            formCompletionHelper.Click(TeamMembersLink);
            return new TeamMembersPage(_context);
        }

        public CommitmentsSearchPage ClickCommitmentsMenuLink()
        {
            formCompletionHelper.Click(CommitmentsMenuLink);
            return new CommitmentsSearchPage(_context);
        }

        private void RefreshPage() => formCompletionHelper.Click(OrganisationsMenuLink);
    }
}