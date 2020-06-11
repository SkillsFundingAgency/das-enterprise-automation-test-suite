using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class E2ESteps
    {
        private readonly ScenarioContext _context;
        private readonly ApplyStepsHelper _applyStepsHelper;
        private readonly AdminStepshelper _adminStepshelper;
        private readonly EPAOHomePageHelper _ePAOHomePageHelper;

        private string _e2eorgName => "Brunell School";

        public E2ESteps(ScenarioContext context)
        {
            _context = context;
            _applyStepsHelper = new ApplyStepsHelper(_context);
            _adminStepshelper = new AdminStepshelper(_context);
            _ePAOHomePageHelper = new EPAOHomePageHelper(_context);
        }

        [Given(@"the apply user submits an Assessment Service Application")]
        public void GivenTheApplyUserSubmitsAnAssessmentServiceApplication()
        {
            _ePAOHomePageHelper.LoginInAsApplyUser(_context.GetUser<EPAOE2EApplyUser>());

            var _applicationOverviewPage = _applyStepsHelper.CompletePreambleJourney(_e2eorgName);

            _applicationOverviewPage = _applyStepsHelper.CompleteOrganisationDetailsSection(_applicationOverviewPage);

            _applicationOverviewPage = _applyStepsHelper.CompleteDeclarationsSection(_applicationOverviewPage);

            _applicationOverviewPage = _applyStepsHelper.CompletesTheFHASection(_applicationOverviewPage);

            _applyStepsHelper.SubmitApplication(_applicationOverviewPage);
        }

        [Given(@"the admin appoves the assessor")]
        public void GivenTheAdminAppovesTheAssessor() => _adminStepshelper.ApproveAnOrganisation();

        [When(@"the apply user applies for a standard")]
        public void WhenTheApplyUserAppliesForAStandard()
        {
            var page = _ePAOHomePageHelper.LoginInAsStandardApplyUser(_context.GetUser<EPAOE2EApplyUser>());

            _applyStepsHelper.ApplyForAStandard(page);
        }

        [Then(@"the admin approves the standard")]
        public void ThenTheAdminApprovesTheStandard() => _adminStepshelper.ApproveAStandard();

        [Then(@"make the epao live")]
        public void ThenMakeTheEpaoLive() => _adminStepshelper.MakeEPAOOrganisationLive(_e2eorgName);
    }
}
