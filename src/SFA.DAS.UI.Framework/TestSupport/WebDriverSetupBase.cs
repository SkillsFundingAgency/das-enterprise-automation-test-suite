using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public partial class WebDriverSetupBase(ScenarioContext context)
{
    protected readonly string DriverPath = FileHelper.GetLocalExecutingAssemblyPath();

    protected readonly ScenarioContext context = context;

    protected readonly ObjectContext objectContext = context.Get<ObjectContext>();

    protected readonly WebDriverSetupHelper webDriverSetupHelper = new(context);

    protected readonly FrameworkConfig frameworkConfig = context.Get<FrameworkConfig>();

    private const string ChromeDriverServiceName = "chromedriver.exe";
    private const string FirefoxDriverServiceName = "geckodriver.exe";
    private const string EdgeDriverServiceName = "msedgedriver.exe";

    protected void SetDriverLocation()
    {
        string chromeDriverLocation, geckoDriverLocation, edgeDriverLocation;

        if (frameworkConfig.IsAdoExecution)
        {
            (chromeDriverLocation, geckoDriverLocation, edgeDriverLocation) = Configurator.GetDriverLocation();

            if (!frameworkConfig.IsAdoDriverVersionCompatible)
            {
                var adoLocalPath = FileHelper.GetAzureSrcFilesPath();

                (chromeDriverLocation, geckoDriverLocation, edgeDriverLocation) = (adoLocalPath, adoLocalPath, adoLocalPath);
            }
        }
        else
        {
            (chromeDriverLocation, geckoDriverLocation, edgeDriverLocation) = FindLocalDriverServiceLocation();
        }

        objectContext.SetChromeDriverLocation(chromeDriverLocation);

        objectContext.SetFireFoxDriverLocation(geckoDriverLocation);

        objectContext.SetEdgeDriverLocation(edgeDriverLocation);
    }

    private (string chromeWebDriver, string geckoWebDriver, string edgeWebDriver) FindLocalDriverServiceLocation()
    {
        string replacedPath = ProjectNameRegexHelper.ProjectNameRegex().Replace(DriverPath, "SFA.DAS.UI.FrameworkHelpers");

        return (FindLocalDriverServiceLocation(replacedPath, ChromeDriverServiceName), FindLocalDriverServiceLocation(replacedPath, FirefoxDriverServiceName), FindLocalDriverServiceLocation(replacedPath, EdgeDriverServiceName));
    }

    private string FindLocalDriverServiceLocation(string replacedPath, string executableName)
    {
        string[] file = Directory.GetFiles(replacedPath, executableName);

        return file.Length != 0 ? Directory.GetParent(file.Last()).FullName : DriverPath;
    }
}
