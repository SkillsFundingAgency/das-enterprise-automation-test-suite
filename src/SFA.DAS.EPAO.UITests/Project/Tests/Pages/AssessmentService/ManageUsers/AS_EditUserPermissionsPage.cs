using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_EditUserPermissionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Edit user permissions";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");
        private readonly ScenarioContext _context;

        #region Locators
        private By SaveButton => By.LinkText("Edit user permissions");
        private By ChangeOrganisationDetailsCheckBox => By.Id("PrivilegeViewModels[1].Selected");
        private By ChangPipelineCheckBox => By.Id("PrivilegeViewModels[5].Selected");
        private By ChangeCompletedAssessmentsCheckBox => By.Id("PrivilegeViewModels[3].Selected");
        private By ChangeApplyForAStandardCheckBox => By.Id("PrivilegeViewModels[0].Selected");
        private By ChangeManageUsersCheckBox => By.Id("PrivilegeViewModels[4].Selected");
        private By ChangeRecordGradesCheckBox => By.Id("PrivilegeViewModels[2].Selected");
        #endregion

        public AS_EditUserPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public bool IsChangeOrganisationDetailsCheckBoxSelected() => pageInteractionHelper.GetElementSelectedStatus(ChangeOrganisationDetailsCheckBox);

        public AS_UserDetailsPage ClickSaveButton()
        {
            Continue();
            return new AS_UserDetailsPage(_context);
        }

        public AS_EditUserPermissionsPage UnSelectChangeOrganisationDetailsCheckBox()
        {
            formCompletionHelper.UnSelectCheckbox(ChangeOrganisationDetailsCheckBox);
            return this;
        }

        public AS_EditUserPermissionsPage SelectAllPermissionCheckBoxes()
        {
            formCompletionHelper.SelectCheckbox(ChangeOrganisationDetailsCheckBox);
            formCompletionHelper.SelectCheckbox(ChangPipelineCheckBox);
            formCompletionHelper.SelectCheckbox(ChangeCompletedAssessmentsCheckBox);
            formCompletionHelper.SelectCheckbox(ChangeApplyForAStandardCheckBox);
            formCompletionHelper.SelectCheckbox(ChangeManageUsersCheckBox);
            formCompletionHelper.SelectCheckbox(ChangeRecordGradesCheckBox);
            return this;
        }

        public AS_EditUserPermissionsPage UnSelectAllPermissionCheckBoxes()
        {
            formCompletionHelper.UnSelectCheckbox(ChangeOrganisationDetailsCheckBox);
            formCompletionHelper.UnSelectCheckbox(ChangPipelineCheckBox);
            formCompletionHelper.UnSelectCheckbox(ChangeCompletedAssessmentsCheckBox);
            formCompletionHelper.UnSelectCheckbox(ChangeApplyForAStandardCheckBox);
            formCompletionHelper.UnSelectCheckbox(ChangeManageUsersCheckBox);
            formCompletionHelper.UnSelectCheckbox(ChangeRecordGradesCheckBox);
            return this;
        }
    }
}
