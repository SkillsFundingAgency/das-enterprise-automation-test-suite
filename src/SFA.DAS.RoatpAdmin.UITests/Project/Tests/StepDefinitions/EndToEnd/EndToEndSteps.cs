using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.EndToEnd
{
    [Binding]
    public class EndToEndSteps
    {
        private readonly ScenarioContext _context;
        private readonly RoatpApplyEnd2EndStepsHelper _end2EndStepsHelper;
        private readonly SelectRouteStepsHelper _selectRouteStepsHelper;
        private readonly GatewayEndtoEndStepsHelpers _gatewayEndToEndStepsHelpers;
        private readonly AssessorEndtoEndStepsHelper _assessorEndtoEndStepsHelper;
        private readonly ModeratorEndtoEndStepsHelper _moderatorEndtoEndStepsHelper;
        private readonly RoatpAdminLoginStepsHelper _roatpAdminLoginStepsHelper;
        private readonly AssessorLoginStepsHelper _assessorLoginStepsHelper;
        private readonly RestartWebDriverHelper _restartWebDriverHelper;

        private ApplicationRoute _applicationRoute;

        public EndToEndSteps(ScenarioContext context)
        {
            _context = context;
            _end2EndStepsHelper = new RoatpApplyEnd2EndStepsHelper();
            _roatpAdminLoginStepsHelper = new RoatpAdminLoginStepsHelper(context);
            _assessorLoginStepsHelper = new AssessorLoginStepsHelper(_context);
            _selectRouteStepsHelper = new SelectRouteStepsHelper(context);
            _gatewayEndToEndStepsHelpers = new GatewayEndtoEndStepsHelpers();
            _assessorEndtoEndStepsHelper = new AssessorEndtoEndStepsHelper();
            _moderatorEndtoEndStepsHelper = new ModeratorEndtoEndStepsHelper();
            _restartWebDriverHelper = new RestartWebDriverHelper(context);
        }

        [Given(@"the provider completes the Apply Journey as Main route company")]
        public void GivenTheProviderCompletesTheApplyJourneyAsMainRouteCompany()
        {
            _applicationRoute = ApplicationRoute.MainProviderRoute;

            var overviewPage = _selectRouteStepsHelper.CompleteProviderMainRouteSection();
            overviewPage = _end2EndStepsHelper.CompleteYourOrganisation_Section1(overviewPage);
            overviewPage = _end2EndStepsHelper.CompleteFinancialEvidence_Section2(overviewPage);
            overviewPage = _end2EndStepsHelper.CompletesCriminalAndCompliance_Section3(overviewPage);
            overviewPage = _end2EndStepsHelper.CompletesProtectingYourApprentices_Section4(overviewPage);
            overviewPage = _end2EndStepsHelper.CompletesReadinessToEngage_Section5(overviewPage);
            overviewPage = _end2EndStepsHelper.CompletesPlanningApprenticeshipTraining_Section6(overviewPage);
            overviewPage = _end2EndStepsHelper.CompletesDeliveringApprenticeshipTraining_Section7_MainRoute(overviewPage);
            overviewPage = _end2EndStepsHelper.CompletesEvaluatingApprenticeshipTraining_Section8(overviewPage);
            
            _end2EndStepsHelper.CompletesFinish_Section9(overviewPage);
        }

        [When(@"the GateWay user assess the application by confirming Gateway outcome as Pass")]
        public void WhenTheGateWayUserAssessTheApplicationByConfirmingGatewayOutcomeAsPass()
        {
            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("GatewayAdmin");

            staffDashboardPage.AccessGatewayApplications().SelectApplication();

            var gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_MainRouteCompany((new GWApplicationOverviewPage(_context)));

            _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsPass(gwApplicationOverviewPage);
        }

        [When(@"the Financial user assess the application by confirming Finance outcome as Outstanding")]
        public void WhenTheFinancialUserAssessTheApplicationByConfirmingFinanceOutcomeAsOutstanding()
        {
            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("FinanceAdmin");

            staffDashboardPage.AccessFinancialApplications().SelectNewApplication().ConfirmFHAReviewAsOutstanding();
        }

        [When(@"the Asssesssors assess the application and marks the application as Ready for Moderation")]
        public void WhenTheAsssesssorAndAssessorAssessTheApplicationAndMarksTheApplicationAsReadyForModeration()
        {
            RestartRoatpAssessor("Asssesssor1Admin");

            var assessorApplicationsPage = _assessorLoginStepsHelper.Assessor1Login();

            var applicationAssessmentOverviewPage = assessorApplicationsPage.Assessor1SelectsAssignToMe();

            RoatpAssessor(applicationAssessmentOverviewPage);

            RestartRoatpAssessor("Asssesssor2Admin");

            assessorApplicationsPage = _assessorLoginStepsHelper.Assessor2Login();

            applicationAssessmentOverviewPage = assessorApplicationsPage.Assessor2SelectsAssignToMe();

            RoatpAssessor(applicationAssessmentOverviewPage);
        }

        [Then(@"the Moderation user assess the application and marks outcomes as Pass")]
        public void ThenTheModerationUserAssessTheApplicationAndMarksOutcomesAsPass()
        {
            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("ModerationAdmin");

            var moderationApplicationAssessmentOverviewPage = staffDashboardPage.AccessAssessorAndModerationApplications().ModeratorSelectsAssignToMe();

            moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.CompleteAllSectionsWithPass(moderationApplicationAssessmentOverviewPage, _applicationRoute);

            var _moderationApplicationsPage = _moderatorEndtoEndStepsHelper.CompleteModeratorOutcomeSectionAsPass(moderationApplicationAssessmentOverviewPage);

            _moderationApplicationsPage.VerifyOutcomeStatus("PASS");
        }

        private StaffDashboardPage GoToRoatpAdminStaffDashBoardPage(string applicationName)
        {
            RestartRoatpAdmin(applicationName);

            _roatpAdminLoginStepsHelper.SubmitValidLoginDetails();
            
            return new StaffDashboardPage(_context);
        }

        private void RestartRoatpAdmin(string applicationName) => RestartWebDriver(UrlConfig.Admin_BaseUrl, applicationName);

        private void RestartRoatpAssessor(string applicationName) => RestartWebDriver(UrlConfig.RoATPAssessor_BaseUrl, applicationName);

        private void RestartWebDriver(string url, string applicationName) => _restartWebDriverHelper.RestartWebDriver(url, applicationName);

        private void RoatpAssessor(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            _assessorEndtoEndStepsHelper.CompleteAllSectionsWithPass(applicationAssessmentOverviewPage, _applicationRoute);

            _assessorEndtoEndStepsHelper.MarkApplicationAsReadyForModeration(applicationAssessmentOverviewPage);
        }
    }
}
