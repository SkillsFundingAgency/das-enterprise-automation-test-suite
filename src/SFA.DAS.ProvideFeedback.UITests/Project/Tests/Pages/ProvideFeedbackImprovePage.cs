namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ProvideFeedbackImprovePage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "improve";

    protected override By ContinueButton => By.Id("q2-continue");
    private static By Option1 => By.Id("col1-2");
    private static By Option2 => By.Id("col1-3");

    public ProvideFeedbackImprovePage(ScenarioContext context) : base(context) { }

    public ProvideFeedbackOverallRatingPage ContinueToOverallRating()
    {
        formCompletionHelper.SelectCheckbox(Option1);
        formCompletionHelper.SelectCheckbox(Option2);
        formCompletionHelper.ClickElement(ContinueButton);
        return new ProvideFeedbackOverallRatingPage(context);
    }

    public ProvideFeedbackOverallRatingPage SkipQuestion2()
    {
        formCompletionHelper.ClickLinkByText("Skip this question");
        return new ProvideFeedbackOverallRatingPage(context);
    }

    public ProvideFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
    {
        SelectOptionAndContinue();
        return new ProvideFeedbackCheckYourAnswersPage(context);
    }
}