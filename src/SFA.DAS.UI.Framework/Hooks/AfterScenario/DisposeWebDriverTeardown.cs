using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario;

[Binding]
public class DisposeWebDriverTeardown(ScenarioContext context)
{
    [AfterScenario(Order = 19)]
    public void DisposeWebDriver() => new DisposeWebDriverTeardownHelper(context).DisposeWebDriver();
}