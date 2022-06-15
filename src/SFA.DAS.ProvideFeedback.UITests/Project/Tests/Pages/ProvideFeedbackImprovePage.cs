namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ProvideFeedbackImprovePage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "improve";

    protected override By ContinueButton => By.Id("q2-continue");
    private static By Options => By.CssSelector(".govuk-label.govuk-checkboxes__label");

    public ProvideFeedbackImprovePage(ScenarioContext context) : base(context) { }

    public ProvideFeedbackOverallRatingPage ContinueToOverallRating()
    {
        SelectOptionAndContinue(Options);
        return new (context);
    }
    public ProvideFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
    {
        Continue();
        return new (context);
    }
}