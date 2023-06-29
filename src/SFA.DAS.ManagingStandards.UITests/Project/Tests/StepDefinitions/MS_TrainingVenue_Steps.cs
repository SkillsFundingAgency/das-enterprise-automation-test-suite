namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions;

[Binding]
public class MS_TrainingVenue_Steps
{
    private readonly ScenarioContext _context;

    public MS_TrainingVenue_Steps(ScenarioContext context) => _context = context;

    [Then(@"the provider is able to add a new training venue")]
    public void ThenTheProviderIsAbleToAddANewTrainingVenue()
    {
        new ManagingStandardsProviderHomePage(_context)
            .NavigateToYourStandardsAndTrainingVenuesPage()
            .AccessTrainingLocations()
            .AccessAddANewTrainingVenue()
            .EnterPostcodeAndContinue()
            .ChooseTheAddressAndContinue()
            .AddVenueDetailsAndSubmit();
    }

    [Then(@"the provider is able to update the new training venuw")]
    public void ThenTheProviderIsAbleToUpdateTheNewTrainingVenuw()
    {
        new TrainingVenuesPage(_context)
            .AccessNewTrainingVenue_Added()
            .Click_UpdateContactDetails()
            .UpdateVenueDetailsAndSubmit();
    }
}