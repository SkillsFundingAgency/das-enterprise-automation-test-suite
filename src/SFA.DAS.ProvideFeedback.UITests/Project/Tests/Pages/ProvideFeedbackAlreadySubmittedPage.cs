namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ProvideFeedbackAlreadySubmittedPage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "Feedback already submitted";

    public ProvideFeedbackAlreadySubmittedPage(ScenarioContext context) : base(context, false)
    {
        OpenFeedbackUsingSurveyCode();
        VerifyPage();
    }
}
