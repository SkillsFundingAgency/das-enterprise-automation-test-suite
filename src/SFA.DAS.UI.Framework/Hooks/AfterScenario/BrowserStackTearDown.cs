using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario;

[Binding]
public class BrowserStackTearDown
{
    private readonly ScenarioContext _context;

    public BrowserStackTearDown(ScenarioContext context) => _context = context;

    [AfterScenario(Order = 12)]
    public void InformBrowserStackOnFailure() => new BrowserStackTearDownHelper(_context).MarkTestStatus();
}