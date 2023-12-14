namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerDashboardPage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "PRO LIMITED";

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
