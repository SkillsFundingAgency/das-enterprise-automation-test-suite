namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnDetailsPageWithTrainingProviderHistory(ScenarioContext context, CohortDetails cohortDetails) : UlnDetailsPage(context, cohortDetails)
{
    private static By ProviderHistoryTab => By.CssSelector("a[href='#tab-provider-history']");

    private static By ProviderHistoryTable => By.CssSelector("#tab-provider-history table");

    internal void ClickTrainingProviderHistoryTab() => ClickTab(ProviderHistoryTab);

    internal void TrainingProviderHistoryIsDisplayed() => IsTabDisplayed(ProviderHistoryTable);
}