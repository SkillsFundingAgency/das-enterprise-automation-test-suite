using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangeYourEmailAddressPage : RegistrationBasePage
    {
        protected override string PageTitle => "Change your email address";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.CssSelector(".button[type='submit']");
        private By NewEmailAddressTextBox => By.Id("NewEmailAddress");
        private By ReTypeEmailAddressTextBox => By.Id("ConfirmEmailAddress");
        #endregion

        public ChangeYourEmailAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EnterYourSecurityCodePage EnterNewEmailAddressDetailsAndContinue()
        {
            var newEmail = registrationDataHelper.AnotherRandomEmail;
            objectContext.SetRegisteredEmail(newEmail);

            formCompletionHelper.EnterText(NewEmailAddressTextBox, newEmail);
            formCompletionHelper.EnterText(ReTypeEmailAddressTextBox, newEmail);
            Continue();
            return new EnterYourSecurityCodePage(_context);
        }
    }
}