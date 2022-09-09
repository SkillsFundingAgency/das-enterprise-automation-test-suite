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
    public VenueAddedPage AccessNewTrainingVenue_Added()
    {
        formCompletionHelper.ClickLinkByText("Test Demo Automation Venue");
        return new VenueAddedPage(context);
    }
    public VenueAndDeliveryPage AccessAddTrainingVenue()
    {
        formCompletionHelper.ClickLinkByText("Add training venue");
        return new VenueAndDeliveryPage(context);
    }
    public ManageAStandard_TeacherPage NavigateBackToStandardPage()
    {
        formCompletionHelper.Click(BackLink);
        return new ManageAStandard_TeacherPage(context);
    }
    public AddAstandard_ActuaryPage Save_NewTrainingVenue_Continue()
    {
        Continue();
        return new AddAstandard_ActuaryPage(context);
    }
}
