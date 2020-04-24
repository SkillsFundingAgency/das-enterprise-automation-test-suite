using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class AccountOverviewPage : BasePage
    {
        protected override string PageTitle => "Department for Education";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly SupportConsoleConfig _config;

        #endregion

        #region Locators
        protected override By PageHeader => By.CssSelector(".heading-large");
        private By PageHeaderWithAccountDetails => By.CssSelector(".heading-secondary");
        private By OrganisationsMenuLink => By.LinkText("Organisations");
        private By CommitmentsMenuLink => By.LinkText("Commitments");
        #endregion

        public AccountOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            ClickOrganisationsLink(); //Doing this to refresh the page as the Header dissappears at times - known issue
            VerifyPage();
            VerifyPage(PageHeaderWithAccountDetails, _config.AccountDetails);
        }

        public CommitmentsSearchPage ClickCommitmentsMenuLink()
        {
            _formCompletionHelper.Click(CommitmentsMenuLink);
            return new CommitmentsSearchPage(_context);
        }

        private AccountOverviewPage ClickOrganisationsLink()
        {
            _formCompletionHelper.Click(OrganisationsMenuLink);
            return this;
        }
    }
}