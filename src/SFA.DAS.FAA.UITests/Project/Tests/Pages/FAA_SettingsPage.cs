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

        public void VerifySuccessfulVerificationText() => _pageInteractionHelper.VerifyText(SuccessfulMobileVerificationText, _faadataHelper.SuccessfulPhoneVerificationText);

        public FAA_ConfirmAccountDeletionPage DeleteYourAccount()
        {
            var (username, password, _ , _) = _objectContext.GetFAALogin();
            _formCompletionHelper.Click(DeleteYourAccountLink);
            _formCompletionHelper.EnterText(UsernameField, username);
            _formCompletionHelper.EnterText(PasswordField, password);
            _formCompletionHelper.Click(DeleteAccountButton);
            return new FAA_ConfirmAccountDeletionPage(_context);
        }

        public FAA_ChangeYourEmailAddressPage ChangeTheEmailIdSettings()
        {
            _formCompletionHelper.EnterText(Postcode_Address, _faadataHelper.NewPostCode);
            _formCompletionHelper.Click(UpdateDetailsButton);
            _formCompletionHelper.Click(ChangeEmailIdLink);
            return new FAA_ChangeYourEmailAddressPage(_context);
        }

        public FAA_PhoneNumberVerificationPage ChangePhoneNumberSettings()
        {
            _formCompletionHelper.EnterText(PhoneNumberField, _faadataHelper.NewPhoneNumber);
            _formCompletionHelper.Click(UpdateDetailsButton);
            return new FAA_PhoneNumberVerificationPage(_context);
        }
    }
}
