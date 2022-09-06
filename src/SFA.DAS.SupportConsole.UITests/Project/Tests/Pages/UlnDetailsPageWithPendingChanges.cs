namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPageWithPendingChanges : UlnDetailsPage
{
    private static By PendingChangesTab => By.CssSelector("a[href='#tab-pending-changes']");

    private static By PendingChangesTable => By.CssSelector("#tab-pending-changes table tbody tr");

    public UlnDetailsPageWithPendingChanges(ScenarioContext context, CohortDetails cohortDetails) : base(context, cohortDetails) { }

    internal void ClickPendingChangesTab() => ClickTab(PendingChangesTab);

    internal void PendingChangesAreDisplayed() => IsTabDisplayed(PendingChangesTable);

}