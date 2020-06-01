using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SettingsPage : FAABasePage
    {
        protected override string PageTitle => "Settings";

        private By UsernameField => By.CssSelector("#EmailAddress");
        private By PasswordField => By.CssSelector("#Password");
        private By SuccessfulMobileVerificationText => By.Id("SuccessMessageText");
        private By DeleteYourAccountLink => By.LinkText("Delete your account");
        private By DeleteAccountButton => By.Id("delete-account-button");
        private By PhoneNumberField => By.Id("PhoneNumber");
        private By Postcode_Address => By.Id("Address_Postcode");
        private By ChangeEmailIdLink => By.Id("settings-change-username");
        private By UpdateDetailsButton => By.Id("update-details-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
    
        public FAA_SettingsPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySuccessfulVerificationText() => pageInteractionHelper.VerifyText(SuccessfulMobileVerificationText, faadataHelper.SuccessfulPhoneVerificationText);

        public FAA_ConfirmAccountDeletionPage DeleteYourAccount()
        {
            var (username, password, _ , _) = objectContext.GetFAALogin();
            formCompletionHelper.Click(DeleteYourAccountLink);
            formCompletionHelper.EnterText(UsernameField, username);
            formCompletionHelper.EnterText(PasswordField, password);
            formCompletionHelper.Click(DeleteAccountButton);
            return new FAA_ConfirmAccountDeletionPage(_context);
        }

        public FAA_ChangeYourEmailAddressPage ChangeTheEmailIdSettings()
        {
            formCompletionHelper.EnterText(Postcode_Address, faadataHelper.NewPostCode);
            formCompletionHelper.Click(UpdateDetailsButton);
            formCompletionHelper.Click(ChangeEmailIdLink);
            return new FAA_ChangeYourEmailAddressPage(_context);
        }

        public FAA_PhoneNumberVerificationPage ChangePhoneNumberSettings()
        {
            formCompletionHelper.EnterText(PhoneNumberField, faadataHelper.NewPhoneNumber);
            formCompletionHelper.Click(UpdateDetailsButton);
            return new FAA_PhoneNumberVerificationPage(_context);
        }
    }
}
