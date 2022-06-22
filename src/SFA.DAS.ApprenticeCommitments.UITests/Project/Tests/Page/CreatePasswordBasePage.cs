using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class CreatePasswordBasePage : ApprenticeCommitmentsBasePage
    {
        protected string validPassword;
        protected override string PageTitle { get; }
        protected override By ServiceHeader => NonClickableServiceHeader;
        private By PasswordError => By.XPath("(//ul[@class='govuk-list govuk-error-summary__list']/li)[1]");
        protected By ConfirmPassword => By.CssSelector("#ConfirmPassword");

        public CreatePasswordBasePage(ScenarioContext context) : base(context)
        {
            validPassword = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>().AC_AccountPassword; 
        }

        public void EnterMismatchedPasswordsOnCreateLoginDetailsPage(string password)
        {
            SubmitPassword(password, password + 1);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Save and continue");
        }

        public void EnterMismatchedPasswordsOnResetPasswordPage(string password) => SubmitPassword(password, password + 1, true);

        public void VerifyMismatchPasswordErrorOnCreateLoginDetailsPage() => pageInteractionHelper.VerifyText(PasswordError, "Enter the same password");

        public void VerifyMismatchPasswordErrorOnPasswordResetPage() => pageInteractionHelper.VerifyText(PasswordError, "Passwords should match");

        protected void SubmitPassword(string password, string confirmpassword, bool clickSubmit = false)
        {
            formCompletionHelper.EnterText(Password, password);
            formCompletionHelper.EnterText(ConfirmPassword, confirmpassword);
            
            if (clickSubmit)
                formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
        }
    }
}