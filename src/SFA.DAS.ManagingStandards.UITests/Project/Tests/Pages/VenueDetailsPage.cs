namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class VenueDetailsPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Venue details";

    private static By WebsiteTextBox => By.Id("Website");
    private static By SaveAndContinueButton => By.Id("submit");

    public VenueAddedPage UpdateVenueDetailsAndSubmit()
    {
        formCompletionHelper.EnterText(WebsiteTextBox, managingStandardsDataHelpers.UpdatedWebsite);
        formCompletionHelper.Click(SaveAndContinueButton);
        return new VenueAddedPage(context);
    }
}
