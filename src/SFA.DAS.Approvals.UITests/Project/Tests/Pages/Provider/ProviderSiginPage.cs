using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderSiginPage : BasePage
    {
        protected override string PageTitle => "Sign in";

        protected override By PageHeader => By.CssSelector(".pageTitle");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        public ProviderSiginPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By UsernameField => By.Id("username");
        private By PasswordField => By.Id("password");
        private By SignInButton => By.XPath("//button[@value='Log in']");

        internal ProviderHomePage SubmitValidLoginDetails()
        {
            EnterEmailAddress()
            .EnterPassword()
            .SignIn();
            return new ProviderHomePage(_context);
        }

        private ProviderSiginPage EnterEmailAddress()
        {
            _formCompletionHelper.EnterText(UsernameField, _config.AP_ProviderLoginId);
            return this;
        }

        private ProviderSiginPage EnterPassword()
        {
            _formCompletionHelper.EnterText(PasswordField, _config.AP_ProviderLoginPassword);
            return this;
        }

        private void SignIn()
        {
            _formCompletionHelper.ClickElement(SignInButton);
        }
    }
}
