using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using System.Linq;
using System.Collections.Generic;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario;

[Binding]
public class FrameworkConfigurationSetup(ScenarioContext context)
{
    private readonly IConfigSection _configSection = context.Get<IConfigSection>();

    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    [BeforeScenario(Order = 2)]
    public void SetUpFrameworkConfiguration()
    {
        var testExecutionConfig = _configSection.GetConfigSection<TestExecutionConfig>();

        var captureUrlAdmin = testExecutionConfig.CaptureUrlAdmins.ToList(",");

        var fullscreenshotAdmin = testExecutionConfig.FullScreenShotAdmins.ToList(",");

        _ = bool.TryParse(testExecutionConfig.CanTakeFullScreenShot, out bool canTakeFullScreenShot);

        _ = bool.TryParse(testExecutionConfig.IsAccessibilityTesting, out bool isAccessibilityTesting);

        bool IsVstsExecution = Configurator.IsVstsExecution;

        var frameworkConfig = new FrameworkConfig
        {
            NServiceBusConfig = _configSection.GetConfigSection<NServiceBusConfig>(),
            TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
            BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
            IsVstsExecution = IsVstsExecution,
            CanCaptureUrl = IsCurrrentUserAnAdmin(captureUrlAdmin) && IsVstsExecution,
            CanTakeFullScreenShot = IsCurrrentUserAnAdmin(fullscreenshotAdmin) || canTakeFullScreenShot,
            IsAccessibilityTesting = isAccessibilityTesting
        };

        context.Set(frameworkConfig);

        _objectContext.SetBrowser(testExecutionConfig.Browser);

        context.Set(new DriverLocationConfig { DriverLocation = Configurator.GetDriverLocation() });

        if (frameworkConfig.CanCaptureUrl) _objectContext.InitAuthUrl();
    }

      private bool IsCurrrentUserAnAdmin(List<string> admins) => admins.Any(x => Configurator.GetDeploymentRequestedFor().ContainsCompareCaseInsensitive(x));
}