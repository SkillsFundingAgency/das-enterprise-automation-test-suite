namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackAlreadySubmittedPage : EmployerFeedbackBasePage
{
    protected override string PageTitle => "Feedback already submitted";

    public EmployerFeedbackAlreadySubmittedPage(ScenarioContext context) : base(context, false)
    {
        OpenFeedbackUsingSurveyCode();
        VerifyPage();
    }
}
