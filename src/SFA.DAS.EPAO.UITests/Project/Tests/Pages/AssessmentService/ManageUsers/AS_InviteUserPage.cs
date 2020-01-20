using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers
{
    public class AS_InviteUserPage : BasePage
    {
        protected override string PageTitle => "Invite user";

        #region 
        private By GivenNameTextBox => By.Id("GivenName");
        private By FamilyNameTextBox => By.Id("FamilyName");
        private By EmailTextBox => By.Id("Email");
        private By ChangeOrganisationDetailsCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[0].Selected");
        private By ChangPipelineCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[1].Selected");
        private By ChangeCompletedAssessmentsCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[2].Selected");
        private By ChangeApplyForAStandardCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[3].Selected");
        private By ChangeManageUsersCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[4].Selected");
        private By ChangeRecordGradesCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[5].Selected");
        #endregion

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public AS_InviteUserPage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public string EnterUserDetailsAndSendInvite(EPAODataHelper dataHelper)
        {
            var newUserEmailId = dataHelper.GetRandomEmail;
            _formCompletionHelper.EnterText(GivenNameTextBox, "Test Given Name");
            _formCompletionHelper.EnterText(FamilyNameTextBox, "Test Family Name");
            _formCompletionHelper.EnterText(EmailTextBox, newUserEmailId);
            SelectAllPermissionCheckBoxes();
            Continue();
            return newUserEmailId;
        }

        private void SelectAllPermissionCheckBoxes()
        {
            _formCompletionHelper.SelectCheckbox(ChangeOrganisationDetailsCheckBox);
            _formCompletionHelper.SelectCheckbox(ChangPipelineCheckBox);
            _formCompletionHelper.SelectCheckbox(ChangeCompletedAssessmentsCheckBox);
            _formCompletionHelper.SelectCheckbox(ChangeApplyForAStandardCheckBox);
            _formCompletionHelper.SelectCheckbox(ChangeManageUsersCheckBox);
            _formCompletionHelper.SelectCheckbox(ChangeRecordGradesCheckBox);
        }
    }
}
