namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class TrainingVenuesPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Training venues";

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
    public VenueAndDeliveryPage AccessSeeTrainingVenue()
    {
        formCompletionHelper.ClickLinkByText("See training venues");
        return new VenueAndDeliveryPage(context);
    }
    public ManageAStandard_TeacherPage NavigateBackToStandardPage()
    {
        formCompletionHelper.Click(BackLink);
        return new ManageAStandard_TeacherPage(context);
    }
    public AddAstandardPage Save_NewTrainingVenue_Continue(string standardname)
    {
        Continue();
        return new AddAstandardPage(context, standardname);
    }
    public VenueAndDeliveryPage AccessSeeANewTrainingVenue_AddStandard()
    {
        formCompletionHelper.ClickLinkByText("See training venues");
        return new VenueAndDeliveryPage(context);
    }
}
