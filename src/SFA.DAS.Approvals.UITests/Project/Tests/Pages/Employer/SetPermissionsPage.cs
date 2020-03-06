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
            return AddApprenticeRecordsPermissions(true)
                   .Update();
        }

        internal ConfirmTrainingProviderPermissionsPage UnSetCreateCohortPermissions()
        {
            return AddApprenticeRecordsPermissions(false)
                   .Update();
        }

        internal ConfirmTrainingProviderPermissionsPage UnSetCreateCohortAndRecruitmentPermissions()
        {
            return AddApprenticeRecordsPermissions(false)
                   .RecruitApprenticesPermissions(false)
                   .Update();
        }
        internal ConfirmTrainingProviderPermissionsPage SetRecruitmentPermissions()
        {
            return RecruitApprenticesPermissions(true)
                   .Update();
        }

        internal ConfirmTrainingProviderPermissionsPage UnSetRecruitmentPermissions()
        {
            return RecruitApprenticesPermissions(false)
                   .Update();
        }

        private SetPermissionsPage AddApprenticeRecordsPermissions(bool set)
        {
            SelectRadioOptionByForAttribute(set ? "operation-0-yes": "operation-0-no");
            return this;
        }

        private SetPermissionsPage RecruitApprenticesPermissions(bool set)
        {
            SelectRadioOptionByForAttribute(set ? "operation-1-yes" : "operation-1-no");
            return this;
        }

        private ConfirmTrainingProviderPermissionsPage Update()
        {
            _formCompletionHelper.ClickElement(SetPermissionsButton);
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }
    }
}

