namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class VenueAddedPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Test Demo Automation Venue";
    public VenueAddedPage(ScenarioContext context) : base(context) { }

    public VenueDetailsPage Click_UpdateContactDetails()
    {
        formCompletionHelper.ClickLinkByText("Update contact details");
        return new VenueDetailsPage(context);
    }
}
