using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class SignInPage : ConsolidatedSupportBasePage
    {
        protected override string PageTitle => "Sign in to Apprenticeship Service Support";

        protected override By PageHeader => By.CssSelector("#signin_title");

        private static By UserEmail => By.CssSelector("#user_email");
        private static By UserPassword => By.CssSelector("#user_password");
        private static By SignInButton => By.CssSelector("#sign-in-submit-button");

        public SignInPage(ScenarioContext context) : base(context) => VerifyPage();

        public HomePage SignIntoApprenticeshipServiceSupport()
        {
            formCompletionHelper.EnterText(UserEmail, config.Username);
            formCompletionHelper.EnterText(UserPassword, config.Password);
            formCompletionHelper.ClickElement(SignInButton);
            
            return new HomePage(context, true);
        }
    }
}
