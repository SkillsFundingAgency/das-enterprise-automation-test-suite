using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages
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

        public SignInPage FailedLogin(EasAccountUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.IdOrUserRef);
            return this;
        }

        public string GetErrorFromSigninPage() => pageInteractionHelper.GetText(errorMsg).ToString();

        public MyAccountWithOutPayePage LoginToMyAccountWithOutPaye(EasAccountUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.IdOrUserRef);
            return new MyAccountWithOutPayePage(context);
        }

        public MyAccountTransferFundingPage GoToMyAccountTransferFundingPage(EasAccountUser loginUser)
        {
            EnterLoginDetailsAndClickSignIn(loginUser.Username, loginUser.IdOrUserRef);
            return new MyAccountTransferFundingPage(context);
        }

        public void EnterLoginDetailsAndClickSignIn(string userName, string password)
        {
            formCompletionHelper.EnterText(EmailAddressInput, userName);
            formCompletionHelper.EnterText(PasswordInput, password);
            formCompletionHelper.ClickElement(SignInButton);
        }
    }
}
