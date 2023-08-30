using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SignInPage : FAABasePage
    {
        protected override string PageTitle => "Sign in";

        private static By UsernameField => By.CssSelector("#EmailAddress");
        private static By PasswordField => By.CssSelector("#Password");
        private static By SignInButton => By.CssSelector("#sign-in-button");
        private static By CreateAnAccountLink => By.Id("create-account-link");
        private static By ChangeSettingsInfo => By.Id("SuccessMessageText");


        public FAA_SignInPage(ScenarioContext context) : base(context, false)
        {
            VerifyPage(UsernameField);

            var environmentName = EnvironmentName.ToLower() + ".";

            var currentURL = GetUrl();

            if (!currentURL.ToLower().Contains(environmentName))
            {
                var newURL = currentURL.Replace("www.", environmentName) + "?ReturnUrl=%2F";

                tabHelper.GoToUrl(newURL);

                VerifyPage(UsernameField);
            }
        }

        public FAA_MyApplicationsHomePage SubmitValidLoginDetails(string emailId, string password)
        {
            FAASignIn(emailId, password);
            return new FAA_MyApplicationsHomePage(context);
        }

        public FAA_ActivateYourAccountPage SubmitUnactivatedLoginDetails(string emailId, string password)
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
