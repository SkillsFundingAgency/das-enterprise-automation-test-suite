namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;

public class AS_UsersPage : EPAO_BasePage
{
    protected override string PageTitle => "Users";

    #region Locators
    private static By ManageUserNameLink => By.LinkText("Mr Preprod Epao0007");
    private static By PermissionsEditUserLink => By.LinkText("Liz Kemp");
    private static By InviteNewUSerButton => By.LinkText("Invite new user");
    #endregion

    public AS_UsersPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_UserDetailsPage ClickManageUserNameLink()
    {
        formCompletionHelper.Click(ManageUserNameLink);
        return new AS_UserDetailsPage(context);
    }

    public AS_UserDetailsPage ClickPermissionsEditUserLink()
    {
        formCompletionHelper.Click(PermissionsEditUserLink);
        return new AS_UserDetailsPage(context);
    }

    public AS_InviteUserPage ClickInviteNewUserButton()
    {
        formCompletionHelper.Click(InviteNewUSerButton);
        return new AS_InviteUserPage(context);
    }

    public AS_UserDetailsPage ClickOnNewlyAddedUserLink(string userEmail)
    {
        formCompletionHelper.Click(By.XPath($"//span[text()='{userEmail}']/..//a"));
        return new AS_UserDetailsPage(context);
    }
}
