using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignInPage : VerifyBasePage
    {
        protected override string PageTitle => "Sign in";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private By EmailAddressInput => By.Id("EmailAddress");
        private By PasswordInput => By.Id("Password");
        private By SignInButton => By.Id("button-signin");
        private By HeaderInformationMessage => By.CssSelector(".bold-large");
        private By ForgottenYourPasswordLink => By.LinkText("Forgotten your password?");
        private By errorMsg => By.ClassName("danger");
        #endregion

        public SignInPage(ScenarioContext context) : base(context) => VerifyPage();

        public HomePage Login(LoginUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.Password);
            return new HomePage(context);
        }

        public SignInPage FailedLogin(LoginUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.Password);
            return this;
        }

        public string GetErrorFromSigninPage()
        {
            return pageInteractionHelper.GetText(errorMsg).ToString();
        }


        public ConfirmYourIdentityPage LoginWithUnActivatedAccount(string userName, string password)
        {
            EnterLoginDetailsAndClickSignIn(userName, password);
            return new ConfirmYourIdentityPage(context, userName, password);
        }

        public MyAccountWithOutPayePage LoginToMyAccountWithOutPaye(LoginUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.Password);
            return new MyAccountWithOutPayePage(context);
        }

        public YourAccountsPage MultipleAccountLogin(LoginUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.Password);
            return new YourAccountsPage(context);
        }

        public MyAccountTransferFundingPage GoToMyAccountTransferFundingPage(LoginUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.Password);
            return new MyAccountTransferFundingPage(context);
        }

        public void EnterLoginDetailsAndClickSignIn(string userName, string password)
        {
            formCompletionHelper.EnterText(EmailAddressInput, userName);
            formCompletionHelper.EnterText(PasswordInput, password);
            formCompletionHelper.ClickElement(SignInButton);
        }

        public SignInPage CheckHeaderInformationMessageOnSignInPage(string info)
        {
            VerifyElement(HeaderInformationMessage, info);
            return this;
        }

        public PasswordResetCodePage ClickForgottenYourPasswordLink()
        {
            formCompletionHelper.Click(ForgottenYourPasswordLink);
            return new PasswordResetCodePage(context);
        }

        public AddAPAYESchemePage LoginWithResetPassword(string userName, string password)
        {
            EnterLoginDetailsAndClickSignIn(userName,password);
            return new AddAPAYESchemePage(context);
        }
    }
}
