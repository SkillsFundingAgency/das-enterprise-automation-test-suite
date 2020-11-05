using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Clarification
{
    [Binding]
    public class ClarificationSteps
    {
        private readonly ScenarioContext _context;
        private readonly ModeratorEndtoEndStepsHelper _moderatorEndtoEndStepsHelper;
        private ApplicationRoute _applicationRoute;
        private ModerationApplicationAssessmentOverviewPage _moderationApplicationAssessmentOverviewPage;

        public ClarificationSteps(ScenarioContext context)
        {
            _context = context;
            _moderatorEndtoEndStepsHelper = new ModeratorEndtoEndStepsHelper();
        }

        [When(@"selects the (Main Provider Route|Supporting Provider Route|Employer Provider Route) application from Clarification Tab")]
        public void WhenSelectsTheEmployerProviderRouteApplicationFromClarificationTab(ApplicationRoute applicationroute)
        {
            _applicationRoute = applicationroute;

            _moderationApplicationAssessmentOverviewPage = new StaffDashboardPage(_context).AccessAssessorAndModerationApplications().ClarificationSelectsAssignToMe();
        }

        [Then(@"the Clarification assessor assesses all the sections of the application as PASS")]
        public void ThenTheClarificationAssessorAssessesAllTheSectionsOfTheApplicationAsPASS()
        {
            _moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.CompleteAllSectionsWithPass(_moderationApplicationAssessmentOverviewPage, _applicationRoute);
        }

    }
}
