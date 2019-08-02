using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class SignInPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        #endregion

        private By CreateAnAccountLink => By.LinkText("create an account");

        private By EmailAddressInput => By.Id("EmailAddress");

        private By PasswordInput => By.Id("Password");

        private By SignInButton => By.Id("button-signin");

        private By ForgottenYourPasswordLink => By.LinkText("Forgotten your password?");

        private By BackLink => By.CssSelector(".link-back");

        protected override string PageTitle => "Sign in";

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetProjectSpecificConfig<ProjectSpecificConfig>();
            VerifyPage();
        }
        public RegisterPage CreateAnAccount()
        {
            _formCompletionHelper.ClickElement(CreateAnAccountLink);
            return new RegisterPage(_context);
        }

        public void Login()
        {
            EnterEmailAddress().
            EnterPassword().
            SignIn();
        }

        private SignInPage EnterEmailAddress()
        {
            _formCompletionHelper.EnterText(EmailAddressInput, _config.PP_AccountUserName);
            return this;
        }

        private SignInPage EnterPassword()
        {
            _formCompletionHelper.EnterText(PasswordInput, _config.PP_AccountPassword);
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
