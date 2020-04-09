using OpenQA.Selenium;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignInPage : BasePage
    {
        protected override string PageTitle => "Sign in";

        protected readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailAddressInput => By.Id("EmailAddress");
        private By PasswordInput => By.Id("Password");
        private By SignInButton => By.Id("button-signin");
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public HomePage Login(LoginUser loginUser)
        {
            SignIn(loginUser);
            return new HomePage(_context);
        }

        public MyAccountWithOutPayePage LoginToMyAccountWithOutPaye(LoginUser loginUser)
        {
            SignIn(loginUser);
            return new MyAccountWithOutPayePage(_context);
        }

        public YourAccountsPage MultipleAccountLogin(LoginUser loginUser)
        {
            SignIn(loginUser);
            return new YourAccountsPage(_context);
        }

        private void SignIn(LoginUser loginUser)
        {
            _formCompletionHelper.EnterText(EmailAddressInput, loginUser.Username);
            _formCompletionHelper.EnterText(PasswordInput, loginUser.Password);
            _formCompletionHelper.ClickElement(SignInButton);
        }
    }
}
