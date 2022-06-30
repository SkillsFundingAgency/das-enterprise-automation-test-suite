namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPageWithTrainingProviderHistory : SupportConsoleBasePage
{
    protected override string PageTitle => config.UlnName;

    protected override By PageHeader => By.CssSelector(".heading-large");

    private static By ProviderHistoryTab => By.CssSelector("a[href='#tab-provider-history']");

    private static By ProviderHistoryTable => By.CssSelector("#tab-provider-history table");

    public UlnDetailsPageWithTrainingProviderHistory(ScenarioContext context) : base(context) { }

    internal void ClickTrainingProviderHistoryTab() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ProviderHistoryTab));

    internal void TrainingProviderHistoryIsDisplayed() => Assert.IsTrue(pageInteractionHelper.FindElements(ProviderHistoryTable).Count > 0);
}