namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;


public class ApprenticeFeedbackHomePage(ScenarioContext context) : ApprenticeOverviewPage(context, false)
{
    public ApprenticeFeedbackSelectProviderPage GiveFeedbackOnYourTrainingProvider()
    {
        formCompletionHelper.Click(FeedbackLink);
        return new(context);
    }
}
