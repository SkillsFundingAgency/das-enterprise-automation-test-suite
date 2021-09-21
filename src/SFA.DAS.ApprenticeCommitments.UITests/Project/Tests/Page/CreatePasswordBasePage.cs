using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class CreatePasswordBasePage : ApprenticeCommitmentsBasePage
    {
        protected string _validPassword, email;
        protected override string PageTitle { get; }

        protected By Password => By.CssSelector("#Password");
        protected By ConfirmPassword => By.CssSelector("#ConfirmPassword");
        protected By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");
        protected override By ServiceHeader => NonClickableServiceHeader;
        private By ErrorSummaryTitle => By.Id("error-summary-title");
        private By PasswordError1 => By.XPath("(//ul[@class='govuk-list govuk-error-summary__list']/li)[1]");
        private By PasswordError2 => By.XPath("(//ul[@class='govuk-list govuk-error-summary__list']/li)[2]");

        public CreatePasswordBasePage(ScenarioContext context) : base(context) => _validPassword = apprenticeCommitmentsConfig.AC_AccountPassword;

        public void EnterMismatchedPasswordsOnCreateLoginDetailsPage(string password)
        {
            SubmitPassword(password, password + 1);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Save and continue");
        }

        public void EnterMismatchedPasswordsOnResetPasswordPage(string password)
        {
            SubmitPassword(password, password + 1);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
        }

        public void VerifyErrorSummaryTitle() => pageInteractionHelper.VerifyText(ErrorSummaryTitle, "There is a problem");

        public void VerifyMismatchPasswordErrorOnCreateLoginDetailsPage() => pageInteractionHelper.VerifyText(PasswordError1, "Enter the same password");

        public void VerifyMismatchPasswordErrorOnPasswordResetPage() => pageInteractionHelper.VerifyText(PasswordError1, "Passwords should match");

        public void VerifyBlankPasswordError() => pageInteractionHelper.VerifyText(PasswordError1, "Enter a password");

        public void VerifyBlankReTypePasswordError() => pageInteractionHelper.VerifyText(PasswordError2, "Re-enter the password");

        protected void SubmitPassword(string password, string confirmpassword)
        {
            formCompletionHelper.EnterText(Password, password);
            formCompletionHelper.EnterText(ConfirmPassword, confirmpassword);
        }
    }
}