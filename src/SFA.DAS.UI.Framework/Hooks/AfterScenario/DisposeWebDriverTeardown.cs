using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class DisposeWebDriverTeardown
    {
        private readonly ScenarioContext _context;

        public DisposeWebDriverTeardown(ScenarioContext context) => _context = context;

        [AfterScenario(Order = 19)]
        public void DisposeWebDriver() => new DisposeWebDriverTeardownHelper(_context).DisposeWebDriver();
    }
}