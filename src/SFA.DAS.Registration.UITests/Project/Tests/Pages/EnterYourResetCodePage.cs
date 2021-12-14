using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourResetCodePage : RegistrationBasePage
    {
        protected override string PageTitle => "Enter your reset code";
        
        #region Locators
        protected override By ContinueButton => By.CssSelector(".button[type='submit']");
        private By EnterCodeTextBox => By.Id("PasswordResetCode");
        #endregion

        public EnterYourResetCodePage(ScenarioContext context) : base(context) => VerifyPage();

        public ChangePasswordPage EnterConfirmationCode()
        {
            formCompletionHelper.EnterText(EnterCodeTextBox, config.RE_ConfirmCode);
            Continue();
            return new ChangePasswordPage(context);
        }
    }
}
