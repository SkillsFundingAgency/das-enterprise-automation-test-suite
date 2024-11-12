namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class RequestSentToEmployerPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
{
    protected override string PageTitle => "Request sent to employer";

    private static By ViewEmployersPage => By.LinkText("View employers and manage permissions page");

    public ViewEmpAndManagePermissionsPage GoToViewEmployersPage()
    {
        formCompletionHelper.Click(ViewEmployersPage);

        return new(context);
    }
}
