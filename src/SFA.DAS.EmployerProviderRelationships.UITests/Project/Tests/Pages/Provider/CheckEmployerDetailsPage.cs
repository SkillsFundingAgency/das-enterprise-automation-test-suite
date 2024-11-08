namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class CheckEmployerDetailsPage(ScenarioContext context) : ProviderRelationshipsBasePage(context)
{
    protected override string PageTitle => "Check details";

    public RequestSentToEmployerPage SendInvitation()
    {
        Continue();

        return new(context);
    }
}
