using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Roatp.UITests.Project;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Assessor
{
    [Binding]
    public class AssessorSteps
    {
        private readonly ScenarioContext _context;
        private readonly RoatpConfig _config;
        private readonly AssessorLoginStepsHelper _assessorLoginStepsHelper;
        private readonly RestartWebDriverHelper _restartWebDriverHelper;
        private AssessorApplicationsPage _assessorApplicationsPage;
        private ApplicationAssessmentOverviewPage _applicationAssessmentOverviewPage;
        private AssessorEndtoEndStepsHelper _assessorEndtoEndStepsHelper;

        public AssessorSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetRoatpConfig<RoatpConfig>();
            _restartWebDriverHelper = new RestartWebDriverHelper(context);
            _assessorLoginStepsHelper = new AssessorLoginStepsHelper(_context);
            _assessorEndtoEndStepsHelper = new AssessorEndtoEndStepsHelper();
        }

        [When(@"the Assessor(1|2) is on the RoATP assessor applications dashboard")]
        public void WhenTheAssessorIsOnTheRoATPAssessorApplicationsDashboard(int assessorUser)
        {
            if (assessorUser == 1)
            {
                _assessorApplicationsPage = _assessorLoginStepsHelper.Assessor1Login();
            }
            else
            {
                _restartWebDriverHelper.RestartWebDriver(_config.RoATPAssessorBaseUrl, "RoatpAdmin");
                _assessorApplicationsPage = _assessorLoginStepsHelper.Assessor2Login();
            }
        }

        [When(@"selects the Main provider route application")]
        public void AndSelectsTheMainProviderRouteApplication() =>
            _applicationAssessmentOverviewPage = _assessorApplicationsPage.AssessorSelectsAssignToMeForMainProvider();

        [Then(@"the Assessor assesses all the sections of the Main provider application as PASS")]
        public void ThenTheAssessorAssessesAllTheSectionsOfTheMainProviderApplicationAsPASS() =>
            _assessorEndtoEndStepsHelper.CompleteAllSectionsWithPass(_applicationAssessmentOverviewPage);

        [Then(@"marks the Application as Ready for moderation")]
        public void ThenMarksTheApplicationAsReadyForModeration() =>
            _assessorEndtoEndStepsHelper.MarkApplicationAsReadyForModeration(_applicationAssessmentOverviewPage);
    }
}
