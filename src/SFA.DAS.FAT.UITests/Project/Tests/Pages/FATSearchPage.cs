namespace SFA.DAS.FAT.UITests.Project.Tests.Pages;

public class FATSearchPage(ScenarioContext context) : FATBasePage(context)
{
    protected override string PageTitle => "Search for apprenticeship training courses and training providers";

    #region Locators
    private static By StaBrowseAllCoursesLink => By.LinkText("Browse all courses");

    #endregion

    public ApprenticeshipTrainingCoursesPage BrowseAllCourses()
    {
        formCompletionHelper.Click(StaBrowseAllCoursesLink);
        return new ApprenticeshipTrainingCoursesPage(context);
    }
}
