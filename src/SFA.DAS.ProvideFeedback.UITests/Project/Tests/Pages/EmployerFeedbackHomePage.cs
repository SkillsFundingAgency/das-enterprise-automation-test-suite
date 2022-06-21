namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackHomePage : EmployerFeedbackBasePage
{
    protected override string PageTitle => "Give feedback";

    private static By StartButton => By.Id("service-start");

    public EmployerFeedbackHomePage(ScenarioContext context) : base(context) { }

    public EmployerFeedbackStrengthsPage StartNow()
    {
        formCompletionHelper.ClickElement(StartButton);
        return new (context);
    }
}