namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public class FindApprenticeshipTrainingSearchPage(ScenarioContext context) : ApprenticeshipTrainingCourseBasePage(context)
{
    public TrainingCourseSearchResultsPage SearchApprenticeshipInFindApprenticeshipTrainingSearchPage(string searchTerm)
    {
        SearchApprenticeship(searchTerm);
        return new TrainingCourseSearchResultsPage(context);
    }
}
