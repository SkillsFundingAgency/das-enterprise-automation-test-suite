using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.EndToEnd
{
    [Binding]
    public class EndToEndSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
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
            _objectContext = context.Get<ObjectContext>();
            _roatpAdminLoginStepsHelper = new RoatpAdminLoginStepsHelper(context);
            _assessorLoginStepsHelper = new AssessorLoginStepsHelper(_context);
            _gatewayEndToEndStepsHelpers = new GatewayEndtoEndStepsHelpers();
            _assessorEndtoEndStepsHelper = new AssessorEndtoEndStepsHelper();
            _moderatorEndtoEndStepsHelper = new ModeratorEndtoEndStepsHelper();
            _restartWebDriverHelper = new RestartWebDriverHelper(context);
        }

        [Given(@"the GateWay user assess the application by confirming Gateway outcome as Pass")]
        [When(@"the GateWay user assess the application by confirming Gateway outcome as Pass")]
        public void TheGateWayUserAssessTheApplicationByConfirmingGatewayOutcomeAsPass()
        {
            _applicationRoute = _objectContext.GetApplicationRoute();

            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("GatewayAdmin");

            var gwApplicationOverviewPage = staffDashboardPage.AccessGatewayApplications().SelectApplication();

            gwApplicationOverviewPage = CompleteAllSectionsWithPass(gwApplicationOverviewPage);

            _gatewayEndToEndStepsHelpers.ConfirmGatewayOutcomeAsPass(gwApplicationOverviewPage);
        }

        [When(@"the Financial user assess the application by confirming Finance outcome as (outstanding|inadequate)")]
        public void WhenTheFinancialUserAssessTheApplicationByConfirmingFinanceOutcomeAsOutstanding(string expectedoutcome)
        {
            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("FinanceAdmin");

            staffDashboardPage.AccessFinancialApplications().SelectNewApplication().ConfirmFHAReviewAsOutstanding(expectedoutcome);
        }

        [Given(@"the Asssesssors assess the application and marks the application as Ready for Moderation")]
        [When(@"the Asssesssors assess the application and marks the application as Ready for Moderation")]
        public void TheAsssesssorAndAssessorAssessTheApplicationAndMarksTheApplicationAsReadyForModeration()
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
            var moderationApplicationAssessmentOverviewPage = ModeratorSelectsAssignToMe();

            moderationApplicationAssessmentOverviewPage = CompleteAllSectionsWithPass(moderationApplicationAssessmentOverviewPage);

            var moderationApplicationsPage = _moderatorEndtoEndStepsHelper.CompleteModeratorOutcomeSectionAsPass(moderationApplicationAssessmentOverviewPage);

            moderationApplicationsPage.VerifyOutcomeStatus("PASS");
        }

        [Then(@"the (PASS) status overall application is marked as Successful")]
        public void ThenThePASSStatusOverallApplicationIsMarkedAsSuccessful(string expectedStatus)
        {
            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("OversightAdmin");

            staffDashboardPage.AccessOversightApplications().SelectApplication(expectedStatus).MakeApplicationSuccessful()
                .SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the (FAIL) status overall application is marked as UnSuccessful")]
        public void ThenTheFAILStatusOverallApplicationIsMarkedAsUnSuccessful(string expectedStatus)
        {
            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("OversightAdmin");

            staffDashboardPage.AccessOversightApplications().SelectApplication(expectedStatus).MakeApplicationUnSuccessful()
                .SelectYesAskAndContinueOutcomePage().GoToRoATPAssessorApplicationsPage();
        }

        [Then(@"the Moderation user assess the application and marks outcomes as Fail")]
        public void ThenTheModerationUserAssessTheApplicationAndMarksOutcomesAsFail()
        {
            var moderationApplicationAssessmentOverviewPage = ModeratorSelectsAssignToMe();

            moderationApplicationAssessmentOverviewPage = CompleteAllSectionsWithPass(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.FailWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.FailTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, _applicationRoute);

            var moderationApplicationsPage = _moderatorEndtoEndStepsHelper.CompleteModeratorOutcomeSectionAsFail(moderationApplicationAssessmentOverviewPage);

            moderationApplicationsPage.VerifyOutcomeStatus("FAIL");
        }


        [Then(@"the Oversight user assess the (PASS|IN PROGRESS|UNSUCCESSFUL) application as Successful and verifies the provider added to the register")]
        public void ThenTheOversightUserAssessTheApplicationAsSuccessfulAndVerifiesTheProviderAddedToTheRegister(string expectedStatus)
        {
            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("OversightAdmin");

            staffDashboardPage.AccessOversightApplications().SelectApplication(expectedStatus).MakeApplicationSuccessful().SelectYesAskAndContinueOutcomePage();

            new OversightLandingPage(_context).VerifyOverallOutcomeStatus(expectedStatus);

            var resultPage = new StaffDashboardPage(_context, true)
                .SearchForATrainingProvider()
                .SearchTrainingProviderByUkprn();

            resultPage.VerifyOneProviderUkprnResultFound();

            resultPage.VerifyProviderStatusAsOnBoarding();

        }

        [Given(@"the Moderation user assess the application and marks every section as Fail and outcome As Clarification")]
        public void GivenTheModerationUserAssessTheApplicationAndMarksEverySectionAsFailAndOutcomeAsClarification()
        {
            var moderationApplicationAssessmentOverviewPage = ModeratorSelectsAssignToMe();

            moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.CompleteAllSectionsWithFail(moderationApplicationAssessmentOverviewPage, _applicationRoute);

            CompleteModeratorOutcomeSectionAsAskClarification(moderationApplicationAssessmentOverviewPage);
        }

        [Given(@"the Moderation user assess the application and marks few section as Fail and outcome As Clarification")]
        public void GivenTheModerationUserAssessTheApplicationAndMarksFewSectionAsFailAndOutcomeAsClarification()
        {
            var moderationApplicationAssessmentOverviewPage = ModeratorSelectsAssignToMe();

            moderationApplicationAssessmentOverviewPage = CompleteAllSectionsWithPass(moderationApplicationAssessmentOverviewPage);

            moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.CompleteSomeSectionsWithFail(moderationApplicationAssessmentOverviewPage, _applicationRoute);

            CompleteModeratorOutcomeSectionAsAskClarification(moderationApplicationAssessmentOverviewPage);

        }

        private ModerationApplicationAssessmentOverviewPage CompleteAllSectionsWithPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return _moderatorEndtoEndStepsHelper.CompleteAllSectionsWithPass(moderationApplicationAssessmentOverviewPage, _applicationRoute);
        }

        private RoatpAssessorApplicationsHomePage CompleteModeratorOutcomeSectionAsAskClarification(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            var moderationApplicationsPage = _moderatorEndtoEndStepsHelper.CompleteModeratorOutcomeSectionAsAskClarification(moderationApplicationAssessmentOverviewPage);

            return moderationApplicationsPage.VerifyClarificationStatus();
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

        private GWApplicationOverviewPage CompleteAllSectionsWithPass(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            if (_applicationRoute == ApplicationRoute.MainProviderRoute) 
                gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_MainOrEmpRouteCompany((gwApplicationOverviewPage));

            if (_applicationRoute == ApplicationRoute.EmployerProviderRoute || _applicationRoute == ApplicationRoute.EmployerProviderRouteForExistingProvider)
                gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_EmployerRouteCharity((gwApplicationOverviewPage));
                
            if (_applicationRoute == ApplicationRoute.SupportingProviderRoute) 
                gwApplicationOverviewPage = _gatewayEndToEndStepsHelpers.CompleteAllSectionsWithPass_SupportingRouteSoleTrader((gwApplicationOverviewPage));

            return gwApplicationOverviewPage;
        }

        private ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMe()
        {
            var staffDashboardPage = GoToRoatpAdminStaffDashBoardPage("ModerationAdmin");

            return staffDashboardPage.AccessAssessorAndModerationApplications().ModeratorSelectsAssignToMe();
        }

    }
}
