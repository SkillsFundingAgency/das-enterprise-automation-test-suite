using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Outcome
{
    [Binding]
    public class OutcomeSteps
    {
        private readonly ScenarioContext _context;
        private StaffDashboardPage _staffDashboardPage;
        private ApplicationSummaryPage _applicationSummaryPage;
        private readonly TabHelper _tabhelper;

        public OutcomeSteps(ScenarioContext context)
        { 
            _context = context;
            _tabhelper = _context.Get<TabHelper>();
        }

        [Then(@"Oversight user is able to send the application to Appeal Status")]
        public void ThenOversightUserIsAbleToSendTheApplicationToAppealStatus()
        {
            
        }

        [Given(@"the admin navigates to the Dashboard")]
        public void TheAdminNavigatesToTheDashboard() => _tabhelper.GoToUrl(UrlConfig.Admin_BaseUrl, "dashboard");

        [Given(@"the application with (PASS|IN PROGRESS) outcome is ready to be assessed")]
        public void ApplicationIsReadyToBeAssessed(string expectedStatus) => SelectApplication(expectedStatus);

        [Then(@"Verify the application is transitioned to Oversight Outcome tab with (REJECTED|REMOVED|UNSUCCESSFUL|SUCCESSFUL|IN PROGRESS) status")]
        public void VerifyTheApplicationOversightStatus(string expectedStatus) => VerifyOverallOutcomeStatus(expectedStatus);

        [Then(@"verify that the admin can send the application outcome as (REMOVED|UNSUCCESSFUL) to the applicant")]
        public void ThenVerifyThatTheAdminCanSendTheOutcome(string expectedStatus)
        {
            SelectApplication(expectedStatus == "UNSUCCESSFUL" ? "FAIL" : expectedStatus);

            _applicationSummaryPage.SendOutcomeToTheApplicant(expectedStatus).GoToRoATPAssessorApplicationsPage();

            VerifyOverallOutcomeStatus(expectedStatus);
        }

        [When(@"the oversight user selects the overall application outcome as Successful")]
        public void WhenTheOversightUserSelectsTheOverallApplicationOutcomeAsSuccessful()
        {
            ConfirmApplicationOutcome(_applicationSummaryPage.MakeApplicationSuccessful());
        }

        [When(@"the oversight user overturns gateway and moderation outcome")]
        public void WhenTheOversightUserOverturnsGatewayAndModerationOutcome()
        {
            _applicationSummaryPage =  _applicationSummaryPage.OverTurnThisApplication(); 
        }

        [When(@"the oversight user selects the overall application outcome as Unsuccessful")]
        public void WhenTheOversightUserSelectsTheOverallApplicationOutcomeAsUnsuccessful()
        {
            ConfirmApplicationOutcome(_applicationSummaryPage.MakeApplicationUnSuccessful());
        }

        [When(@"the oversight user selects the overall application outcome as In Progress")]
        public void WhenTheOversightUserSelectsTheOverallApplicationOutcomeAsInProgress()
        {
            ConfirmApplicationOutcome(_applicationSummaryPage.MakeApplicationInProgress());
        }

        [When(@"the oversight user selects the overall application outcome as Successful already active")]
        public void WhenTheOversightUserSelectsTheOverallApplicationOutcomeAsSuccessfulAlreadyActive()
        {
            ConfirmApplicationOutcome(_applicationSummaryPage.MakeApplicationSuccessfulAlreadyActive());
        }

        [When(@"the oversight user selects the overall application outcome as Successful fitness for funding")]
        public void WhenTheOversightUserSelectsTheOverallApplicationOutcomeAsSuccessfulFitnessForFunding()
        {
            ConfirmApplicationOutcome(_applicationSummaryPage.MakeApplicationSuccessfulFitnessForFunding());
        }

        [Then(@"verify the provider is added to the register with status of Onboarding")]
        public void ThenVerifyTheProviderIsAddedToTheRegisterWithStatusOfOnboarding()
        {
            var resultPage = new StaffDashboardPage(_context, true)
                .SearchForATrainingProvider()
                .SearchTrainingProviderByUkprn();

            resultPage.VerifyOneProviderUkprnResultFound();

            resultPage.VerifyProviderStatusAsOnBoarding();
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

        private void ConfirmApplicationOutcome(AreYouSureAboutApplicationOutcomePage areYouSureSuccessfullPage)
        {
            areYouSureSuccessfullPage.SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }
    }
}
