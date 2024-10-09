namespace SFA.DAS.FAT.UITests.Project.Tests.Pages;

public class ProviderSummaryPage(ScenarioContext context) : FATBasePage(context)
{
    protected override string PageTitle => objectContext.GetProviderName();

    protected override string AccessibilityPageTitle => "Provider summary Page";

    #region Locators
    private static By LocationTextBox => By.Id("search-location");
    private static By ViewOtherTrainingProvidersButton => By.Id("btn-view-providers");
    private static By BackToTrainingProviders => By.Id("providers-breadcrumb");

    private static By TrainingOptions => By.XPath("(//h2['.govuk-heading-m'])[8]");

    private string TrainingOptionsText => $"{objectContext.GetProviderName()}’s training options";


    #endregion

    public void VerifyTrainingOptionsDisplayed() => pageInteractionHelper.VerifyText(TrainingOptions, TrainingOptionsText);

    public ProviderSummaryPage EnterPostCodeAndSearch(string location)
    {
        formCompletionHelper.EnterText(LocationTextBox, location);
        formCompletionHelper.SendKeys(LocationTextBox, Keys.Enter);
        return new ProviderSummaryPage(context);
    }
    public ProviderSearchResultsPage SelectViewOtherTrainingProviders()
    {
        formCompletionHelper.Click(ViewOtherTrainingProvidersButton);
        return new ProviderSearchResultsPage(context);
    }
    public ProviderSearchResultsPage NavigateBackFromProviderSummaryPage()
    {
        NavigateBackToTrainingProviders();
        return new ProviderSearchResultsPage(context);
    }
    public ProviderSearchResultsPage NavigateBackToTrainingProviders()
    {
        formCompletionHelper.Click(BackToTrainingProviders);
        return new ProviderSearchResultsPage(context);
    }
}