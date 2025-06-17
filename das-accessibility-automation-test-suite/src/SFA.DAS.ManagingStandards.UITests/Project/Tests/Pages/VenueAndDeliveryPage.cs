namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class VenueAndDeliveryPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Venue and delivery";

    private static By ChooseVenue => By.Id("TrainingVenueNavigationId");
    private static By DayRelease => By.Id("HasDayReleaseDeliveryOption");
    private static By BlockRelease => By.Id("HasBlockReleaseDeliveryOption");

    public TrainingVenuesPage ChooseTheVenueDeliveryAndContinue()
    {
        formCompletionHelper.SelectFromDropDownByText(ChooseVenue, "CENTRAL HAIR ESSEX");
        formCompletionHelper.SelectCheckbox(DayRelease);
        formCompletionHelper.SelectCheckbox(BlockRelease);
        Continue();
        return new TrainingVenuesPage(context);
    }
}
