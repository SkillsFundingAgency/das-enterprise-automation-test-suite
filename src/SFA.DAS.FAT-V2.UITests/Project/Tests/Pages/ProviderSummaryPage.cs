namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public class ProviderSummaryPage : FATV2BasePage
{
    protected override string PageTitle => objectContext.GetProviderName();

    #region Locators
    private static By LocationTextBox => By.Id("search-location");
    private static By ViewOtherTrainingProvidersButton => By.Id("btn-view-providers");
    private static By BackToTrainingProviders => By.Id("providers-breadcrumb");
    private static By NoProviderAtLocationErrorText => By.Id("course_provider_not_available");
    #endregion

    public ProviderSummaryPage(ScenarioContext context) : base(context) { }
    
    public bool VerifyNoTrainingProviderAtLocationErrorText() => pageInteractionHelper.IsElementDisplayed(NoProviderAtLocationErrorText);

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