using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SetPermissionsPage : BasePage
    {
        protected override string PageTitle => "Set permissions";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By SetCreateCohortPermissionsOptions => By.CssSelector(".govuk-radios__label");
        private By SetPermissionsButton => By.CssSelector(".govuk-button");

        public SetPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ConfirmTrainingProviderPermissionsPage SetCreateCohortPermissions()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(SetCreateCohortPermissionsOptions, "operation-0-yes");
            _formCompletionHelper.ClickElement(SetPermissionsButton);
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }

        internal ConfirmTrainingProviderPermissionsPage UnSetCreateCohortPermissions()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(SetCreateCohortPermissionsOptions, "operation-0-no");
            _formCompletionHelper.ClickElement(SetPermissionsButton);
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }
    }
}

