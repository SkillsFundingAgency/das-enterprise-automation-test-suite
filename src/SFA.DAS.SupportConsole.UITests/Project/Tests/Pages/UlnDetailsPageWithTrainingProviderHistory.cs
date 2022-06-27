namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPageWithTrainingProviderHistory : SupportConsoleBasePage
{
    protected override string PageTitle => config.UlnName;

    protected override By PageHeader => By.CssSelector(".heading-large");

    public UlnDetailsPageWithTrainingProviderHistory(ScenarioContext context) : base(context) { }

    internal void ClickPTrainingProviderHistoryTab()
    {
        var pendingChangesLink = pageInteractionHelper.FindElement(By.CssSelector("a[href='#tab-provider-history']"));
        pendingChangesLink.Click();
    }

    internal void TrainingProviderHistoryIsDisplayed()
    {
        var tables = pageInteractionHelper.FindElements(By.CssSelector("#tab-provider-history table"));
        Assert.IsTrue(tables.Count > 0);
    }
}