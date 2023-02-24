namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions;

[Binding]
public class MS_YourDetails_Steps
{
    private readonly ScenarioContext _context;

    public MS_YourDetails_Steps(ScenarioContext context) => _context = context;

    [Given(@"the provider logs into employer portal")]
    public void GivenTheProviderLogsIntoEmployerPortal() => new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(false);

    [When(@"the provider navigates to Review your details")]
    public void WhenTheProviderNavigatesToReviewYourDetails()
    {
        StepsHelper stepsHelper = new(_context);
        stepsHelper.NavigateToReviewYourDetails();
    }

    [Then(@"the provider verifies organisation details")]
    public void ThenTheProviderVerifiesOrganisationDetails()
    {
        YourStandardsAndTrainingVenuesPage reviewYourDetailsPage = new(_context);
        reviewYourDetailsPage.AccessTrainingLocations()
            .NavigateBackToReviewYourDetails()
            .AccessStandards();
    }

    [Then(@"the provider verifies provider overview")]
    public void ThenTheProviderVerifiesProviderOverview()
    {
        ManageTheStandardsYouDeliverPage manageTheStandardsYouDeliverPage = new(_context);
        manageTheStandardsYouDeliverPage
            .ReturnToYourStandardsAndTrainingVenues()
            .AccessProviderOverview()
            .NavigateBackToReviewYourDetails()
            .AccessStandards();
    }


    [Then(@"the provider updates contact details")]
    public void ThenTheProviderUpdatesContactDetails()
    {
        ManageTheStandardsYouDeliverPage manageTheStandardsYouDeliverPage = new(_context);
        manageTheStandardsYouDeliverPage
            .AccessTeacherLevel6()
            .UpdateTheseContactDetails()
            .UpdateContactInformation();
    }

    [When(@"the provider is able to approve regulated standard")]
    public void WhenTheProviderIsAbleToApproveRegulatedStandard()
    {
        YourStandardsAndTrainingVenuesPage reviewYourDetailsPage = new(_context);
        reviewYourDetailsPage.AccessStandards()
            .AccessRegulatorApprovalLinkFromTheSTandardsTable()
            .ApproveStandard_FromStandardsPage()
            .AccessTeacherLevel6();
    }

    [Then(@"the provider is able to disapprove regulated standard")]
    public void ThenTheProviderIsAbleToDisapproveRegulatedStandard()
    {
        ManageAStandard_TeacherPage manageAStandard_TeacherPage = new(_context);
        manageAStandard_TeacherPage.AccessApprovedByRegulationOrNot()
            .DisApproveStandard()
            .ContinueToTeacher_ManageStandardPage();
    }

    [When(@"the provider is able to change the standard delivered in one of the training locations")]
    public void WhenTheProviderIsAbleToChangeTheStandardDeliveredInOneOfTheTrainingLocations()
    {

        ManageAStandard_TeacherPage manageAStandard_TeacherPage = new(_context);
        manageAStandard_TeacherPage.AccessWhereYouWillDeliverThisStandard()
            .ConfirmAtOneofYourTrainingLocations()
            .ConfirmVenueDetailsAndDeliveryMethod_AtOneOFYourTrainingLocation();
    }

    [When(@"the provider is able to add the training locations")]
    public void WhenTheProviderIsAbleToAddTheTrainingLocations()
    {
        ManageAStandard_TeacherPage manageAStandard_TeacherPage = new(_context);
        manageAStandard_TeacherPage.AccessEditTrainingLocations()
            .AccessSeeTrainingVenue()
            .ChooseTheVenueDeliveryAndContinue()
            .NavigateBackToStandardPage();
    }


    [When(@"the provider is able to change the standard delivered at an employers location national provider")]
    public void WhenTheProviderIsAbleToChangeTheStandardDeliveredAtAnEmployersLocationNationalProvider()
    {

        ManageAStandard_TeacherPage manageAStandard_TeacherPage = new(_context);
        manageAStandard_TeacherPage.AccessWhereYouWillDeliverThisStandard()
            .ConfirmAtAnEmployersLocation()
            .YesDeliverAnyWhereInEngland();
    }

    [When(@"the provider is able to change the standard delivered in both not a national provider")]
    public void WhenTheProviderIsAbleToChangeTheStandardDeliveredInBothNotANationalProvider()
    {
        YourStandardsAndTrainingVenuesPage reviewYourDetailsPage = new(_context);
        reviewYourDetailsPage.AccessStandards()
            .AccessTeacherLevel6()
            .AccessWhereYouWillDeliverThisStandard()
            .ConfirmStandardWillDeliveredInBoth()
            .ConfirmVenueDetailsAndDeliveryMethod_AtBoth()
            .NoDeliverAnyWhereInEngland()
            .SelectDerbyRutlandRegionsAndConfirm();
    }

    [When(@"the provider is able to add the standard delivered in one of the training locations")]
    public void WhenTheProviderIsAbleToAddTheStandardDeliveredInOneOfTheTrainingLocations()
    {
        YourStandardsAndTrainingVenuesPage reviewYourDetailsPage = new(_context);
        reviewYourDetailsPage.AccessStandards()
            .AccessAddStandard()
            .SelectActuaryAndContinue()
            .YesStandardIsCorrectAndContinue()
            .Add_ContactInformation()
            .ConfirmAtOneofYourTrainingLocations_AddStandard()
            .AccessSeeANewTrainingVenue_AddStandard()
            .ChooseTheVenueDeliveryAndContinue()
            .Save_NewTrainingVenue_Continue()
            .Save_NewStandard_Continue();
    }

    [When(@"the provider is able to delete the standard")]
    public void WhenTheProviderIsAbleToDeleteTheStandard()
    {
        ManageTheStandardsYouDeliverPage manageTheStandardsYouDeliverPage = new ManageTheStandardsYouDeliverPage(_context);
        manageTheStandardsYouDeliverPage.AccessActuaryLevel7()
            .ClickDeleteAStandard()
            .DeleteStandard();
    }

    [When(@"the provider is able to edit the regions")]
    public void WhenTheProviderIsAbleToEditTheRegions()
    {
        ManageAStandard_TeacherPage manageAStandard_TeacherPage = new(_context);
        manageAStandard_TeacherPage.AccessWhereYouWillDeliverThisStandard()
            .ConfirmAtAnEmployersLocation()
            .NoDeliverAnyWhereInEngland()
            .SelectDerbyRutlandRegionsAndConfirm()
            .AccessEditTheseRegions()
            .EditRegionsAddLutonEssexAndConfirm();
    }

    [Then(@"the provider is able to add a new training venue")]
    public void ThenTheProviderIsAbleToAddANewTrainingVenue()
    {
       
        YourStandardsAndTrainingVenuesPage reviewYourDetailsPage = new(_context);
        reviewYourDetailsPage.AccessTrainingLocations()
            .AccessAddANewTrainingVenue()
            .EnterPostcodeAndContinue()
            .ChooseTheAddressAndContinue()
            .AddVenueDetailsAndSubmit(); 
    }

    [Then(@"the provider is able to update the new training venuw")]
    public void ThenTheProviderIsAbleToUpdateTheNewTrainingVenuw()
    {
        TrainingVenuesPage trainingVenuesPage = new(_context);
        trainingVenuesPage
            .AccessNewTrainingVenue_Added()
            .Click_UpdateContactDetails()
            .UpdateVenueDetailsAndSubmit();
    }
}
