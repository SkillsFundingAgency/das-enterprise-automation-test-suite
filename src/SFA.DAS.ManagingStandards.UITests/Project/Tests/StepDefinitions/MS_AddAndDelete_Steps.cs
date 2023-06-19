namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions;

[Binding]
public class MS_AddAndDelete_Steps
{
    private readonly ScenarioContext _context;
    
    private string StandardName;

    public MS_AddAndDelete_Steps(ScenarioContext context) => _context = context;

    [When(@"the provider is able to add the standard delivered in one of the training locations")]
    public void WhenTheProviderIsAbleToAddTheStandardDeliveredInOneOfTheTrainingLocations()
    {
        StandardName = _context.Get<ManagingStandardsDataHelpers>().Standard_ActuaryLevel7;

        new ManagingStandardsProviderHomePage(_context)
           .NavigateToYourStandardsAndTrainingVenuesPage()
           .AccessStandards()
           .AccessAddStandard()
           .SelectAStandardAndContinue(StandardName)
           .YesStandardIsCorrectAndContinue()
           .Add_ContactInformation()
           .ConfirmAtOneofYourTrainingLocations_AddStandard()
           .AccessSeeANewTrainingVenue_AddStandard()
           .ChooseTheVenueDeliveryAndContinue()
           .Save_NewTrainingVenue_Continue(StandardName)
           .Save_NewStandard_Continue();
    }

    [When(@"the provider is able to delete the standard")]
    public void WhenTheProviderIsAbleToDeleteTheStandard()
    {
        new ManageTheStandardsYouDeliverPage(_context)
            .AccessActuaryLevel7(StandardName)
            .ClickDeleteAStandard()
            .DeleteStandard();
    }
}
