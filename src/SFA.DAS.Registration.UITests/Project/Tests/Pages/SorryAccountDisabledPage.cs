using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SorryAccountDisabledPage : RegistrationBasePage
    {
        protected override string PageTitle => "Sorry";
        private readonly ScenarioContext _context;

        #region Locators
        private By AddViaGGLink => By.LinkText("Try adding your PAYE scheme via Government Gateway");
        private By AccountDisabledInfo => By.CssSelector(".govuk-body");
        #endregion

        #region Constants
        public const string AccountDisabledInfoMessage = "Due to incorrect attempts, this has been disabled for 30 minutes.";
        #endregion

        public SorryAccountDisabledPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            VerifyPage(AccountDisabledInfo, AccountDisabledInfoMessage);
        }

        public UsingYourGovtGatewayDetailsPage ClickAddViaGGLink()
        {
            formCompletionHelper.Click(AddViaGGLink);
            return new UsingYourGovtGatewayDetailsPage(_context);
        }
    }
}