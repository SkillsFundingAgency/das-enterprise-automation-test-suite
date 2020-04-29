using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangeYourPasswordPage : RegistrationBasePage
    {
        protected override string PageTitle => "Change your password";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.CssSelector(".button[type='submit']");
        private By CurrentPasswordTextBox => By.Id("CurrentPassword");
        private By CreateNewPasswordTextBox => By.Id("NewPassword");
        private By ReTypePasswordTextBox => By.Id("ConfirmPassword");
        #endregion

        public ChangeYourPasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AddAPAYESchemePage ChangePasswordDuringAccountCreationJourney()
        {
            var newPassword = registrationDataHelper.NewPassword;
            formCompletionHelper.EnterText(CurrentPasswordTextBox, registrationDataHelper.Password);
            formCompletionHelper.EnterText(CreateNewPasswordTextBox, newPassword);
            formCompletionHelper.EnterText(ReTypePasswordTextBox, newPassword);
            Continue();
            return new AddAPAYESchemePage(_context);
        }
    }
}