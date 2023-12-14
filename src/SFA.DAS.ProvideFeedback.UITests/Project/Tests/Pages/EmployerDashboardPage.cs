namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerDashboardPage : EmployerFeedbackBasePage
{
    protected override string PageTitle => "PRO LIMITED";

    public EmployerDashboardPage(ScenarioContext context) : base(context) { }

    public EmployerFeedbackSelectProviderPage ClickFeedbackLink()
    {
        formCompletionHelper.ClickLinkByText("Feedback on training providers");
        return new(context);
    }

    public EmployerFeedbackHomePage OpenFeedbackLinkWithSurveyCode()
    {
        OpenFeedbackUsingSurveyCode();

        return new(context);
    }
}
