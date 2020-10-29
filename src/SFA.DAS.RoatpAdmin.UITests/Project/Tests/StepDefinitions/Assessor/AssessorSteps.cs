using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.Framework;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Assessor
{
    [Binding]
    public class AssessorSteps
    {
        private readonly AssessorEndtoEndStepsHelper _assessorEndtoEndStepsHelper;
        private readonly AssessorLoginStepsHelper _assessorLoginStepsHelper;
        private readonly RestartWebDriverHelper _restartWebDriverHelper;
        private AssessorApplicationsPage _assessorApplicationsPage;
        private ApplicationAssessmentOverviewPage _applicationAssessmentOverviewPage;
        private ApplicationRoute _applicationRoute;

        public AssessorSteps(ScenarioContext context)
        {
            _restartWebDriverHelper = new RestartWebDriverHelper(context);
            _assessorLoginStepsHelper = new AssessorLoginStepsHelper(context);
            _assessorEndtoEndStepsHelper = new AssessorEndtoEndStepsHelper();
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

        [When(@"selects the (Main Provider Route|Supporting Provider Route|Employer Provider Route) application")]
        public void SelectsTheRouteApplication(ApplicationRoute applicationroute)
        {
            _applicationRoute = applicationroute;
            _applicationAssessmentOverviewPage = _assessorApplicationsPage.AssessorSelectsAssignToMe(); 
        }

        [When(@"the Assessor selects the same application")]
        public void WhenTheAssessorSelectsTheSameApplication() => SelectsTheRouteApplication(_applicationRoute);


        [Then(@"marks the Application as Ready for moderation")]
        public void ThenMarksTheApplicationAsReadyForModeration() =>
            _assessorEndtoEndStepsHelper.MarkApplicationAsReadyForModeration(_applicationAssessmentOverviewPage);

        [Then(@"the Assessor assesses all the sections of the application as PASS")]
        public void TheAssessorAssessesAllTheSectionsOfTheApplicationAsPASS() =>
            _assessorEndtoEndStepsHelper.CompleteAllSectionsWithPass(_applicationAssessmentOverviewPage, _applicationRoute);
        
    }
}