namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public class TrainingCourseSummaryPage(ScenarioContext context) : FATV2BasePage(context)
{
    protected override string PageTitle => objectContext.GetTrainingCourseName();

    protected override string AccessibilityPageTitle => "Training course name Page";

    #region Locators
    private static By LocationTextBox => By.Id("search-location");
    private static By ViewProvidersForThisCourseButton => By.Id("btn-view-providers");
    private static By BackToCourseSearchPage => By.Id("courses-breadcrumb");

    #endregion

    public FATV2IndexPage NavigateBackToHompage()
    {
        NavigateToHomepage();
        return new FATV2IndexPage(context);
    }

    public ProviderSearchResultsPage EnterPostCodeAndSearch(string location)
    {
        formCompletionHelper.EnterText(LocationTextBox, location);
        formCompletionHelper.SendKeys(LocationTextBox, Keys.Tab);
        formCompletionHelper.Click(ViewProvidersForThisCourseButton);
        return new ProviderSearchResultsPage(context);
    }

    public ProviderSearchResultsPage ClickViewProvidersForThisCourse()
    {
        formCompletionHelper.Click(ViewProvidersForThisCourseButton);
        return new ProviderSearchResultsPage(context);
    }

    public TrainingCourseSearchResultsPage NavigateBackFromCourseSummaryPage()
    {
        NavigateBackToCourseSummary();
        return new TrainingCourseSearchResultsPage(context);
    }

    public TrainingCourseSearchResultsPage NavigateBackToCourseSummary()
    {
        formCompletionHelper.Click(BackToCourseSearchPage);
        return new TrainingCourseSearchResultsPage(context);
    }
}
