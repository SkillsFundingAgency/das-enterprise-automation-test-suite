using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class ChallengePage : BasePage
    {
        protected override string PageTitle => "Enter the following information to verify the caller";

        protected override By PageHeader => By.CssSelector(".lede");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By Challenge1 => By.Id("challenge1");
        private By Challenge2 => By.Id("challenge2");
        private By LevyBalance => By.Id("balance");
        private By Challenge_ErrorMessage => By.CssSelector(".error-summary");

        public ChallengePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public void EnterChallenge(string challenge1, string challenge2)
        {
            _formCompletionHelper.EnterText(Challenge1, challenge1);
            _formCompletionHelper.EnterText(Challenge2, challenge2);
        }

        public void EnterCurrentLevybalance(string balance) => _formCompletionHelper.EnterText(LevyBalance, balance);

        public void VerifyChallengeResponseErrorMessage(string errorMessage) => _pageInteractionHelper.VerifyText(Challenge_ErrorMessage, errorMessage);
    }

    public class FinancePage : BasePage
    {
        protected override string PageTitle => "Finanace";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly SupportConsoleConfig _config;
        #endregion

        public FinancePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

    }

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
        private By FinanceLink => By.LinkText("Finance");
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

        public void ClickFinanceMenuLink() => _formCompletionHelper.Click(FinanceLink);

        private AccountOverviewPage ClickOrganisationsLink()
        {
            _formCompletionHelper.Click(OrganisationsMenuLink);
            return this;
        }
    }
}