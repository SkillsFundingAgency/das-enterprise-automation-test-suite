using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Assessor
{
    [Binding]
    public class AssessorSteps
    {
        private readonly AssessorLoginStepsHelper _assessorLoginStepsHelper;
        private readonly RestartWebDriverHelper _restartWebDriverHelper;
        private AssessorApplicationsPage _assessorApplicationsPage;
        private ApplicationAssessmentOverviewPage _applicationAssessmentOverviewPage;
        private AssessorEndtoEndStepsHelper _assessorEndtoEndStepsHelper;

        public AssessorSteps(ScenarioContext context)
        {
            _restartWebDriverHelper = new RestartWebDriverHelper(context);
            _assessorLoginStepsHelper = new AssessorLoginStepsHelper(context);
            _assessorEndtoEndStepsHelper = new AssessorEndtoEndStepsHelper(context);
        }

        [When(@"the (Assessor1|Assessor2) is on the RoATP assessor applications dashboard")]
        public void WhenTheAssessorIsOnTheRoATPAssessorApplicationsDashboard(string assessorUser)
        {
            if (assessorUser.Equals("Assessor1"))
            {
                _assessorApplicationsPage = _assessorLoginStepsHelper.Assessor1Login();
            }
            else if (assessorUser.Equals("Assessor2"))
            {
                _restartWebDriverHelper.RestartWebDriver(UrlConfig.RoATPAssessor_BaseUrl, "RoatpAdmin");
                _assessorApplicationsPage = _assessorLoginStepsHelper.Assessor2Login();
            }
        }

        [When(@"selects the Main provider route application")]
        [When(@"selects the Supporting provider route application")]
        [When(@"selects the Employer provider route application")]
        public void AndSelectsTheRouteApplication() => _applicationAssessmentOverviewPage = _assessorApplicationsPage.AssessorSelectsAssignToMe();

        [Then(@"the Assessor assesses all the sections of the application as PASS")]
        public void ThenTheAssessorAssessesAllTheSectionsOfTheApplicationAsPASS() =>
            _assessorEndtoEndStepsHelper.CompleteAllSectionsWithPass(_applicationAssessmentOverviewPage);

        [Then(@"marks the Application as Ready for moderation")]
        public void ThenMarksTheApplicationAsReadyForModeration() =>
            _assessorEndtoEndStepsHelper.MarkApplicationAsReadyForModeration(_applicationAssessmentOverviewPage);
    }
}
