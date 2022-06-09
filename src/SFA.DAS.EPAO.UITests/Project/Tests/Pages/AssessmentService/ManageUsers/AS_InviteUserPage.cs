namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;

public class AS_InviteUserPage : EPAO_BasePage
{
    protected override string PageTitle => "Invite user";

    #region Locators
    private static By GivenNameTextBox => By.Id("GivenName");
    private static By FamilyNameTextBox => By.Id("FamilyName");
    private static By EmailTextBox => By.Id("Email");
    private static By ChangeOrganisationDetailsCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[0].Selected");
    private static By ChangPipelineCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[1].Selected");
    private static By ChangeCompletedAssessmentsCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[2].Selected");
    private static By ChangeApplyForAStandardCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[3].Selected");
    private static By ChangeManageUsersCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[4].Selected");
    private static By ChangeRecordGradesCheckBox => By.Id("PrivilegesViewModel.PrivilegeViewModels[5].Selected");
    #endregion

    public AS_InviteUserPage(ScenarioContext context) : base(context) => VerifyPage();

    public string EnterUserDetailsAndSendInvite()
    {
        var newUserEmailId = ePAOAssesmentServiceDataHelper.RandomEmail;
        formCompletionHelper.EnterText(GivenNameTextBox, "Test Given Name");
        formCompletionHelper.EnterText(FamilyNameTextBox, "Test Family Name");
        formCompletionHelper.EnterText(EmailTextBox, newUserEmailId);
        SelectAllPermissionCheckBoxes();
        Continue();
        return newUserEmailId;
    }

    private void SelectAllPermissionCheckBoxes()
    {
        formCompletionHelper.SelectCheckbox(ChangeOrganisationDetailsCheckBox);
        formCompletionHelper.SelectCheckbox(ChangPipelineCheckBox);
        formCompletionHelper.SelectCheckbox(ChangeCompletedAssessmentsCheckBox);
        formCompletionHelper.SelectCheckbox(ChangeApplyForAStandardCheckBox);
        formCompletionHelper.SelectCheckbox(ChangeManageUsersCheckBox);
        formCompletionHelper.SelectCheckbox(ChangeRecordGradesCheckBox);
    }
}
