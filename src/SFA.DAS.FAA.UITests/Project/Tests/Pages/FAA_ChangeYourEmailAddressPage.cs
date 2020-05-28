using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ChangeYourEmailAddressPage : FAABasePage
    {
        protected override string PageTitle => "Change your email address";

        private By EmailAddress => By.Id("EmailAddress");
        private By SendCodeButton => By.Id("btn-sendcode");
        private By SuccessMessageText => By.Id("SuccessMessageText");
        private By VerificationCode => By.Id("PendingUsernameCode");
        private By VerifyEmailButton => By.Id("verify-email-button");
        private By VerifyPassword => By.Id("VerifyPassword");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FAA_ChangeYourEmailAddressPage(ScenarioContext context) : base(context) => _context = context;

        public FAA_SignInPage ChangeEmailAddress()
        {
            formCompletionHelper.EnterText(EmailAddress, faadataHelper.ChangedEmailId);
            formCompletionHelper.Click(SendCodeButton);
            pageInteractionHelper.VerifyText(SuccessMessageText, "A verification code has been sent to your new email address.");
            formCompletionHelper.EnterText(VerificationCode, faadataHelper.ActivationCode);
            formCompletionHelper.EnterText(VerifyPassword, faadataHelper.Password);
            formCompletionHelper.Click(VerifyEmailButton);
            return new FAA_SignInPage(_context);
        }
    }
}
