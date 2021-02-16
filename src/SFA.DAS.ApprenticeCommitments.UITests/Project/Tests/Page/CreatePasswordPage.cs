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
        #endregion

        private By Password => By.CssSelector("#Password");
        private By ConfirmPassword => By.CssSelector("#ConfirmPassword");

        private By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");

        public CreatePasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;

            VerifyPage(() =>
            {
                var invitationId = loginInvitationsSqlDbHelper.GetId(objectContext.GetApprenticeEmail());

                context.Get<TabHelper>().OpenInNewTab(UrlConfig.Apprentice_InvitationUrl, invitationId);

                return pageInteractionHelper.FindElements(PageHeader);

            }, PageTitle);

        }

        public SigUpCompletePage CreatePassword(string pasword)
        {
            formCompletionHelper.EnterText(Password, pasword);
            formCompletionHelper.EnterText(ConfirmPassword, pasword);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
            return new SigUpCompletePage(_context);
        }
    }
}
