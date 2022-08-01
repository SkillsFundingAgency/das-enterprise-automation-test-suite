namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class TrainingVenuesPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Training venues";

    public TrainingVenuesPage(ScenarioContext context) : base(context) { }

    public ReviewYourDetailsPage NavigateBackToReviewYourDetails()
    {
        formCompletionHelper.Click(BackLink);
        return new ReviewYourDetailsPage(context);
    }
}
