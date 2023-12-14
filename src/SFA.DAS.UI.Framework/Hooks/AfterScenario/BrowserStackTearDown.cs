using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario;

[Binding]
public class BrowserStackTearDown(ScenarioContext context)
{
    [AfterScenario(Order = 12)]
    public void InformBrowserStackOnFailure() => new BrowserStackTearDownHelper(context).MarkTestStatus();
}