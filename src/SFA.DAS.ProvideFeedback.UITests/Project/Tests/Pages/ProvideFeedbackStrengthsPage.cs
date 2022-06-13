namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ProvideFeedbackStrengthsPage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "strengths";

    protected override By ContinueButton => By.Id("q1-continue");
    private static By Option1 => By.Id("col1-0");
    private static By Option2 => By.Id("col1-1");

    public ProvideFeedbackStrengthsPage(ScenarioContext context) : base(context) { }

    public ProvideFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
    {
        SelectOptionAndContinue();
        return new ProvideFeedbackCheckYourAnswersPage(context);
    }

    public ProvideFeedbackImprovePage SelectOptionsForDoingWell()
    {
        formCompletionHelper.SelectCheckbox(Option1);
        formCompletionHelper.SelectCheckbox(Option2);
        formCompletionHelper.ClickElement(ContinueButton);
        return new ProvideFeedbackImprovePage(context);
    }
}
