using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario;

[Binding]
public class UIFrameworkHelpersSetup(ScenarioContext context)
{
    private readonly TestSupport.UIFrameworkHelpersSetup _helpersSetup = new TestSupport.UIFrameworkHelpersSetup(context);
    private readonly FrameworkConfig _config = context.Get<FrameworkConfig>();

    [BeforeScenario(Order = 4)]
    public void SetUpUIFrameworkHelpers()
    {
        _helpersSetup.SetupUIFrameworkHelpers(false);

        context.Set(new BrowserStackReportingService(_config.BrowserStackSetting));
    }
}
