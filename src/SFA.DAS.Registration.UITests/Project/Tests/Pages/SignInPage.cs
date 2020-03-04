using OpenQA.Selenium;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignInPage : RegistrationBasePage
    {
        protected override string PageTitle => "Sign in";
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailAddressInput => By.Id("EmailAddress");
        private By PasswordInput => By.Id("Password");
        private By SignInButton => By.Id("button-signin");
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HomePage Login(LoginUser loginUser)
        {
            SignIn(loginUser);
            return new HomePage(_context);
        }

        public YourAccountsPage MultipleAccountLogin(LoginUser loginUser)
        {
            SignIn(loginUser);
            return new YourAccountsPage(_context);
        }

        private void SignIn(LoginUser loginUser)
        {
            formCompletionHelper.EnterText(EmailAddressInput, loginUser.Username);
            formCompletionHelper.EnterText(PasswordInput, loginUser.Password);
            formCompletionHelper.ClickElement(SignInButton);
        }
    }
}
