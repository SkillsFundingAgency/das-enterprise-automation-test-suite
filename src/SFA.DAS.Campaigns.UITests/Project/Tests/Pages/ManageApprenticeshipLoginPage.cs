using OpenQA.Selenium;
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
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly CampaignsConfig _config;
        #endregion

        #region Page Object Elements
        private readonly By _pageHeading =By.XPath("//h1[@class='heading-xlarge']");
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
            _config = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        public ManageApprenticeshipHomePage EmployerLogsIn()
        {
            SubmitLoginDetails(_config.EmployerUserName, _config.EmployerPassword);
            return new ManageApprenticeshipHomePage(_context);
        }

        private void SubmitLoginDetails(string username, string password)
        {
            _formCompletionHelper.EnterText(_emailAddressField, username);
            _formCompletionHelper.EnterText(_passwordField, password);
            _formCompletionHelper.ClickElement(_signInButton);
        }
    }
}