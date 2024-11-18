namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class EmployerAccountDetailsPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
{
    protected override By ContinueButton => By.CssSelector("button.govuk-button[type='submit']");

    private static By ViewEmployersPage => By.LinkText("View employers and manage permissions page");

    protected override string PageTitle => "Employer account details";

    public void ChangePermissions()
    {
        Continue();
    }

    public ViewEmpAndManagePermissionsPage ViewEmployersAndManagePermissionsPage()
    {
        formCompletionHelper.Click(ViewEmployersPage);

        return new(context);
    }

}
