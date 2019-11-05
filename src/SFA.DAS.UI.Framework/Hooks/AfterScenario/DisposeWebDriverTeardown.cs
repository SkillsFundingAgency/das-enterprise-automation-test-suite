using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class DisposeWebDriverTeardown
    {
        private readonly DisposeWebDriverTeardownHelper _helper;

        public DisposeWebDriverTeardown(ScenarioContext context)
        {
            _helper = new DisposeWebDriverTeardownHelper(context);
        }

        [AfterScenario(Order = 13)]
        public void DisposeWebDriver()
        {
            _helper.DisposeWebDriver();
        }
    }
}
