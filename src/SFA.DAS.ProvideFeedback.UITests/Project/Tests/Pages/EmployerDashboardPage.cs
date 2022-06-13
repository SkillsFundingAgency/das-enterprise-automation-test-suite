namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerDashboardPage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "PRO LIMITED";

    public EmployerDashboardPage(ScenarioContext context) : base(context) { }

    public SelectTrainingProviderPage ClickFeedbackLink()
    {
        formCompletionHelper.ClickLinkByText("Feedback on training providers");
        return new (context);
    }

    public ProvideFeedbackHomePage OpenFeedbackLinkWithSurveyCode()
    {
        OpenFeedbackUsingSurveyCode();

        return new (context);
    }
}
