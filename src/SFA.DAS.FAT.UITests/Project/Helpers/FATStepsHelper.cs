namespace SFA.DAS.FAT.UITests.Project.Helpers;

public class FATStepsHelper(ScenarioContext context)
{
    public ApprenticeshipTrainingCoursesPage SearchForTrainingCourse(string course) => new FATIndexPage(context).ClickStartButton().BrowseAllCourses().SearchApprenticeshipInApprenticeshipTrainingCoursesPage(course);

    public ProviderSummaryPage SelectASpecificProvider(string provider) => new ProviderSearchResultsPage(context).ClickSpecifiedProvider(provider);

    public ProviderShortlistPage ShortlistATrainingCourseAndNavigateToShortlistPage() => ViewProvidersForThisCourse().ShortlistAProviderFromProviderList().NavigateToProviderShortlistPage();

    public ProviderSearchResultsPage ViewProvidersForThisCourse() => SearchForTrainingCourse(string.Empty).SelectFirstTrainingResult().ViewProvidersForThisCourse();
}
