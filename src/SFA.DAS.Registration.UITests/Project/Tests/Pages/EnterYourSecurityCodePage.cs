using OpenQA.Selenium;
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

        public EnterYourSecurityCodePage(ScenarioContext context) : base(context) => VerifyPage();

        public AddAPAYESchemePage EnterSecurityCodeDetailsDuringAccountCreationJourney()
        {
            formCompletionHelper.EnterText(EnterYourSecurityCodeTextBox, config.RE_ConfirmCode);
            formCompletionHelper.EnterText(PasswordTextBox, registrationDataHelper.Password);
            Continue();
            return new AddAPAYESchemePage(_context);
        }
    }
}
