using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class PasswordBasePage : ApprenticeCommitmentsBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected string _validPassword;
        #endregion

        protected override string PageTitle { get; }

        private By Password => By.CssSelector("#Password");
        private By ConfirmPassword => By.CssSelector("#ConfirmPassword");
        private By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");
        private By ErrorSummary => By.CssSelector(".govuk-error-summary");

        public PasswordBasePage(ScenarioContext context) : base(context)
        {
            _context = context;

            _validPassword = apprenticeCommitmentsConfig.AC_AccountPassword;
        }

        public PasswordBasePage InvalidPassword(string password, string confirmpassword)
        {
            SubmitPassword(password, confirmpassword);
            return this;
        }

        public void VerifyErrorSummary() => StringAssert.Contains("There is a problem", pageInteractionHelper.GetText(ErrorSummary), "Password error message did not match");

        protected void SubmitPassword(string password, string confirmpassword)
        {
            formCompletionHelper.EnterText(Password, password);
            formCompletionHelper.EnterText(ConfirmPassword, confirmpassword);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
        }
    }
}