using SFA.DAS.AODP.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "@aodp")]
    public class Hooks(ScenarioContext scenarioContext) 
    {

        [BeforeScenario(Order = 1)]
        public void setUp() => new AodpLandingPage(scenarioContext).verifyLandingPage();


        [AfterScenario(Order = 1)]
        public void tearDown()
        {
            // Implement tear down logic.
        }
    }
}