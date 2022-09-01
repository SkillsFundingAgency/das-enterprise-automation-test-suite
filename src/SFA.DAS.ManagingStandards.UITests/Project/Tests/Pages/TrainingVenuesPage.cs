namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class TrainingVenuesPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Training venues";

    public TrainingVenuesPage(ScenarioContext context) : base(context) { }

    public YourStandardsAndTrainingVenuesPage NavigateBackToReviewYourDetails()
    {
        formCompletionHelper.Click(BackLink);
        return new YourStandardsAndTrainingVenuesPage(context);
    }

    public PostcodePage AccessAddANewTrainingVenue()
    {
        formCompletionHelper.ClickLinkByText("Add a new training venue");
        return new PostcodePage(context);
    }
}
