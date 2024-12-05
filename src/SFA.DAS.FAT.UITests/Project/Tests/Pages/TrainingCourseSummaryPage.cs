namespace SFA.DAS.FAT.UITests.Project.Tests.Pages;

public class TrainingCourseSummaryPage(ScenarioContext context) : FATBasePage(context)
{
    protected override string PageTitle => objectContext.GetTrainingCourseName();

    protected override string AccessibilityPageTitle => "Training course name Page";

    #region Locators
    private static By LocationTextBox => By.Id("search-location");
    private static By ViewProvidersForThisCourseButton => By.Id("btn-view-providers");
    private static By BackToCourseSearchPage => By.Id("courses-breadcrumb");

    #endregion

    public FATIndexPage NavigateBackToHompage()
    {
        NavigateToHomepage();
        return new FATIndexPage(context);
    }

    public ProviderSearchResultsPage ViewProvidersForThisCourse() => ViewProvidersForThisCourse(false, string.Empty);

    public ProviderSearchResultsPage ViewProvidersForThisCourse(string location) => ViewProvidersForThisCourse(true, location);

    public ProviderSearchResultsPage ViewProvidersForThisCourse(bool filterByLocation, string location)
    {
        if (filterByLocation)
        {
            location = string.IsNullOrEmpty(location) ? RandomDataGenerator.RandomTown() : location;

            formCompletionHelper.EnterText(LocationTextBox, location);

            formCompletionHelper.SendKeys(LocationTextBox, Keys.Tab);
        }

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
