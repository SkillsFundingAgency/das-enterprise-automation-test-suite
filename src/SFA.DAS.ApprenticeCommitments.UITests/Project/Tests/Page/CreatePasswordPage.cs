using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreatePasswordPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Create password";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly string _validPassword;
        #endregion

        private By Password => By.CssSelector("#Password");
        private By ConfirmPassword => By.CssSelector("#ConfirmPassword");
        private By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");
        private By ErrorSummary => By.CssSelector(".govuk-error-summary");

        public CreatePasswordPage(ScenarioContext context, string invitationId) : base(context)
        {
            _context = context;

            VerifyPage(() =>
            {
                invitationId = string.IsNullOrEmpty(invitationId) ? loginInvitationsSqlDbHelper.GetId(objectContext.GetApprenticeEmail()) : invitationId;

                context.Get<TabHelper>().OpenInNewTab(UrlConfig.Apprentice_InvitationUrl, invitationId);

                return pageInteractionHelper.FindElements(PageHeader);

            }, PageTitle);

            _validPassword = apprenticeCommitmentsConfig.AC_AccountPassword;

        }

        public SigUpCompletePage CreatePassword()
        {
            SubmitPassword(_validPassword, _validPassword);
            return new SigUpCompletePage(_context);
        }

        public CreatePasswordPage InvalidPassword()
        {
            SubmitPassword(_validPassword, "invalidpassword");
            return this;
        }

        public void VerifyErrorSummary() => StringAssert.Contains("There is a problem", pageInteractionHelper.GetText(ErrorSummary), "Password error message did not match");

        private void SubmitPassword(string password, string confirmpassword)
        {
            formCompletionHelper.EnterText(Password, password);
            formCompletionHelper.EnterText(ConfirmPassword, confirmpassword);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
        }
    }
}
