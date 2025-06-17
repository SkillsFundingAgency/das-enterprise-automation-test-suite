namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class TrainingProviderOverviewPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Your training provider overview";

    public YourStandardsAndTrainingVenuesPage NavigateBackToReviewYourDetails()
    {
        formCompletionHelper.Click(BackLink);
        return new YourStandardsAndTrainingVenuesPage(context);
    }

}
