namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ChooseTheAddressPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Choose the address";

    private static By AddressFound => By.Id("SelectedAddressUprn");

    public AddVenueDetailsPage ChooseTheAddressAndContinue()
    {
        formCompletionHelper.SelectFromDropDownByValue(AddressFound, "100021525713");
        Continue();
        return new AddVenueDetailsPage(context);
    }
}
