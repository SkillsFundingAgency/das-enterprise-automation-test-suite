using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SignInPage : FAABasePage
    {
        protected override string PageTitle => "Sign in";

        private readonly IWebDriver _webDriver;
        private By UsernameField => By.CssSelector("#EmailAddress");
        private By PasswordField => By.CssSelector("#Password");
        private By SignInButton => By.CssSelector("#sign-in-button");
        private By CreateAnAccountLink => By.Id("create-account-link");
        private By ChangeSettingsInfo => By.Id("SuccessMessageText");
        

        public FAA_SignInPage(ScenarioContext context) : base(context, false)
        {
            VerifyPage(UsernameField);

            _webDriver = context.GetWebDriver();
            var environmentName = Configurator.EnvironmentName.ToLower() + ".";
            var currentURL = GetUrl();

            if (!currentURL.ToLower().Contains(environmentName))
            {
                var newURL = currentURL.Replace("www.", environmentName) + "?ReturnUrl=%2F";
                _webDriver.Navigate().GoToUrl(newURL);
                VerifyPage(UsernameField);
            }
        }

        public FAA_MyApplicationsHomePage SubmitValidLoginDetails(string emailId, string password)
        {
            FAASignIn(emailId, password);
            return new FAA_MyApplicationsHomePage(context);
        }

        public FAA_ActivateYourAccountPage SubmitUnactivatedLoginDetails(string emailId,string password)
        {
            FAASignIn(emailId, password);
            return new FAA_ActivateYourAccountPage(context);
        }

        private void FAASignIn(string emailId, string password)
        {
            formCompletionHelper.EnterText(UsernameField, emailId);
            formCompletionHelper.EnterText(PasswordField, password);
            formCompletionHelper.ClickElement(SignInButton);
        }

        public FAA_CreateAnAccountPage ClickCreateAnAccountLink()
        {
            formCompletionHelper.Click(CreateAnAccountLink);
            return new FAA_CreateAnAccountPage(context);
        }

        public void ConfirmAccountDeletion() => pageInteractionHelper.VerifyText(ChangeSettingsInfo, "Your account has been deleted"); 

        public void ConfirmEmailAddressUpdate() => pageInteractionHelper.VerifyText(ChangeSettingsInfo, "Your email address has been updated, please login using your new details.");
    }
}
