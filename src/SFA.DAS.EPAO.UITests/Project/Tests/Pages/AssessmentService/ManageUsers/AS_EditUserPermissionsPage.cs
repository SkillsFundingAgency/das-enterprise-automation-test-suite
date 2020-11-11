using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Linq;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_EditUserPermissionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Edit user permissions";
        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");
        private readonly ScenarioContext _context;

        #region Locators
        private By ChangeOrganisationDetailsCheckBox => By.Id(Getid("Change organisation details"));
        private By ChangPipelineCheckBox => By.Id(Getid("Pipeline"));
        private By ChangeCompletedAssessmentsCheckBox => By.Id(Getid("Completed assessments"));
        private By ChangeApplyForAStandardCheckBox => By.Id(Getid("Apply for a Standard"));
        private By ChangeManageUsersCheckBox => By.Id(Getid("Manage users"));
        private By ChangeRecordGradesCheckBox => By.Id(Getid("Record grades and issue certificates"));
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

        private string Getid(string labeltext) => pageInteractionHelper.FindElements(CheckBoxLabels).ToList().SingleOrDefault(x => x?.Text == labeltext).GetAttribute("for");
    }
}
