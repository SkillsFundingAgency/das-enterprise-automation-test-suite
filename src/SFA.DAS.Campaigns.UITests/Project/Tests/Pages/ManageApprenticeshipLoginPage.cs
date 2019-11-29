using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    public class ManageApprenticeshipLoginPage: BasePage
    {
        protected override string PageTitle => "";
        #region Constants
        private const string ExpectedPageTitle = "Sign In";
        private const string EmailAddress="sultan.m4hmood+qa1@gmail.com";
        private const string Password ="Testing01";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Object Elements
        private readonly By _pageHeading =By.XPath("//h1[@class='heading-xlarge']");
        //private readonly By _emailAddressField = By.XPath("//input [@class='form-control form-control-3-4']");
        private readonly By _emailAddressField = By.Id("EmailAddress");

        private readonly By _passwordField = By.Id("Password");
        private readonly By _signInButton=By.Id("button-signin");
        private readonly By _createAccountButton = By.XPath("//a[@class='button hero__panel-button']");
        #endregion


        public ManageApprenticeshipLoginPage(ScenarioContext context):base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public ManageApprenticeshipHomePage EmployerLogsIn()
        {
           
            _formCompletionHelper.EnterText(_emailAddressField,EmailAddress);
            _formCompletionHelper.EnterText(_passwordField,Password);
            _formCompletionHelper.ClickElement(_signInButton);
            return new ManageApprenticeshipHomePage(_context);
        }


    }
}