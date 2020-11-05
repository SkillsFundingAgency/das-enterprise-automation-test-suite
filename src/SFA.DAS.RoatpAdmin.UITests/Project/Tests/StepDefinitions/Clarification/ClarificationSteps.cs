using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Clarification
{
    [Binding]
    public class ClarificationSteps
    {
        private readonly ScenarioContext _context;
        private ApplicationRoute _applicationRoute;

        public ClarificationSteps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"selects the (Main Provider Route|Supporting Provider Route|Employer Provider Route) application from Clarification Tab")]
        public void WhenSelectsTheEmployerProviderRouteApplicationFromClarificationTab(ApplicationRoute applicationroute)
        {
            _applicationRoute = applicationroute;

            new StaffDashboardPage(_context).AccessAssessorAndModerationApplications().ClarificationSelectsAssignToMe();
        }
    }
}
