using OpenQA.Selenium;
using SFA.DAS.TestDataCleanup;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourSecurityCodePage : RegistrationBasePage
    {
        protected override string PageTitle => "Enter your security code";
        
        #region Locators
        protected override By ContinueButton => By.CssSelector(".button[type='submit']");
        private By EnterYourSecurityCodeTextBox => By.Id("SecurityCode");
        private By PasswordTextBox => By.Id("Password");
        #endregion

        public EnterYourSecurityCodePage(ScenarioContext context, string email) : base(context)
        {
            VerifyPage();

            objectContext.SetDbNameToTearDown(CleanUpDbName.EasUsersTestDataCleanUp, email);
        }

        public AddAPAYESchemePage EnterSecurityCodeDetailsDuringAccountCreationJourney()
        {
            formCompletionHelper.EnterText(EnterYourSecurityCodeTextBox, config.RE_ConfirmCode);
            formCompletionHelper.EnterText(PasswordTextBox, registrationDataHelper.Password);
            Continue();
            return new AddAPAYESchemePage(context);
        }
    }
}
