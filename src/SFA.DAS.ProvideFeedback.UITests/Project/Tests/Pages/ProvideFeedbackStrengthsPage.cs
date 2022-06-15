namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ProvideFeedbackStrengthsPage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "strengths";

    protected override By ContinueButton => By.Id("q1-continue");

    private static By Options => By.CssSelector(".govuk-label.govuk-checkboxes__label");

    public ProvideFeedbackStrengthsPage(ScenarioContext context) : base(context) { }

    public ProvideFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
    {
        Continue();
        return new (context);
    }

    public ProvideFeedbackImprovePage SelectOptionsForDoingWell()
    {
        SelectOptionAndContinue(Options);
        return new (context);
    }
}
