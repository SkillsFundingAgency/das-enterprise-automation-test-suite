namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class FeedbackCompletePage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "Feedback complete";

    protected override By PageHeader => By.CssSelector(".govuk-panel__title");

    public FeedbackCompletePage(ScenarioContext context) : base(context) { }

}