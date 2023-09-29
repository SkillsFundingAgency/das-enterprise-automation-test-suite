namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ChooseTheAddressPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Choose the address";

    private static By AddressFound => By.Id("SelectedAddressUprn");
    public ChooseTheAddressPage(ScenarioContext context) : base(context) { }

    public AddVenueDetailsPage ChooseTheAddressAndContinue()
    {
        formCompletionHelper.SelectFromDropDownByValue(AddressFound, "100021525713");
        Continue();
        return new AddVenueDetailsPage(context);
    }
}
