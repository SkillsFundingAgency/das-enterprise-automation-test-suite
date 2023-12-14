using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SettingsPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Settings";

        private static By UsernameField => By.CssSelector("#EmailAddress");
        private static By PasswordField => By.CssSelector("#Password");
        private static By SuccessfulMobileVerificationText => By.Id("SuccessMessageText");
        private static By DeleteYourAccountLink => By.LinkText("Delete your account");
        private static By DeleteAccountButton => By.Id("delete-account-button");
        private static By PhoneNumberField => By.Id("PhoneNumber");
        private static By Postcode_Address => By.Id("Address_Postcode");
        private static By ChangeEmailIdLink => By.Id("settings-change-username");
        private static By UpdateDetailsButton => By.Id("update-details-button");

        public void VerifySuccessfulVerificationText() => pageInteractionHelper.VerifyText(SuccessfulMobileVerificationText, faaDataHelper.SuccessfulPhoneVerificationText);

        public FAA_ConfirmAccountDeletionPage DeleteYourAccount()
        {
            var (username, password, _, _) = objectContext.GetFAALogin();
            formCompletionHelper.Click(DeleteYourAccountLink);
            formCompletionHelper.EnterText(UsernameField, username);
            formCompletionHelper.EnterText(PasswordField, password);
            formCompletionHelper.Click(DeleteAccountButton);
            return new FAA_ConfirmAccountDeletionPage(context);
        }

        public FAA_ChangeYourEmailAddressPage ChangeTheEmailIdSettings()
        {
            formCompletionHelper.EnterText(Postcode_Address, faaDataHelper.NewPostCode);
            formCompletionHelper.Click(UpdateDetailsButton);
            formCompletionHelper.Click(ChangeEmailIdLink);
            return new FAA_ChangeYourEmailAddressPage(context);
        }

        public FAA_PhoneNumberVerificationPage ChangePhoneNumberSettings()
        {
            formCompletionHelper.EnterText(PhoneNumberField, faaDataHelper.NewPhoneNumber);
            formCompletionHelper.Click(UpdateDetailsButton);
            return new FAA_PhoneNumberVerificationPage(context);
        }
    }
}
