namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public class ProviderSearchResultsPage : FATV2BasePage
{
    protected override string PageTitle => "Training providers for";

    protected override bool TakeFullScreenShot => false;

    protected override By PageHeader => By.ClassName("govuk-caption-xl");

    #region Locators
    private static By ProviderSearchList => By.CssSelector(".das-search-results__link");
    private static By BackToCourseSummaryPage => By.Id("course-detail-breadcrumb");
    private static By AddToShortlist => By.CssSelector("button[id^='add-to-shortlist-']");
    private static By RemoveLocation => By.LinkText("Clear");
    #endregion

    public ProviderSearchResultsPage(ScenarioContext context) : base(context) { }

    public ProviderSummaryPage SelectFirstProviderInTheList()
    {
        var firstProviderLinkText = pageInteractionHelper.GetText(FirstProviderResultLink);
        objectContext.SetProviderName(firstProviderLinkText);
        formCompletionHelper.ClickLinkByText(firstProviderLinkText);
        return new ProviderSummaryPage(context);
    }
    public TrainingCourseSummaryPage NavigateBackFromTrainingProvidersPage()
    {
        NavigateBackToTrainingProviders();
        return new TrainingCourseSummaryPage(context);
    }
    public TrainingCourseSummaryPage NavigateBackToTrainingProviders()
    {
        formCompletionHelper.Click(BackToCourseSummaryPage);
        return new TrainingCourseSummaryPage(context);
    }
    public ProviderSearchResultsPage ShortlistAProviderFromProviderList()
    {
        formCompletionHelper.Click(AddToShortlist);
        return new ProviderSearchResultsPage(context);
    }
    public ProviderSearchResultsPage RemoveLocationOnProviderListPage()
    {
        formCompletionHelper.Click(RemoveLocation);
        return new ProviderSearchResultsPage(context);
    }
    public ProviderShortlistPage NavigateToProviderShortlistPage()
    {
        NavigateToShortlistPage();
        return new ProviderShortlistPage(context);
    }

    public ProviderSummaryPage SelectAProvider()
    {
        formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(ProviderSearchList)));
        return new ProviderSummaryPage(context);
    }
}
