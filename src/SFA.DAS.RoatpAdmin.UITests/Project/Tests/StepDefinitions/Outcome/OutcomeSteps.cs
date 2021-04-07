using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Outcome
{
    [Binding]
    public class OutcomeSteps
    {
        private readonly ScenarioContext _context;
        private StaffDashboardPage _staffDashboardPage;
        private ApplicationSummaryPage _applicationSummaryPage;
        
        public OutcomeSteps(ScenarioContext context) => _context = context;

        [Given(@"the application with (PASS) outcome is ready to be assessed")]
        public void ApplicationIsReadyToBeAssessed(string expectedStatus) => SelectApplication(expectedStatus);

        [Then(@"Verify the application is transitioned to Oversight Outcome tab with (REJECTED|REMOVED|UNSUCCESSFUL|SUCCESSFUL) status")]
        public void VerifyTheApplicationOversightStatus(string expectedStatus) => VerifyOverallOutcomeStatus(expectedStatus);

        [Then(@"verify that the admin can send the application outcome as (REMOVED|UNSUCCESSFUL) to the applicant")]
        public void ThenVerifyThatTheAdminCanSendTheOutcome(string expectedStatus)
        {
            SelectApplication(expectedStatus == "UNSUCCESSFUL" ? "FAIL" : expectedStatus);

            _applicationSummaryPage.SendOutcomeToTheApplicant(expectedStatus).GoToRoATPAssessorApplicationsPage();

            VerifyOverallOutcomeStatus(expectedStatus);
        }

        [When(@"the oversight user approves gateway and moderation outcome")]
        public void WhenTheOversightUserApprovesGatewayAndModerationOutcome()
        {
            _applicationSummaryPage
                .ApproveOverallOutcome()
                .SelectYesAskAndContinueOutcomePage()
                .GoToRoATPAssessorApplicationsPage();
        }

        [When(@"the oversight user overturns gateway and moderation outcome")]
        public void WhenTheOversightUserOverturnsGatewayAndModerationOutcome()
        {
            _applicationSummaryPage =  _applicationSummaryPage.OverTurnThisApplication(); 
        }

        [When(@"the oversight user selects the overall application outcome as Unsuccessful")]
        public void WhenTheOversightUserSelectsTheOverallApplicationOutcomeAsUnsuccessful()
        {
            _applicationSummaryPage.MakeApplicationUnSuccessfull().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"verify the provider is added to the register with status of Onboarding")]
        public void ThenVerifyTheProviderIsAddedToTheRegisterWithStatusOfOnboarding()
        {
            var resultPage = new StaffDashboardPage(_context, true)
                .SearchForATrainingProvider()
                .SearchTrainingProviderByUkprn();

            resultPage.VerifyOneProviderUkprnResultFound();

            resultPage.VerifyMainAndEmployerTypeStatus();
        }

        [Then(@"verify the provider is not added to the register")]
        public void ThenVerifyTheProviderIsNotAddedToTheRegister()
        {
            new StaffDashboardPage(_context, true).SearchForATrainingProvider().SearchTrainingProviderByUkprn().VerifyNoProviderUkprnResultFound();
        }

        private void SelectApplication(string expectedStatus)
        {
            _staffDashboardPage = new StaffDashboardPage(_context, true);

            _applicationSummaryPage = _staffDashboardPage.AccessOversightApplications().SelectApplication(expectedStatus);
        }

        private void VerifyOverallOutcomeStatus(string expectedStatus) => new OversightLandingPage(_context).VerifyOverallOutcomeStatus(expectedStatus);

    }
}
