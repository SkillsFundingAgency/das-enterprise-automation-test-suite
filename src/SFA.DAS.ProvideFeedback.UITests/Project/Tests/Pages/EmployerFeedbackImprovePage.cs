namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackImprovePage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "improve";

    protected override By ContinueButton => By.Id("q2-continue");
    private static By Options => By.CssSelector(".govuk-label.govuk-checkboxes__label");

    public EmployerFeedbackOverallRatingPage ContinueToOverallRating()
    {
        SelectOptionAndContinue(Options);
        return new(context);
    }
    public EmployerFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
    {
        Continue();
        return new(context);
    }
}