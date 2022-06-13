namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ProvideFeedbackHomePage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "Give feedback";

    private static By StartButton => By.Id("service-start");

    public ProvideFeedbackHomePage(ScenarioContext context) : base(context) { }

    public ProvideFeedbackStrengthsPage StartNow()
    {
        formCompletionHelper.ClickElement(StartButton);
        return new ProvideFeedbackStrengthsPage(context);
    }
}