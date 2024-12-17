namespace SFA.DAS.FAT.UITests.Project.Tests.Pages;

public class ApprenticeshipTrainingCoursesPage : FATBasePage
{
    #region Locators
    private static By UpdateResultsButton => By.Id("filters-submit");
    private static By LevelCheckBox(string level) => By.Id($"level-{level}");
    private static By LevelText => By.ClassName("das-no-wrap");
    private static By SortByOption => By.Id("sort-by-name");
    private static By SortByInfoText => By.Id("sort-by-relevance");

    private static By FirstSearchResult => By.CssSelector(".das-search-results__heading");

    #endregion

    protected override string PageTitle => "Apprenticeship training courses";

    protected override bool TakeFullScreenShot => false;

    public ApprenticeshipTrainingCoursesPage(ScenarioContext context) : base(context)
    {
        var environmentName = EnvironmentName.ToLower() + "-";

        var currentURL = GetUrl();

        if (!currentURL.Contains(environmentName, System.StringComparison.CurrentCultureIgnoreCase))
        {
            var newURL = currentURL.Insert(8, environmentName);

            tabHelper.GoToUrl(newURL);
        }
    }

    public ApprenticeshipTrainingCoursesPage SearchApprenticeshipInApprenticeshipTrainingCoursesPage(string searchTerm)
    {
        SearchApprenticeship(searchTerm);

        return new ApprenticeshipTrainingCoursesPage(context);
    }

    public ApprenticeshipTrainingCoursesPage SelectLevelAndFilterResults(string level)
    {
        SelectLevelCheckBox(level);
        formCompletionHelper.Click(UpdateResultsButton);
        return this;
    }

    public ApprenticeshipTrainingCoursesPage VerifyLevelInfoFromSearchResults(string level)
    {
        pageInteractionHelper.VerifyText(LevelText, level);
        UnselectLevelCheckBox(level);
        formCompletionHelper.Click(UpdateResultsButton);
        return this;
    }

    public ApprenticeshipTrainingCoursesPage VerifySortByInfoFromSearchResults(string relevance)
    {
        pageInteractionHelper.VerifyText(SortByInfoText, relevance);
        return this;
    }

    public ApprenticeshipTrainingCourseSummaryPage SelectFirstTrainingResult()
    {
        var firstLinkText = pageInteractionHelper.GetText(FirstSearchResult).Replace("\r\n", " ");

        objectContext.SetTrainingCourseName(firstLinkText);

        SetDebugInformation($"selected '{firstLinkText}' course");

        formCompletionHelper.ClickLinkByText(firstLinkText);

        return new ApprenticeshipTrainingCourseSummaryPage(context);
    }

    public FATIndexPage NavigateBackToHompage()
    {
        NavigateToHomepage();

        return new FATIndexPage(context);
    }

    public void SelectNameOrderSort() => SelectSortByValue("Name");
    public void SelectRelevanceOrderSort() => SelectSortByValue("Relevance");
    private void SelectLevelCheckBox(string level) => formCompletionHelper.SelectCheckbox(LevelCheckBox(level));
    private void UnselectLevelCheckBox(string level) => formCompletionHelper.UnSelectCheckbox(LevelCheckBox(level));
    private void SelectSortByValue(string value) => formCompletionHelper.ClickLinkByText(SortByOption, value);
}
