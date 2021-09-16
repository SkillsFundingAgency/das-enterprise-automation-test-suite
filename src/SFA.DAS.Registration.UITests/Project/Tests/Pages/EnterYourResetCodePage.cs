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
        #endregion

        public EnterYourResetCodePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }


        public ChangePasswordPage ResetPasswordDuringAccountCreation()
        {
            formCompletionHelper.EnterText(EnterCodeTextBox, config.RE_ConfirmCode);
            Continue();
            return new ChangePasswordPage(_context);
        }
    }
}
