namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class VenueAndDeliveryPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Venue and delivery";

    private By ChooseVenue = By.Id("TrainingVenueNavigationId");
    private By DayRelease = By.Id("HasDayReleaseDeliveryOption");
    private By BlockRelease = By.Id("HasBlockReleaseDeliveryOption");
    public VenueAndDeliveryPage(ScenarioContext context) : base(context) { }

    public TrainingVenuesPage ChooseTheVenueDeliveryAndContinue()
    {
        formCompletionHelper.SelectFromDropDownByText(ChooseVenue, "CENTRAL HAIR ESSEX");
        formCompletionHelper.SelectCheckbox(DayRelease);
        formCompletionHelper.SelectCheckbox(BlockRelease);
        Continue();
        return new TrainingVenuesPage(context);
    }
}
