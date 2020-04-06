using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SignInPage : BasePage
    {
        protected override string PageTitle => "Sign in";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly FAAConfig _config;
        private readonly FAADataHelper _dataHelper;
        private readonly PageInteractionHelper _PageInteractionhelper;
        #endregion

        private By UsernameField => By.CssSelector("#EmailAddress");

        private By PasswordField => By.CssSelector("#Password");

        private By SignInButton => By.CssSelector("#sign-in-button");

        private By CreateAnAccountLink => By.Id("create-account-link");

        private By ChangeSettingsInfo => By.Id("SuccessMessageText");
        

        public FAA_SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetFAAConfig<FAAConfig>();
            _dataHelper = context.Get<FAADataHelper>();
            _PageInteractionhelper = context.Get<PageInteractionHelper>();
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
            _formCompletionHelper.EnterText(UsernameField, emailId);
            _formCompletionHelper.EnterText(PasswordField, password);
            _formCompletionHelper.ClickElement(SignInButton);
        }

        public FAA_CreateAnAccountPage ClickCreateAnAccountLink()
        {
            _formCompletionHelper.Click(CreateAnAccountLink);
            return new FAA_CreateAnAccountPage(_context);
        }

        public void ConfirmAccountDeletion()
        {
            _PageInteractionhelper.VerifyText(ChangeSettingsInfo, "Your account has been deleted"); 
        }

        public void ConfirmEmailAddressUpdate()
        {
            _PageInteractionhelper.VerifyText(ChangeSettingsInfo, "Your email address has been updated, please login using your new details.");
        }
    }
}
