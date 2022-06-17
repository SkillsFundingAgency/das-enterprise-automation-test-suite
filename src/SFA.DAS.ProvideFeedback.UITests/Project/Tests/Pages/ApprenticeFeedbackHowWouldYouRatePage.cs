namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackHowWouldYouRatePage : ApprenticeFeedbackBasePage
{
    protected override string PageTitle => "How would you rate";

    public ApprenticeFeedbackHowWouldYouRatePage(ScenarioContext context) : base(context)
    {

    }

    public ApprenticeFeedbackCheckYourAnswersPage ProvideRating()
    {
        formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioItems)));

        return GoToCheckYourAnswersPage();
    }

    public ApprenticeFeedbackCheckYourAnswersPage GoToCheckYourAnswersPage()
    {
        ClickContinueButton();

        return new(context);
    }
}
