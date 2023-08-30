using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class CreatePasswordPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Create password";

        #region Helpers and Context
        private readonly LoginInvitationsSqlDbHelper _loginInvitationsSqlDbHelper;
        #endregion

        private static By Password => By.CssSelector("#Password");
        private static By ConfirmPassword => By.CssSelector("#ConfirmPassword");
        private static By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");

        public CreatePasswordPage(ScenarioContext context) : base(context)
        {
            _loginInvitationsSqlDbHelper = new LoginInvitationsSqlDbHelper(context.Get<DbConfig>());

            VerifyPage(() =>
            {
                var invitationId = _loginInvitationsSqlDbHelper.GetId(applyCreateUserDataHelpers.CreateAccountEmail);

                tabHelper.OpenInNewTab(UrlConfig.RoatpApply_InvitationUrl, invitationId);

                return pageInteractionHelper.FindElements(PageHeader);

            }, PageTitle);

        }

        public SigUpCompletePage CreatePassword(string pasword)
        {
            formCompletionHelper.EnterText(Password, pasword);
            formCompletionHelper.EnterText(ConfirmPassword, pasword);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
            return new SigUpCompletePage(context);
        }
    }
}
