namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPageWithPendingChanges : SupportConsoleBasePage
{
    protected override string PageTitle => config.UlnName;

    protected override By PageHeader => By.CssSelector(".heading-large");

    private static By PendingChangesTab => By.CssSelector("a[href='#tab-pending-changes']");

    private static By PendingChangesTable => By.CssSelector("#tab-pending-changes table tbody tr");

    public UlnDetailsPageWithPendingChanges(ScenarioContext context) : base(context) { }

    internal void ClickPendingChangesTab() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PendingChangesTab));

    internal void PendingChangesAreDisplayed() => Assert.IsTrue(pageInteractionHelper.FindElements(PendingChangesTable).Count > 0);
}