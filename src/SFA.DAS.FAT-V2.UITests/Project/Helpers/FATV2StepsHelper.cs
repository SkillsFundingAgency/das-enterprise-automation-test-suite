namespace SFA.DAS.FAT_V2.UITests.Project.Helpers;

public class FATV2StepsHelper(ScenarioContext context)
{
    public TrainingCourseSearchResultsPage SearchForTrainingCourse(string course) => new FATV2IndexPage(context).ClickStartButton().SearchApprenticeshipInFindApprenticeshipTrainingSearchPage(course);

    public ProviderSummaryPage SelectASpecificProvider(string provider) => new ProviderSearchResultsPage(context).ClickSpecifiedProvider(provider);

    public ProviderShortlistPage ShortlistATrainingCourseAndNavigateToShortlistPage() => ViewProvidersForThisCourse().ShortlistAProviderFromProviderList().NavigateToProviderShortlistPage();

    public ProviderSearchResultsPage ViewProvidersForThisCourse() => SearchForTrainingCourse(string.Empty).SelectFirstTrainingResult().ClickViewProvidersForThisCourse();
}
