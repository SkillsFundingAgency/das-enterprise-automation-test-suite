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

        [Given(@"the application is ready to be assessed")]
        public void GivenApplicationIsReadyToBeAssessed()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);

            _applicationSummaryPage = _staffDashboardPage.AccessOversightApplications().SelectApplication();
        }

        [When(@"the oversight user approves gateway and moderation outcome")]
        public void WhenTheOversightUserApprovesGatewayAndModerationOutcome()
        {
            _staffDashboardPage = _applicationSummaryPage
                .ApproveOverallOutcome()
                .SelectYesAskAndContinueOutcomePage()
                .GoToRoATPAssessorApplicationsPage()
                .VerifyOutcomeStatus("SUCCESSFUL")
                .ClickReturnToStaffDashBoard();
        }

        [Then(@"verify the provider is added to the register with status of Onboarding")]
        public void ThenVerifyTheProviderIsAddedToTheRegisterWithStatusOfOnboarding()
        {
            var resultPage = _staffDashboardPage.SearchForATrainingProvider()
                .SearchTrainingProviderByUkprn();

            resultPage.VerifyOneProviderUkprnResultFound();

            resultPage.VerifyMainAndEmployerTypeStatus();
        }
    }
}
