namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class HowWouldYouRateTrainingProviderPage : ApprenticeFeedbackBasePage
{
    protected override string PageTitle => "How would you rate";

    public HowWouldYouRateTrainingProviderPage(ScenarioContext context) : base(context)
    {

    }

    public CheckYourAnswersTrainingProviderPage ProvideRating()
    {
        formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(RadioItems)));

        return GoToCheckYourAnswersPage();
    }

    public CheckYourAnswersTrainingProviderPage GoToCheckYourAnswersPage()
    {
        ClickContinueButton();

        return new(context);
    }
}
