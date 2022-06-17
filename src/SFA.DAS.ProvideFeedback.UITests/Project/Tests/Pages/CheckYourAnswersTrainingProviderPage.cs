namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class CheckYourAnswersTrainingProviderPage : ApprenticeFeedbackBasePage
{
    protected override string PageTitle => "Check your answers";

    private static By ChangeFeedbackAttributeQuestionLink => By.CssSelector("a[href*='feedback-attributes']");

    private static By ChangeOverallRatingQuestionLink => By.CssSelector("a[href*='overall-rating']");

    private static By ContactConsent => By.CssSelector("#ContactConsent");

    public CheckYourAnswersTrainingProviderPage(ScenarioContext context) : base(context)
    {

    }

    public DoYouThinkTrainingProviderPage ChangeFeedbackAttribute()
    {
        formCompletionHelper.ClickElement(ChangeFeedbackAttributeQuestionLink);
        return new(context);
    }

    public HowWouldYouRateTrainingProviderPage ChangeOverallRating()
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
