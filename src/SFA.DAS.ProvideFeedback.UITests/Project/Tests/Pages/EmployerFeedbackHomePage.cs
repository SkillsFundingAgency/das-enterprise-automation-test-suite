namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackHomePage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "Give feedback";

    private static By StartButton => By.Id("service-start");

    public EmployerFeedbackStrengthsPage StartNow()
    {
        formCompletionHelper.ClickElement(StartButton);
        return new(context);
    }
}