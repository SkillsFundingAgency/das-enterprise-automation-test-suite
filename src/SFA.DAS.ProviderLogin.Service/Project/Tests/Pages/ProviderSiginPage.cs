using OpenQA.Selenium;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderSiginPage : BasePage
    {
        protected override string PageTitle => "Sign in";

        protected override By PageHeader => By.CssSelector(".pageTitle");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderSiginPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By UsernameField => By.Id("username");
        private By PasswordField => By.Id("password");
        private By SignInButton => By.XPath("//button[@value='Log in']");

        public ProviderHomePage SubmitValidLoginDetails(ProviderLoginUser login)
        {
            EnterEmailAddress(login.Username)
            .EnterPassword(login.Password)
            .SignIn();
            return new ProviderHomePage(_context);
        }

        private ProviderSiginPage EnterEmailAddress(string username)
        {
            _formCompletionHelper.EnterText(UsernameField, username);
            return this;
        }

        private ProviderSiginPage EnterPassword(string password)
        {
            _formCompletionHelper.EnterText(PasswordField, password);
            return this;
        }

        private void SignIn()
        {
            _formCompletionHelper.ClickElement(SignInButton);
        }
    }
}
