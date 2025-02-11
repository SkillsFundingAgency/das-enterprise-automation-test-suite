namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class RequestSentToEmployerPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
{
    protected override string PageTitle => "Request sent to employer";

    private static By ViewEmployersPage => By.LinkText("View employers and manage permissions page");

    private static By ViewCurrentEmployersPage => By.LinkText("View current employers and permissions");

    public ViewEmpAndManagePermissionsPage GoToViewEmployersPage()
    {
        formCompletionHelper.Click(ViewEmployersPage);

        return new(context);
    }

    public ViewEmpAndManagePermissionsPage GoToViewCurrentEmployersPage()
    {
        formCompletionHelper.Click(ViewCurrentEmployersPage);

        return new(context);
    }
}
