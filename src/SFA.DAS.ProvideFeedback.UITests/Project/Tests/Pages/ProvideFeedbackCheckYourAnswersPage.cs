namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ProvideFeedbackCheckYourAnswersPage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "Check your answers";

    private static By ChangeQuestionOneLink => By.CssSelector("a[href*='question-one']");

    private static By ChangeQuestionTwoLink => By.CssSelector("a[href*='question-two']");

    private static By ChangeQuestionThreeLink => By.CssSelector("a[href*='question-three']");

    private static By SubmitAnswers => By.XPath("//button[@class='govuk-button']");

    public ProvideFeedbackCheckYourAnswersPage(ScenarioContext context) : base(context) { }

    public ProvideFeedbackStrengthsPage ChangeQuestionOne()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionOneLink));
        return new ProvideFeedbackStrengthsPage(context);
    }

    public ProvideFeedbackImprovePage ChangeQuestionTwo()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionTwoLink));
        return new ProvideFeedbackImprovePage(context);
    }

    public ProvideFeedbackOverallRatingPage ChangeQuestionThree()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionThreeLink));
        return new ProvideFeedbackOverallRatingPage(context);
    }

    public ProvideFeedbackCompletePage SubmitAnswersNow()
    {
        formCompletionHelper.ClickElement(SubmitAnswers);
        return new ProvideFeedbackCompletePage(context);
    }
}
