namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class TrainingProviderOverviewPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Your training provider overview";

    public TrainingProviderOverviewPage(ScenarioContext context) : base(context) { }

    public YourStandardsAndTrainingVenuesPage NavigateBackToReviewYourDetails()
    {
        formCompletionHelper.Click(BackLink);
        return new YourStandardsAndTrainingVenuesPage(context);
    }

}
