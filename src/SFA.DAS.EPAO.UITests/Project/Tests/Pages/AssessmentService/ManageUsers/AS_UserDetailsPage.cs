namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;

public class AS_UserDetailsPage : EPAO_BasePage
{
    protected override string PageTitle => "User details";
    protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

    #region Locators
    private static By EditUserPermissionLink => By.LinkText("Edit user permissions");
    private static By ViewDashboardPermission => By.XPath("//li[contains(text(),'View dashboard')]");
    private static By ChangeOrganisationDetailsPersmission => By.XPath("//li[contains(text(),'Change organisation details')]");
    private static By PipelinePermission => By.XPath("//li[contains(text(),'Pipeline')]");
    private static By CompletedAssessmentsPermission => By.XPath("//li[contains(text(),'Completed assessments')]");
    private static By ManageStandardsPermission => By.XPath("//li[contains(text(),'Manage standards')]");
    private static By ManageUsersPermission => By.XPath("//li[contains(text(),'Manage users')]");
    private static By RecordGradesPermission => By.XPath("//li[contains(text(),'Record grades and issue certificates')]");
    private static By RemoveThisUserLink => By.LinkText("Remove this user");
    #endregion

    public AS_UserDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_EditUserPermissionsPage ClickEditUserPermissionLink()
    {
        formCompletionHelper.Click(EditUserPermissionLink);
        return new(context);
    }

    public bool IsViewDashboardPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(ViewDashboardPermission);

    public bool IsChangeOrganisationDetailsPersmissionDisplayed() => pageInteractionHelper.IsElementDisplayed(ChangeOrganisationDetailsPersmission);

    public bool IsPipelinePermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(PipelinePermission);

    public bool IsCompletedAssessmentsPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(CompletedAssessmentsPermission);
    
    public bool IsManageStandardsPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(ManageStandardsPermission);

    public bool IsManageUsersPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(ManageUsersPermission);

    public bool IsRecordGradesPermissionDisplayed() => pageInteractionHelper.IsElementDisplayed(RecordGradesPermission);

    public AS_RemoveUserPage ClicRemoveThisUserLinkInUserDetailPage()
    {
        formCompletionHelper.Click(RemoveThisUserLink);
        return new(context);
    }
}
