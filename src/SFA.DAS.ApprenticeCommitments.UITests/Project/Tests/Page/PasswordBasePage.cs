using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class PasswordBasePage : ApprenticeCommitmentsBasePage
    {
        protected string _validPassword;
        protected override string PageTitle { get; }

        private By Password => By.CssSelector("#Password");
        private By ConfirmPassword => By.CssSelector("#ConfirmPassword");
        private By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");
        private By ErrorSummary => By.CssSelector(".govuk-error-summary");

        public PasswordBasePage(ScenarioContext context) : base(context) => _validPassword = apprenticeCommitmentsConfig.AC_AccountPassword;

        public string InvalidPassword(string password, string confirmpassword)
        {
            SubmitPassword(password, confirmpassword);
            return pageInteractionHelper.GetText(ErrorSummary);
        }

        protected void SubmitPassword(string password, string confirmpassword)
        {
            formCompletionHelper.EnterText(Password, password);
            formCompletionHelper.EnterText(ConfirmPassword, confirmpassword);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
        }
    }
}