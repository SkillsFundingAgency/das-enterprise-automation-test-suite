namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class StandardApplicationsPage(ScenarioContext context) : ApplicationBasePage(context)
{
    protected override string PageTitle => "Standard applications";

    public StandardApplicationOverviewPage GoToNewStandardApplicationOverviewPage() => GoToStandardApplicationOverviewPage(NewTab);

    public StandardApplicationOverviewPage GoToInProgressStandardApplicationOverviewPage() => GoToStandardApplicationOverviewPage(InProgressTab);

    public StandardApplicationOverviewPage GoToApprovedStandardApplicationOverviewPage() => GoToStandardApplicationOverviewPage(ApprovedTab);

    private StandardApplicationOverviewPage GoToStandardApplicationOverviewPage(By by)
    {
        GoToApplicationOverviewPage(by);
        return new(context);
    }
}