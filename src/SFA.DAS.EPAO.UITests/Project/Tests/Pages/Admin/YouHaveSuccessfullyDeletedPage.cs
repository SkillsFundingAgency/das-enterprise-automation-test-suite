namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class YouHaveSuccessfullyDeletedPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "You’ve successfully deleted";

    private static By ReturnToStaffDashBoard => By.CssSelector(".govuk-button");

    public YouHaveSuccessfullyDeletedPage(ScenarioContext context) : base(context) => VerifyPage();

    public StaffDashboardPage ClickReturnToDashboard()
    {
        formCompletionHelper.ClickElement(ReturnToStaffDashBoard);
        return new StaffDashboardPage(context);
    }
}