namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class VenueAddedPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Test Demo Automation Venue";

    public VenueDetailsPage Click_UpdateContactDetails()
    {
        formCompletionHelper.ClickLinkByText("Update contact details");
        return new VenueDetailsPage(context);
    }
}
