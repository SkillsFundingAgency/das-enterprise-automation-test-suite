namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages.Provider;

public class FeedbackOverviewPage(ScenarioContext context, bool navigate = false) : ProviderFeedbackBasePage(context, true)
{
    public void VerifyRating(string period, string expectedRating)
    {
        pageInteractionHelper.VerifyText(By.Id($"apprentice-rating-description-{period}"), expectedRating);
    }

    protected override string PageTitle => "Your feedback";

    public void SelectApprenticeTabForAcademicYear(string academicYear)
    {
        formCompletionHelper.Click(By.Id($"tab_app-{academicYear}"));
    }
}