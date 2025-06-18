namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPageWithPendingChanges(ScenarioContext context, CohortDetails cohortDetails) : UlnDetailsPage(context, cohortDetails)
{
    private static By PendingChangesTab => By.CssSelector("a[href='#tab-pending-changes']");

    private static By PendingChangesTable => By.CssSelector("#tab-pending-changes table tbody tr");

    internal void ClickPendingChangesTab() => ClickTab(PendingChangesTab);

    internal void PendingChangesAreDisplayed() => IsTabDisplayed(PendingChangesTable);

}