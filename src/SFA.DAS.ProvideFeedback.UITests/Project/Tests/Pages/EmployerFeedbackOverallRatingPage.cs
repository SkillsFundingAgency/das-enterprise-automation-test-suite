namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackOverallRatingPage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "Overall rating";

    protected override By ContinueButton => By.Id("q3-continue");

    private static By GoodOption => By.CssSelector("label[for='Good']");

    private static By VeryPoorOption => By.CssSelector("label[for='VeryPoor']");

    public EmployerFeedbackCheckYourAnswersPage SelectVPoorAndContinue() => GoToProvideFeedbackCheckYourAnswersPage(VeryPoorOption);

    public EmployerFeedbackCheckYourAnswersPage SelectGoodAndContinue() => GoToProvideFeedbackCheckYourAnswersPage(GoodOption);

    private EmployerFeedbackCheckYourAnswersPage GoToProvideFeedbackCheckYourAnswersPage(By selector)
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(selector));
        Continue();
        return new(context);

    }
}
