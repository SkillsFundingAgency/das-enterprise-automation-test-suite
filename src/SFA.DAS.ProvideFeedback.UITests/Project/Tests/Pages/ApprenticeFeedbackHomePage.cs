namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;


public class ApprenticeFeedbackHomePage : ApprenticeOverviewPage
{
    public ApprenticeFeedbackHomePage(ScenarioContext context) : base(context, false) { }

    public ApprenticeFeedbackSelectProviderPage GiveFeedbackOnYourTrainingProvider()
    {
        formCompletionHelper.Click(FeedbackLink);
        return new (context);
    }
}
