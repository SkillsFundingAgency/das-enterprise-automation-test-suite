using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class CreatePasswordPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Create password";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly LoginInvitationsSqlDbHelper _loginInvitationsSqlDbHelper;
        #endregion

        private By Password => By.CssSelector("#Password");
        private By ConfirmPassword => By.CssSelector("#ConfirmPassword");

        private By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");

        public CreatePasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;

            _loginInvitationsSqlDbHelper = new LoginInvitationsSqlDbHelper(roatpConfig);

            VerifyPage(() =>
            {
                var invitationId = _loginInvitationsSqlDbHelper.GetId(applydataHelpers.CreateAccountEmail);

                context.Get<TabHelper>().OpenInNewTab(UrlConfig.RoatpApply_InvitationUrl, invitationId);

                return pageInteractionHelper.FindElements(PageHeader);

            }, PageTitle);

        }

        public SigUpCompletePage CreatePassword()
        {
            formCompletionHelper.EnterText(Password, applydataHelpers.Password);
            formCompletionHelper.EnterText(ConfirmPassword, applydataHelpers.Password);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
            return new SigUpCompletePage(_context);
        }
    }
}
