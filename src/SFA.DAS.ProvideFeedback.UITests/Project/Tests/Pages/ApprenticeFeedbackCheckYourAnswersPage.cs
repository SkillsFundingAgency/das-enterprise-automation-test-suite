namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackCheckYourAnswersPage(ScenarioContext context) : ApprenticeFeedbackBasePage(context)
{
    protected override string PageTitle => "Check your answers";

    private static By ChangeFeedbackAttributeQuestionLink => By.CssSelector("a[href*='feedback-attributes']");

    private static By ChangeOverallRatingQuestionLink => By.CssSelector("a[href*='overall-rating']");

    public ApprenticeFeedbackDoYouThinkPage ChangeFeedbackAttribute()
    {
        formCompletionHelper.ClickElement(ChangeFeedbackAttributeQuestionLink);
        return new(context);
    }

    public ApprenticeFeedbackHowWouldYouRatePage ChangeOverallRating()
    {
        formCompletionHelper.ClickElement(ChangeOverallRatingQuestionLink);
        return new(context);
    }

    public FeedbackCompletePage SubmitAnswers()
    {
        formCompletionHelper.ClickButtonByText(ContinueToSubmitButton, "Submit");

        return new(context);
    }
}
