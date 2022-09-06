namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class AddVenueDetailsPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Add venue details";

    private static By VenueNameTextBox => By.Id("LocationName");
    private static By TelephoneNumberTextBox => By.Id("PhoneNumber");
    private static By EmailAddressTextBox => By.Id("EmailAddress");
    private static By WebsiteTextBox => By.Id("Website");
    private static By SaveAndContinueButton => By.Id("submit");

    public AddVenueDetailsPage(ScenarioContext context) : base(context)
    {
    }

    public TrainingVenuesPage AddVenueDetailsAndSubmit()
    {
        formCompletionHelper.EnterText(VenueNameTextBox, managingStandardsDataHelpers.VenueName);
        formCompletionHelper.EnterText(WebsiteTextBox, managingStandardsDataHelpers.ContactWebsite);
        formCompletionHelper.EnterText(EmailAddressTextBox, managingStandardsDataHelpers.EmailAddress);
        formCompletionHelper.EnterText(TelephoneNumberTextBox, managingStandardsDataHelpers.ContactNumber);
        formCompletionHelper.Click(SaveAndContinueButton);
        return new TrainingVenuesPage(context);
    }
}
