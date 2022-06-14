namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;

class AS_UserInvitedPage : EPAO_BasePage
{
    protected override string PageTitle => "User invited";

    private static By InviteSomeoneElseLink => By.LinkText("Invite someone else");

    public AS_UserInvitedPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_InviteUserPage ClickInviteSomeoneElseLink()
    {
        formCompletionHelper.Click(InviteSomeoneElseLink);
        return new(context);
    }
}
