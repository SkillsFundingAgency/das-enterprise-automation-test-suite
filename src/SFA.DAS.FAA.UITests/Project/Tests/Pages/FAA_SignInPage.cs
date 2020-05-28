using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SignInPage : FAABasePage
    {
        protected override string PageTitle => "Sign in";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By UsernameField => By.CssSelector("#EmailAddress");

        private By PasswordField => By.CssSelector("#Password");

        private By SignInButton => By.CssSelector("#sign-in-button");

        private By CreateAnAccountLink => By.Id("create-account-link");

        private By ChangeSettingsInfo => By.Id("SuccessMessageText");
        

        public FAA_SignInPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            VerifyPage(UsernameField);
        }

        public FAA_MyApplicationsHomePage SubmitValidLoginDetails(string emailId, string password)
        {
            FAASignIn(emailId, password);
            return new FAA_MyApplicationsHomePage(_context);
        }

        public FAA_ActivateYourAccountPage SubmitUnactivatedLoginDetails(string emailId,string password)
        {
            FAASignIn(emailId, password);
            return new FAA_ActivateYourAccountPage(_context);
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
            return new FAA_CreateAnAccountPage(_context);
        }

        public void ConfirmAccountDeletion() => pageInteractionHelper.VerifyText(ChangeSettingsInfo, "Your account has been deleted"); 

        public void ConfirmEmailAddressUpdate() => pageInteractionHelper.VerifyText(ChangeSettingsInfo, "Your email address has been updated, please login using your new details.");
    }
}
