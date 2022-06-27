namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPageWithPendingChanges : SupportConsoleBasePage
{
    protected override string PageTitle => config.UlnName;

    protected override By PageHeader => By.CssSelector(".heading-large");

    public UlnDetailsPageWithPendingChanges(ScenarioContext context) : base(context) { }

    internal void ClickPendingChangesTab()
    {
        var pendingChangesLink = pageInteractionHelper.FindElement(By.CssSelector("a[href='#tab-pending-changes']"));
        pendingChangesLink.Click();
    }

    internal void PendingChangesAreDisplayed()
    {
        var rows = pageInteractionHelper.FindElements(By.CssSelector("#tab-pending-changes table tbody tr"));
        Assert.IsTrue(rows.Count > 0);
    }
}