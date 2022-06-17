namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackCheckYourAnswersPage : ApprenticeFeedbackBasePage
{
    protected override string PageTitle => "Check your answers";

    private static By ChangeFeedbackAttributeQuestionLink => By.CssSelector("a[href*='feedback-attributes']");

    private static By ChangeOverallRatingQuestionLink => By.CssSelector("a[href*='overall-rating']");

    private static By ContactConsent => By.CssSelector("#ContactConsent");

    public ApprenticeFeedbackCheckYourAnswersPage(ScenarioContext context) : base(context)
    {

    }

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
        formCompletionHelper.ClickElement(ContactConsent);

        formCompletionHelper.ClickButtonByText(ContinueToSubmitButton, "Submit");

        return new(context);
    }
}
