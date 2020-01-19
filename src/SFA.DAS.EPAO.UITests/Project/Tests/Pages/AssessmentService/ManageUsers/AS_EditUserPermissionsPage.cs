using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_EditUserPermissionsPage : BasePage
    {
        protected override string PageTitle => "Edit user permissions";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Locators
        private By SaveButton => By.LinkText("Edit user permissions");
        private By ChangeOrganisationDetailsCheckBox => By.Id("PrivilegeViewModels[0].Selected");
        private By ChangPipelineCheckBox => By.Id("PrivilegeViewModels[1].Selected");
        private By ChangeCompletedAssessmentsCheckBox => By.Id("PrivilegeViewModels[2].Selected");
        private By ChangeApplyForAStandardCheckBox => By.Id("PrivilegeViewModels[3].Selected");
        private By ChangeManageUsersCheckBox => By.Id("PrivilegeViewModels[4].Selected");
        private By ChangeRecordGradesCheckBox => By.Id("PrivilegeViewModels[5].Selected");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public AS_EditUserPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public bool IsChangeOrganisationDetailsCheckBoxSelected() => _pageInteractionHelper.GetCheckboxStatus(ChangeOrganisationDetailsCheckBox);

        public AS_UserDetailsPage ClickSaveButton()
        {
            Continue();
            return new AS_UserDetailsPage(_context);
        }

        public AS_EditUserPermissionsPage UnSelectChangeOrganisationDetailsCheckBox()
        {
            _formCompletionHelper.UnSelectCheckbox(ChangeOrganisationDetailsCheckBox);
            return this;
        }

        public AS_EditUserPermissionsPage ClickOnAllPermissionCheckBoxes()
        {
            _formCompletionHelper.ClickWithoutRetryHelper(ChangeOrganisationDetailsCheckBox);
            _formCompletionHelper.ClickWithoutRetryHelper(ChangPipelineCheckBox);
            _formCompletionHelper.ClickWithoutRetryHelper(ChangeCompletedAssessmentsCheckBox);
            _formCompletionHelper.ClickWithoutRetryHelper(ChangeApplyForAStandardCheckBox);
            _formCompletionHelper.ClickWithoutRetryHelper(ChangeManageUsersCheckBox);
            _formCompletionHelper.ClickWithoutRetryHelper(ChangeRecordGradesCheckBox);
            return this;
        }
    }
}
