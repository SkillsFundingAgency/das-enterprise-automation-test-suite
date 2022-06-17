namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;


public class SelectATrainingProviderPage : ApprenticeFeedbackBasePage
{
    private static By SelectTrainingProvider => By.CssSelector("a.govuk-link[href*='start']");

    protected override string PageTitle => "Select a training provider";

    public SelectATrainingProviderPage(ScenarioContext context) : base(context)
    {

    }

    public GiveFeedbackOnATrainingProviderPage SelectATrainingProvider()
    {
        formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(SelectTrainingProvider)));

        return new (context);
    }
}
