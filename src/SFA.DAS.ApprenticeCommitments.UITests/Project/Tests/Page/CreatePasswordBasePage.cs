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
        private By ErrorSummary => By.CssSelector(".govuk-error-summary");
        protected override By ServiceHeader => NonClickableServiceHeader;

        public CreatePasswordBasePage(ScenarioContext context) : base(context) => _validPassword = apprenticeCommitmentsConfig.AC_AccountPassword;

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