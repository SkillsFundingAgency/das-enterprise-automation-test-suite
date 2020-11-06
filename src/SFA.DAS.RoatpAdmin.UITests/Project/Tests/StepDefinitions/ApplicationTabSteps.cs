using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApplicationTabSteps
    {
        private readonly ScenarioContext _context;

        public ApplicationTabSteps(ScenarioContext context) => _context = context;

        [Then(@"the Outcome tab is updated as (PASS|FAIL)")]
        public void ThenTheOutcomeTabIsUpdated(string expectedStatus) => new RoatpApplicationsHomePage(_context).VerifyOutcomeStatus(expectedStatus);

        [Then(@"the Clarification tab is updated")]
        public void ThenTheClarificationTabIsUpdated() => new RoatpApplicationsHomePage(_context).VerifyClarificationStatus();
    }
}
