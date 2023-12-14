namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackImprovePage : EmployerFeedbackBasePage
{
    protected override string PageTitle => "improve";

    protected override By ContinueButton => By.Id("q2-continue");
    private static By Options => By.CssSelector(".govuk-label.govuk-checkboxes__label");

    public EmployerFeedbackImprovePage(ScenarioContext context) : base(context) { }

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