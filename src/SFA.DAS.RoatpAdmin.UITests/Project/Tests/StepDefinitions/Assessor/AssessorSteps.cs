using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Assessor
{
    [Binding]
    public class AssessorSteps
    {
        private readonly ScenarioContext _context;

        public AssessorSteps(ScenarioContext context) => _context = context;

        [When(@"the Assessor(.*) is on the RoATP assessor applications dashboard")]
        public void WhenTheAssessorIsOnTheRoATPAssessorApplicationsDashboard(int p0)
        {

        }

        [Then(@"Assessor(.*) selects the Main provider route application")]
        public void ThenAssessorSelectsTheMainProviderRouteApplication(int p0)
        {

        }

        [Then(@"assesses all the sections of the Main provider application as PASS")]
        public void ThenAssessesAllTheSectionsOfTheMainProviderApplicationAsPASS()
        {

        }

        [When(@"the Assessor(.*) is on RoATP assessor applications dashboard")]
        public void WhenTheAssessorIsOnRoATPAssessorApplicationsDashboard(int p0)
        {

        }
    }
}
