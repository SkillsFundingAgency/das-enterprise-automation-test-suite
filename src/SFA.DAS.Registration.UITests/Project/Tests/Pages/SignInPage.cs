using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignInPage : BasePage
    {
        protected override string PageTitle => "Sign in";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        #endregion

        private By CreateAnAccountLink => By.LinkText("create an account");

        private By EmailAddressInput => By.Id("EmailAddress");

        private By PasswordInput => By.Id("Password");

        private By SignInButton => By.Id("button-signin");

        private By ForgottenYourPasswordLink => By.LinkText("Forgotten your password?");

        private By BackLink => By.CssSelector(".link-back");

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetProjectConfig<ProjectConfig>();
            VerifyPage();
        }
        public RegisterPage CreateAnAccount()
        {
            _formCompletionHelper.ClickElement(CreateAnAccountLink);
            return new RegisterPage(_context);
        }

        public HomePage Login(LoginUser loginUser)
        {
             EnterEmailAddress(loginUser.Username)
            .EnterPassword(loginUser.Password)
            .SignIn();
            return new HomePage(_context);
        }

        private SignInPage EnterEmailAddress(string username)
        {
            _formCompletionHelper.EnterText(EmailAddressInput, username);
            return this;
        }

        private SignInPage EnterPassword(string password)
        {
            _formCompletionHelper.EnterText(PasswordInput, password);
            return this;
        }

        private void SignIn()
        {
            _formCompletionHelper.ClickElement(SignInButton);
        }

        private void ForgottenYourPassword()
        {
            _formCompletionHelper.ClickElement(ForgottenYourPasswordLink);
        }
    }
}
