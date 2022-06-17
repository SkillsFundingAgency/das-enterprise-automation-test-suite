namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackHowWouldYouRatePage : ApprenticeFeedbackBasePage
{
    protected override string PageTitle => "How would you rate";

    private static By RatingRadioItems => By.CssSelector("[id*='overall-rating']");

    public ApprenticeFeedbackHowWouldYouRatePage(ScenarioContext context) : base(context)
    {

    }

    public ApprenticeFeedbackCheckYourAnswersPage ProvideRating()
    {
        formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RatingRadioItems)));

        return GoToCheckYourAnswersPage();
    }

    public ApprenticeFeedbackCheckYourAnswersPage GoToCheckYourAnswersPage()
    {
        ClickContinueButton();

        return new(context);
    }
}
