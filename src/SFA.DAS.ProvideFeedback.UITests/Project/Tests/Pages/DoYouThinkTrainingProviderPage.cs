namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class DoYouThinkTrainingProviderPage : ApprenticeFeedbackBasePage
{
    protected override string PageTitle => "providing the following aspects of your apprenticeship training to a reasonable standard?";


    public DoYouThinkTrainingProviderPage(ScenarioContext context) : base(context)
    {

    }

    public HowWouldYouRateTrainingProviderPage ProvideFeedback()
    {
        var elements = pageInteractionHelper.FindElements(RadioItems);

        for (int i = 0; i < elements.Count; i+=2)
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(new List<IWebElement> { elements[i], elements[i+1] }));
        }

        ClickContinueButton();

        return new (context);
    }

    public CheckYourAnswersTrainingProviderPage GoToCheckYourAnswersPage()
    {
        ClickContinueButton();

        return new(context);
    }

}
