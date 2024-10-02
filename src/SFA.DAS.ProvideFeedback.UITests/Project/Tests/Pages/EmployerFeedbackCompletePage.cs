namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class FeedbackCompletePage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "Feedback complete";
    private string BannerClass = "govuk-panel__title";

    protected override By PageHeader => By.CssSelector(".govuk-panel__title");

    public void VerifyBanner()
    {
        pageInteractionHelper.IsElementDisplayed(By.ClassName(BannerClass));
    }
}