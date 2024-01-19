using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario;

[Binding]
public class WebDriverSetup(ScenarioContext context) : WebDriverSetupBase(context)
{
    [BeforeScenario(Order = 3)]
    public void SetupWebDriver()
    {
        SetDriverLocation(false);

        webDriverSetupHelper.SetupWebDriver();
    }
}
