namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackDoYouThinkPage(ScenarioContext context) : ApprenticeFeedbackBasePage(context)
{
    protected override string PageTitle => "providing the following aspects of your apprenticeship training to a reasonable standard?";

    private static By RadioItems => By.CssSelector(".govuk-radios__item");

    public ApprenticeFeedbackHowWouldYouRatePage ProvideFeedback()
    {
        var elements = pageInteractionHelper.FindElements(RadioItems);

        for (int i = 0; i < elements.Count; i+=2)
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(new List<IWebElement> { elements[i], elements[i+1] }));
        }

        ClickContinueButton();

        return new (context);
    }

    public ApprenticeFeedbackCheckYourAnswersPage GoToCheckYourAnswersPage()
    {
        ClickContinueButton();

        return new(context);
    }

}
