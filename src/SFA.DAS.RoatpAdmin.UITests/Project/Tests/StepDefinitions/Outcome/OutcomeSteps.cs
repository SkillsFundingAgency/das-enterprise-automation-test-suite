using SFA.DAS.EsfaAdmin.Service.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
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
        private readonly RestartWebDriverHelper _restartWebDriverHelper;
        private readonly RoatpAdminLoginStepsHelper _loginStepsHelper;

        public OutcomeSteps(ScenarioContext context)
        { 
            _context = context;
            _tabhelper = _context.Get<TabHelper>();
            _restartWebDriverHelper = new RestartWebDriverHelper(context);
            _loginStepsHelper = new RoatpAdminLoginStepsHelper(context);
        }

        [Given(@"the admin navigates to the Dashboard")]
        [Then(@"the admin navigates to the Dashboard")]
        public void TheAdminNavigatesToTheDashboard()
        {
            RestartRoatpAdmin("RoATPAdmin");
            _loginStepsHelper.SubmitValidLoginDetails();
        }

        [Then(@"the appeal manager approves the appeal as SUCCESSFUl Already Active")]
        public void ThenTheAppealManagerApprovesTheAppealAsSUCCESSFUlAlreadyActive()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealTab()
                .MakeApplicationSuccessfulAlreadyActive_Appeal().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the appeal manager approves the appeal as SUCCESSFUl")]
        public void ThenTheAppealManagerApprovesTheAppealAsSUCCESSFUl()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealTab()
                .MakeApplicationSuccessful_Appeal().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the appeal manager approves the appeal as UNSUCCESSFUl")]
        public void ThenTheAppealManagerApprovesTheAppealAsUNSUCCESSFUl()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealTab()
                .MakeApplicationUnSuccessful_Appeal().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the appeal manager approves the in progress appeal as UNSUCCESSFUl")]
        public void ThenTheAppealManagerApprovesTheInProgressAppealAsUNSUCCESSFUl()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealOutcomeTab()
                .MakeApplicationUnSuccessful_Appeal().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the appeal manager approves the in progress appeal as SUCCESSFUl Already Active")]
        public void ThenTheAppealManagerApprovesTheInProgressAppealAsSUCCESSFUlAlreadyActive ()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealOutcomeTab()
                .MakeApplicationSuccessfulAlreadyActive_Appeal().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the appeal manager approves the in progress appeal as SUCCESSFUl Fitness For Funding")]
        public void ThenTheAppealManagerApprovesTheInProgressAppealAsSUCCESSFUlFitnessForFunding()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealOutcomeTab()
                .MakeApplicationSuccessfulFitnessForFunding_Appeal().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the appeal manager approves the in progress appeal as SUCCESSFUl")]
        public void ThenTheAppealManagerApprovesTheInProgressAppealAsSUCCESSFUl()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealOutcomeTab()
                .MakeApplicationSuccessful_Appeal().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the appeal manager approves the appeal as INPROGRESS")]
        public void ThenTheAppealManagerApprovesTheAppealAsINPROGRESS()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealTab()
                .MakeApplicationInProgress_Appeal().SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Given(@"the application with (PASS|IN PROGRESS|UNSUCCESSFUL|FAIL) outcome is ready to be assessed")]
        [Then(@"the application with (PASS|IN PROGRESS|UNSUCCESSFUL|FAIL) outcome is ready to be assessed")]
        public void ApplicationIsReadyToBeAssessed(string expectedStatus) => SelectApplication(expectedStatus);

        [Then(@"Verify the application is transitioned to Oversight Outcome tab with (REJECTED|REMOVED|UNSUCCESSFUL|SUCCESSFUL|IN PROGRESS) status")]
        public void VerifyTheApplicationOversightStatus(string expectedStatus) => VerifyOverallOutcomeStatus(expectedStatus);

        [Then(@"Verify the application is transitioned to Appeal Outcome tab with (SUCCESSFUL|IN PROGRESS|UNSUCCESSFUL) status")]
        public void ThenVerifyTheApplicationIsTransitionedToAppealOutcomeTab(string expectedStatus) => VerifyAppealOverallOutcomeStatus(expectedStatus);

        [Given(@"verify that the admin can send the application outcome as (REMOVED|UNSUCCESSFUL) to the applicant")]
        [Then(@"verify that the admin can send the application outcome as (REMOVED|UNSUCCESSFUL) to the applicant")]
        public void ThenVerifyThatTheAdminCanSendTheOutcome(string expectedStatus)
        {
            SelectApplication(expectedStatus == "UNSUCCESSFUL" ? "FAIL" : expectedStatus);

            _applicationSummaryPage.SendOutcomeToTheApplicant(expectedStatus).GoToRoATPAssessorApplicationsPage();

            VerifyOverallOutcomeStatus(expectedStatus);
        }

        [When(@"the oversight user selects the overall application outcome as Successful")]
        [Then(@"the oversight user selects the overall application outcome as Successful")]
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
        [Given(@"the oversight user selects the overall application outcome as Unsuccessful")]
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
        [Then(@"the oversight user selects the overall application outcome as Successful fitness for funding")]
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

        private OversightLandingPage SelectApplicationOversights_WithoutStatus_AppealsTab()
        {
            _staffDashboardPage = new StaffDashboardPage(_context);
            _applicationSummaryPage = _staffDashboardPage.AccessOversightApplications().SelectApplication_AppealTab();
            return new OversightLandingPage(_context);
        }

        private void VerifyOverallOutcomeStatus(string expectedStatus) => new OversightLandingPage(_context).VerifyOverallOutcomeStatus(expectedStatus);
        private void VerifyAppealOverallOutcomeStatus(string expectedStatus) => new OversightLandingPage(_context).VerifyApplicationsAppealOutcomeStatus(expectedStatus);

        private OversightLandingPage ConfirmApplicationOutcome(AreYouSureAboutApplicationOutcomePage areYouSureSuccessfullPage)
        {
            return areYouSureSuccessfullPage.SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        private void RestartWebDriver(string url, string applicationName) => _restartWebDriverHelper.RestartWebDriver(url, applicationName);
        private void RestartRoatpAdmin(string applicationName) => RestartWebDriver(UrlConfig.Admin_BaseUrl, applicationName);
    }
}
