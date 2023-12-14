namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;

public class ProviderShortlistPage(ScenarioContext context) : FATV2BasePage(context)
{
    protected override string PageTitle => "Shortlisted training providers";

    #region
    private static By RemoveShortlist => By.CssSelector("button[id^='remove-shortlistitem-']");
    private static By ReturnToTrainingCoursePage => By.LinkText("View apprenticeship training courses");

    #endregion

    public ProviderShortlistPage RemoveShortlistedProvider()
    {
        formCompletionHelper.Click(RemoveShortlist);
        return new ProviderShortlistPage(context);
    }

    public TrainingCourseSearchResultsPage ReturnToTrainingCourseSearchResultsPage()
    {
        formCompletionHelper.Click(ReturnToTrainingCoursePage);
        return new TrainingCourseSearchResultsPage(context);
    }
}
