using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ApprenticeCommitmentsBasePage : BasePage
    {

        #region Helpers and Context
        protected readonly ApprenticeLoginSqlDbHelper loginInvitationsSqlDbHelper;
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        #endregion

        public ApprenticeCommitmentsBasePage(ScenarioContext context) : base(context)
        {
            objectContext = context.Get<ObjectContext>();

            pageInteractionHelper = context.Get<PageInteractionHelper>();

            formCompletionHelper = context.Get<FormCompletionHelper>();

            loginInvitationsSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
        }
    }

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
