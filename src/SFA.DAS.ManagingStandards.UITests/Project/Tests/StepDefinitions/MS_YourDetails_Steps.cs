using SFA.DAS.ProviderLogin.Service.Project.Helpers;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions;

[Binding]
public class MS_YourDetails_Steps
{
    private readonly ScenarioContext _context;

    public MS_YourDetails_Steps(ScenarioContext context) => _context = context;

    [Given(@"the provider logs into portal")]
    public void GivenTheProviderLogsIntoPortal() => new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(false);

    [Then(@"the provider verifies organisation details")]
    public void ThenTheProviderVerifiesOrganisationDetails()
    {
        new ManagingStandardsProviderHomePage(_context)
            .NavigateToYourStandardsAndTrainingVenuesPage()
            .AccessTrainingLocations()
            .NavigateBackToReviewYourDetails()
            .AccessStandards();
    }

    [Then(@"the provider verifies provider overview")]
    public void ThenTheProviderVerifiesProviderOverview()
    {
        new ManageTheStandardsYouDeliverPage(_context)
            .ReturnToYourStandardsAndTrainingVenues()
            .AccessProviderOverview()
            .NavigateBackToReviewYourDetails()
            .AccessStandards();
    }

    [Then(@"the provider updates contact details")]
    public void ThenTheProviderUpdatesContactDetails()
    {
        new ManageTheStandardsYouDeliverPage(_context)
            .AccessTeacherLevel6()
            .UpdateTheseContactDetails()
            .UpdateContactInformation();
    }

    [When(@"the provider is able to approve regulated standard")]
    public void WhenTheProviderIsAbleToApproveRegulatedStandard()
    {
        new ManagingStandardsProviderHomePage(_context)
            .NavigateToYourStandardsAndTrainingVenuesPage()
            .AccessStandards()
            .AccessRegulatorApprovalLinkFromTheSTandardsTable()
            .ApproveStandard_FromStandardsPage()
            .AccessTeacherLevel6();
    }

    [Then(@"the provider is able to disapprove regulated standard")]
    public void ThenTheProviderIsAbleToDisapproveRegulatedStandard()
    {
        new ManageAStandard_TeacherPage(_context)
            .AccessApprovedByRegulationOrNot()
            .DisApproveStandard()
            .ContinueToTeacher_ManageStandardPage();
    }

    [When(@"the provider is able to change the standard delivered in one of the training locations")]
    public void WhenTheProviderIsAbleToChangeTheStandardDeliveredInOneOfTheTrainingLocations()
    {

        new ManageAStandard_TeacherPage(_context)
            .AccessWhereYouWillDeliverThisStandard()
            .ConfirmAtOneofYourTrainingLocations()
            .ConfirmVenueDetailsAndDeliveryMethod_AtOneOFYourTrainingLocation();
    }

    [When(@"the provider is able to add the training locations")]
    public void WhenTheProviderIsAbleToAddTheTrainingLocations()
    {
        new ManageAStandard_TeacherPage(_context)
            .AccessEditTrainingLocations()
            .AccessSeeTrainingVenue()
            .ChooseTheVenueDeliveryAndContinue()
            .NavigateBackToStandardPage();
    }


    [When(@"the provider is able to change the standard delivered at an employers location national provider")]
    public void WhenTheProviderIsAbleToChangeTheStandardDeliveredAtAnEmployersLocationNationalProvider()
    {

        new ManageAStandard_TeacherPage(_context)
            .AccessWhereYouWillDeliverThisStandard()
            .ConfirmAtAnEmployersLocation()
            .YesDeliverAnyWhereInEngland();
    }

    [When(@"the provider is able to change the standard delivered in both not a national provider")]
    public void WhenTheProviderIsAbleToChangeTheStandardDeliveredInBothNotANationalProvider()
    {
        new ManagingStandardsProviderHomePage(_context)
            .NavigateToYourStandardsAndTrainingVenuesPage()
            .AccessStandards()
            .AccessTeacherLevel6()
            .AccessWhereYouWillDeliverThisStandard()
            .ConfirmStandardWillDeliveredInBoth()
            .ConfirmVenueDetailsAndDeliveryMethod_AtBoth()
            .NoDeliverAnyWhereInEngland()
            .SelectDerbyRutlandRegionsAndConfirm();
    }

    [When(@"the provider is able to edit the regions")]
    public void WhenTheProviderIsAbleToEditTheRegions()
    {
        new ManageAStandard_TeacherPage(_context)
            .AccessWhereYouWillDeliverThisStandard()
            .ConfirmAtAnEmployersLocation()
            .NoDeliverAnyWhereInEngland()
            .SelectDerbyRutlandRegionsAndConfirm()
            .AccessEditTheseRegions()
            .EditRegionsAddLutonEssexAndConfirm();
    }
}
