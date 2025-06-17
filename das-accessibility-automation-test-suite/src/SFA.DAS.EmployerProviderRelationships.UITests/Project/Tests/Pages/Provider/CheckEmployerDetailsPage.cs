namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class CheckEmployerDetailsPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
{
    protected override string PageTitle => "Check details";

    public RequestSentToEmployerPage SendInvitation()
    {
        Continue();

        return new(context);
    }

    public AddAnEmployerPage AccessChangeEmployerName()
    {
        formCompletionHelper.ClickLinkByText("Change employer name");

        return new(context);
    }

    public AccAccountRequestPermissionsPage AccessChangePermissions()
    {
        formCompletionHelper.ClickLinkByText("Change permissions");

        return new(context);
    }
}
