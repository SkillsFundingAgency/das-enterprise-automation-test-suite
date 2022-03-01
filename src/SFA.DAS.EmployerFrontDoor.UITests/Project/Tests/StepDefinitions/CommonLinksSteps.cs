using SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CommonLinksSteps
    {
        private readonly ScenarioContext _context;

        public CommonLinksSteps(ScenarioContext context) => _context = context;

        [Then(@"the links are not broken")]
        public void ThenTheLinksAreNotBroken() => new EmployerFrontDoorVerifyLinks(_context, false).VerifyLinks();
    }
}