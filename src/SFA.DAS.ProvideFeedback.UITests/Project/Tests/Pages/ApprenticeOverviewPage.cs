namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class SelectATrainingProviderPage
{
    public SelectATrainingProviderPage(ScenarioContext context)
    {

    }
}


public class ApprenticeOverview_FeedbackPage : ApprenticeOverviewPage
{
    public ApprenticeOverview_FeedbackPage(ScenarioContext context) : base(context) { }

    public void GiveFeedbackOnYourTrainingProvider()
    {
        formCompletionHelper.Click(FeedbackLink);
    }
}
