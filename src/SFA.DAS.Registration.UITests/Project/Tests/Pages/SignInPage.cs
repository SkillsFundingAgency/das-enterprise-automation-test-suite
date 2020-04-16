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
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;

        #region Locators
        private By EmailAddressInput => By.Id("EmailAddress");
        private By PasswordInput => By.Id("Password");
        private By SignInButton => By.Id("button-signin");
        private By HeaderInformationMessage => By.CssSelector(".bold-large");
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public HomePage Login(LoginUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.Password);
            return new HomePage(_context);
        }

        public MyAccountWithOutPayePage LoginToMyAccountWithOutPaye(LoginUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.Password);
            return new MyAccountWithOutPayePage(_context);
        }

        public YourAccountsPage MultipleAccountLogin(LoginUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.Password);
            return new YourAccountsPage(_context);
        }

        public void EnterLoginDetailsAndClickSignIn(string userName, string password)
        {
            _formCompletionHelper.EnterText(EmailAddressInput, userName);
            _formCompletionHelper.EnterText(PasswordInput, password);
            _formCompletionHelper.ClickElement(SignInButton);
        }

        public SignInPage CheckHeaderInformationMessageOnSignInPage(string info)
        {
            VerifyPage(HeaderInformationMessage, info);
            return this;
        }
    }
}
