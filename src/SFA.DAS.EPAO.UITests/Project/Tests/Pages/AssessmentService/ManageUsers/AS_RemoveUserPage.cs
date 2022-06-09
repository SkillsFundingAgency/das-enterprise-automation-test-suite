namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;

public class AS_RemoveUserPage : EPAO_BasePage
{
    protected override string PageTitle => "Remove user";
    protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

    public AS_RemoveUserPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_UserRemovedPage ClickRemoveUserButtonInRemoveUserPage()
    {
        Continue();
        return new AS_UserRemovedPage(context);
    }
}
