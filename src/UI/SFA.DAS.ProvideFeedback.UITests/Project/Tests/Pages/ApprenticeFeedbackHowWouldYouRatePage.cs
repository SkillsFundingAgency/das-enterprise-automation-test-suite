namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackHowWouldYouRatePage(ScenarioContext context) : ApprenticeFeedbackBasePage(context)
{
    protected override string PageTitle => "How would you rate";

    private static By RatingRadioItems => By.CssSelector("[id*='overall-rating']");

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
