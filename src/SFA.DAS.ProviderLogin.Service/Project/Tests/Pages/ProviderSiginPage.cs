using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderSiginPage : ProviderLoginBasePage
    {
        protected override string PageTitle => "Sign in";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => By.CssSelector(".pageTitle");

        public ProviderSiginPage(ScenarioContext context) : base(context) { }

        private By UsernameField => By.Id("username");
        private By PasswordField => By.Id("password");
        private By SignInButton => By.XPath("//button[@value='Log in']");

        public ProviderHomePage SubmitValidLoginDetails(ProviderLoginUser login)
        {
            EnterEmailAddress(login.UserId)
                    .EnterPassword(login.Password)
                    .SignIn();
            return new ProviderHomePage(context);
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
