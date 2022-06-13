namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ProvideFeedbackOverallRatingPage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "Overall rating";

    protected override By ContinueButton => By.Id("q3-continue");

    private static By GoodOption => By.CssSelector("label[for='Good']");

    private static By VeryPoorOption => By.CssSelector("label[for='VeryPoor']");

    public ProvideFeedbackOverallRatingPage(ScenarioContext context) : base(context) { }

    public ProvideFeedbackCheckYourAnswersPage SelectVPoorAndContinue() => GoToProvideFeedbackCheckYourAnswersPage(VeryPoorOption);

    public ProvideFeedbackCheckYourAnswersPage SelectGoodAndContinue() => GoToProvideFeedbackCheckYourAnswersPage(GoodOption);

    private ProvideFeedbackCheckYourAnswersPage GoToProvideFeedbackCheckYourAnswersPage(By selector)
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(selector));
        Continue();
        return new (context);

    }
}
