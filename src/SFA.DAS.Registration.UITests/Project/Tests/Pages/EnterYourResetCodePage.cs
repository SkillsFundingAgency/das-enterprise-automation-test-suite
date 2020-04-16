using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourResetCodePage : RegistrationBasePage
    {
        protected override string PageTitle => "Enter your reset code";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.CssSelector(".button[type='submit']");
        private By EnterCodeTextBox => By.Id("PasswordResetCode");
        private By CreateNewPasswordTextBox => By.Id("Password");
        private By ConfirmPasswordTextBox => By.Id("ConfirmPassword");
        #endregion

        public EnterYourResetCodePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HomePage ResetPassword()
        {
            var newPassword = registrationDataHelper.NewPassword;
            formCompletionHelper.EnterText(EnterCodeTextBox, config.RE_ConfirmCode);
            formCompletionHelper.EnterText(CreateNewPasswordTextBox, newPassword);
            formCompletionHelper.EnterText(ConfirmPasswordTextBox, newPassword);
            Continue();
            return new HomePage(_context);
        }
    }
}
