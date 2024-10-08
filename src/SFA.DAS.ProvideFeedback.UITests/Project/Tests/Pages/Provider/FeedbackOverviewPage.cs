namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages.Provider;

public class FeedbackOverviewPage(ScenarioContext context, bool navigate = false) : ProviderFeedbackBasePage(context, true)
{
    public void VerifyApprenticeFeedbackRating(string period, string expectedRating)
    {
        pageInteractionHelper.VerifyText(By.Id($"apprentice-rating-description-{period}"), expectedRating);
    }

    protected override string PageTitle => "Your feedback";

    public void SelectApprenticeTabForAcademicYear(string academicYear)
    {
        formCompletionHelper.Click(By.Id($"tab_app-{academicYear}"));
    }

    public void VerifyEmployerFeedbackRating(string period, string expectedRating)
    {
        pageInteractionHelper.VerifyText(By.Id($"employer-rating-description-{period}"), expectedRating);
    }

    public void SelectEmployerTabForAcademicYear(string academicYear)
    {
        formCompletionHelper.Click(By.Id($"tab_emp-{academicYear}"));
    }
}