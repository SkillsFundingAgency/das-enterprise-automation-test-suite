using OpenQA.Selenium;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderSiginPage : ProviderLoginBasePage
    {
        protected override string PageTitle => "Sign in";

        protected override By PageHeader => By.CssSelector(".pageTitle");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderSiginPage(ScenarioContext context) : base(context) => _context = context;

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
            formCompletionHelper.EnterText(UsernameField, username);
            return this;
        }

        private ProviderSiginPage EnterPassword(string password)
        {
            formCompletionHelper.EnterText(PasswordField, password);
            return this;
        }

        private void SignIn() => formCompletionHelper.ClickElement(SignInButton);
    }
}
