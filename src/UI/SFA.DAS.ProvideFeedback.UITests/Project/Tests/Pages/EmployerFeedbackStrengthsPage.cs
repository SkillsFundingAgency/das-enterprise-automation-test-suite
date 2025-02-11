namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackStrengthsPage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "strengths";

    protected override By ContinueButton => By.Id("q1-continue");

    private static By Options => By.CssSelector(".govuk-label.govuk-checkboxes__label");

    public EmployerFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
    {
        Continue();
        return new(context);
    }

    public EmployerFeedbackImprovePage SelectOptionsForDoingWell()
    {
        SelectOptionAndContinue(Options);
        return new(context);
    }
}
