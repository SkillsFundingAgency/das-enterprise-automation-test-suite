namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackCheckYourAnswersPage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "Check your answers";

    private static By ChangeQuestionOneLink => By.CssSelector("a[href*='question-one?']");

    private static By ChangeQuestionTwoLink => By.CssSelector("a[href*='question-two?']");

    private static By ChangeQuestionThreeLink => By.CssSelector("a[href*='question-three?']");

    private static By SubmitAnswers => By.XPath("//button[@class='govuk-button']");

    public EmployerFeedbackStrengthsPage ChangeQuestionOne()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionOneLink));
        return new(context);
    }

    public EmployerFeedbackImprovePage ChangeQuestionTwo()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionTwoLink));
        return new(context);
    }

    public EmployerFeedbackOverallRatingPage ChangeQuestionThree()
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionThreeLink));
        return new(context);
    }

    public FeedbackCompletePage SubmitAnswersNow()
    {
        formCompletionHelper.ClickElement(SubmitAnswers);
        return new(context);
    }
}
