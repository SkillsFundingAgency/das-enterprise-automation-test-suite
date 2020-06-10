using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class E2ESteps
    {
        private readonly ScenarioContext _context;
        private readonly EPAOSqlDataHelper _ePAOSqlDataHelper;
        private readonly ApplyStepsHelper _applyStepsHelper;
        private readonly EPAOConfig _config;
        private readonly TabHelper _tabHelper;
        private readonly EPAOHomePageHelper _ePAOHomePageHelper;

        public E2ESteps(ScenarioContext context)
        {
            _context = context;
            _ePAOSqlDataHelper = context.Get<EPAOSqlDataHelper>();
            _applyStepsHelper = new ApplyStepsHelper(_context);
            _config = context.GetEPAOConfig<EPAOConfig>();
            _tabHelper = context.Get<TabHelper>();
            _ePAOHomePageHelper = new EPAOHomePageHelper(_context);
        }

        [Given(@"the apply user submits an Assessment Service Application")]
        public void GivenTheApplyUserSubmitsAnAssessmentServiceApplication()
        {
            _ePAOHomePageHelper.LoginInAsApplyUser(_context.GetUser<EPAOE2EApplyUser>());

            var _applicationOverviewPage = _applyStepsHelper.CompletePreambleJourney("Brunell School");

            _applicationOverviewPage = _applyStepsHelper.CompleteOrganisationDetailsSection(_applicationOverviewPage);

            _applicationOverviewPage = _applyStepsHelper.CompleteDeclarationsSection(_applicationOverviewPage);

            _applicationOverviewPage = _applyStepsHelper.CompletesTheFHASection(_applicationOverviewPage);

            _applyStepsHelper.SubmitApplication(_applicationOverviewPage);
        }

        [Given(@"the admin appoves the assessor")]
        public void GivenTheAdminAppovesTheAssessor()
        {
            _tabHelper.OpenInNewTab(_config.AdminBaseUrl);

            var staffdashboard = _ePAOHomePageHelper.GoToEpaoAdminHomePage();

            staffdashboard = staffdashboard
                .GoToNewOrganisationApplications()
                .GoToNewApplicationOverviewPage()
                .GoToNewOrganisationDetailsPage()
                .SelectYesAndContinue()
                .GoToNewOrgDeclarationsPage()
                .SelectYesAndContinue()
                .ReturnToOrganisationApplicationsPage()
                .ReturnToDashboard();

            staffdashboard = staffdashboard
                .GoToNewFinancialAssesmentPage()
                .GoToNewApplicationOverviewPage()
                .SelectGoodAndContinue()
                .ReturnToAccountHome()
                .ReturnToDashboard();

            staffdashboard = staffdashboard.GoToInProgressOrganisationApplication()
                .GoToInProgressApplicationOverviewPage()
                .GoToFinancialhealthAssesmentPage()
                .SelectYesAndContinue()
                .CompleteReview()
                .ApproveApplication()
                .ReturnToApplications()
                .ReturnToDashboard();

            staffdashboard
                .GoToApprovedOrganisationApplication()
                .GoToApprovedApplicationOverviewPage()
                .ReturnToOrganisationApplicationsPage()
                .ReturnToDashboard();
        }

        [When(@"the apply user applies for a standard")]
        public void WhenTheApplyUserAppliesForAStandard()
        {
            throw new PendingStepException();
        }

    }
}
