namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class FeedbackCompletePage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "Feedback complete";

    protected override By PageHeader => By.CssSelector(".govuk-panel__title");
}