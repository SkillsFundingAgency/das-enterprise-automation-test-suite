namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public class TrainingCourseSearchResultsPage(ScenarioContext context) : ApprenticeshipTrainingCourseBasePage(context)
{
    #region Locators
    private static By UpdateResultsButton => By.Id("filters-submit");
    private static By LevelCheckBox(string level) => By.Id($"level-{level}");
    private static By LevelText => By.ClassName("das-no-wrap");
    private static By SortByOption => By.Id("sort-by-name");
    private static By SortByInfoText => By.Id("sort-by-relevance");

    #endregion

    public TrainingCourseSearchResultsPage SelectLevelAndFilterResults(string level)
    {
        SelectLevelCheckBox(level);
        formCompletionHelper.Click(UpdateResultsButton);
        return this;
    }

    public TrainingCourseSearchResultsPage VerifyLevelInfoFromSearchResults(string level)
    {
        pageInteractionHelper.VerifyText(LevelText, level);
        UnselectLevelCheckBox(level);
        formCompletionHelper.Click(UpdateResultsButton);
        return this;
    }

    public TrainingCourseSearchResultsPage VerifySortByInfoFromSearchResults(string relevance)
    {
        pageInteractionHelper.VerifyText(SortByInfoText, relevance);
        return this;
    }

    public TrainingCourseSummaryPage SelectFirstTrainingResult()
    {
        var firstLinkText = pageInteractionHelper.GetText(FirstResultLink);
        objectContext.SetTrainingCourseName(firstLinkText);
        formCompletionHelper.ClickLinkByText(firstLinkText);
        return new TrainingCourseSummaryPage(context);
    }

    public FATV2IndexPage NavigateBackToHompage()
    {
        NavigateToHomepage();
        return new FATV2IndexPage(context);
    }

    public void SelectNameOrderSort() => SelectSortByValue("Name");
    public void SelectRelevanceOrderSort() => SelectSortByValue("Relevance");
    private void SelectLevelCheckBox(string level) => formCompletionHelper.SelectCheckbox(LevelCheckBox(level));
    private void UnselectLevelCheckBox(string level) => formCompletionHelper.UnSelectCheckbox(LevelCheckBox(level));
    private void SelectSortByValue(string value) => formCompletionHelper.ClickLinkByText(SortByOption, value);
}
