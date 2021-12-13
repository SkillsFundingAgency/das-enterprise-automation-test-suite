using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ResetYourPasswordPage : RegistrationBasePage
    {
        protected override string PageTitle => "Reset your password";
        
        #region Locators
        protected override By ContinueButton => By.Id("forgottenpassword-button");
        private By EmailTextBox => By.Id("Email");
        #endregion

        public ResetYourPasswordPage(ScenarioContext context) : base(context) => VerifyPage();

        public EnterYourResetCodePage EnterEmailToBeReset()
        {
            formCompletionHelper.EnterText(EmailTextBox, objectContext.GetRegisteredEmail());
            Continue();
            return new EnterYourResetCodePage(context);
        }
    }
}
