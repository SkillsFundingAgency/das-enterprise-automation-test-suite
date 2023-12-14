using SFA.DAS.FrameworkHelpers;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract partial class WebDriverSetupBase(ScenarioContext context)
{
    protected readonly string DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    protected readonly ScenarioContext context = context;

    protected readonly ObjectContext objectContext = context.Get<ObjectContext>();

    protected readonly WebDriverSetupHelper webDriverSetupHelper = new(context);

    protected readonly FrameworkConfig frameworkConfig = context.Get<FrameworkConfig>();

    private const string ChromeDriverServiceName = "chromedriver.exe";
    private const string FirefoxDriverServiceName = "geckodriver.exe";
    private const string EdgeDriverServiceName = "msedgedriver.exe";

    protected void SetDriverLocation(bool isLocal)
    {
        SetFireFoxDriverLocation(isLocal);

        SetChromeDriverLocation(isLocal);

        SetEdgeDriverLocation(isLocal);
    }

    protected void SetFireFoxDriverLocation(bool isLocal) => objectContext.SetFireFoxDriverLocation(GetDriverLocation(isLocal, FirefoxDriverServiceName));

    protected void SetChromeDriverLocation(bool isLocal) => objectContext.SetChromeDriverLocation(GetDriverLocation(isLocal, ChromeDriverServiceName));

    protected void SetEdgeDriverLocation(bool isLocal) => objectContext.SetEdgeDriverLocation(GetDriverLocation(isLocal, EdgeDriverServiceName));

    private string GetDriverLocation(bool isLocal, string executableName) => isLocal ? FindLocalDriverServiceLocation(executableName) : FindDriverServiceLocation(executableName);

    private string FindDriverServiceLocation(string executableName) => frameworkConfig.IsVstsExecution ? FindVstsDriverServiceLocation(executableName) : FindLocalDriverServiceLocation(executableName);

    private string FindLocalDriverServiceLocation(string executableName)
    {
        string[] file = Directory.GetFiles(ProjectNameRegex().Replace(DriverPath, "SFA.DAS.UI.FrameworkHelpers"), executableName);

        return file.Length != 0 ? Directory.GetParent(file.Last()).FullName : DriverPath;
    }

    private string FindVstsDriverServiceLocation(string executableName)
    {
        var (chromeWebDriver, geckoWebDriver, edgeWebDriver) = context.Get<DriverLocationConfig>().DriverLocation;

        return true switch
        {
            bool _ when executableName == FirefoxDriverServiceName => geckoWebDriver,
            bool _ when executableName == EdgeDriverServiceName => edgeWebDriver,
            _ => chromeWebDriver,
        };
    }

    [GeneratedRegex("SFA.DAS.[A-Za-z]*.[A-Z0-9a-z]*Tests")]
    private static partial Regex ProjectNameRegex();
}
