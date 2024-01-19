namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class OrganisationApplicationsPage(ScenarioContext context) : ApplicationBasePage(context)
{
    protected override string PageTitle => "Organisation applications";

    public OrganisationApplicationOverviewPage GoToNewOrganisationApplicationOverviewPage() => GoToOrganisationApplicationOverviewPage(NewTab);

    public OrganisationApplicationOverviewPage GoToInProgressOrganisationApplicationOverviewPage() => GoToOrganisationApplicationOverviewPage(InProgressTab);

    public OrganisationApplicationOverviewPage GoToApprovedOrganisationApplicationOverviewPage() => GoToOrganisationApplicationOverviewPage(ApprovedTab);

    private OrganisationApplicationOverviewPage GoToOrganisationApplicationOverviewPage(By by)
    {
        GoToApplicationOverviewPage(by);
        return new(context);
    }
}