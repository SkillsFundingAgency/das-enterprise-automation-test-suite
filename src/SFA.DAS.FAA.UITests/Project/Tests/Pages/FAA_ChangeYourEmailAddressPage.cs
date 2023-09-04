using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ChangeYourEmailAddressPage : FAABasePage
    {
        protected override string PageTitle => "Change your email address";

        private static By EmailAddress => By.Id("EmailAddress");
        private static By SendCodeButton => By.Id("btn-sendcode");
        private static By SuccessMessageText => By.Id("SuccessMessageText");
        private static By VerificationCode => By.Id("PendingUsernameCode");
        private static By VerifyEmailButton => By.Id("verify-email-button");
        private static By VerifyPassword => By.Id("VerifyPassword");

        public FAA_ChangeYourEmailAddressPage(ScenarioContext context) : base(context) { }

        public FAA_SignInPage ChangeEmailAddress()
        {
            formCompletionHelper.EnterText(EmailAddress, faaDataHelper.ChangedEmailId);
            formCompletionHelper.Click(SendCodeButton);
            pageInteractionHelper.VerifyText(SuccessMessageText, "A verification code has been sent to your new email address.");
            formCompletionHelper.EnterText(VerificationCode, faaDataHelper.ActivationCode);
            formCompletionHelper.EnterText(VerifyPassword, faaDataHelper.Password);
            formCompletionHelper.Click(VerifyEmailButton);
            return new FAA_SignInPage(context);
        }
    }
}
