using OpenQA.Selenium.Remote;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class WebDriverSetup
    {
        private readonly string DriverPath;

        private readonly ObjectContext _objectContext;

        private readonly WebDriverSetupHelper _webDriverSetupHelper;

        private readonly FrameworkConfig _frameworkConfig;

        private readonly DriverLocationConfig _driverLocationConfig;

        private const string ChromeDriverServiceName = "chromedriver.exe";

        private const string FirefoxDriverServiceName = "geckodriver.exe";

        private const string InternetExplorerDriverServiceName = "IEDriverServer.exe";

        public WebDriverSetup(ScenarioContext context)
        {
            DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _objectContext = context.Get<ObjectContext>();
            _webDriverSetupHelper = new WebDriverSetupHelper(context);
            _frameworkConfig = context.Get<FrameworkConfig>();
            _driverLocationConfig = context.Get<DriverLocationConfig>();
        }

        [BeforeScenario(Order = 3)]
        public void SetupWebDriver()
        {
            _objectContext.SetFireFoxDriverLocation(FindDriverServiceLocation(FirefoxDriverServiceName));
            
            _objectContext.SetChromeDriverLocation(FindDriverServiceLocation(ChromeDriverServiceName));
            
            _objectContext.SetIeDriverLocation(FindDriverServiceLocation(InternetExplorerDriverServiceName));

            var browser = _objectContext.GetBrowser();

            var webDriver = _webDriverSetupHelper.SetupWebDriver();

            if (!browser.IsCloudExecution())
            {
                var wb = webDriver as RemoteWebDriver;
                var cap = wb.Capabilities;

                _objectContext.SetBrowserName(cap["browserName"]);
                _objectContext.SetBrowserVersion(cap["browserVersion"]);
            }
        }

        private string FindDriverServiceLocation(string executableName) => _frameworkConfig.IsVstsExecution ? FindVstsDriverServiceLocation(executableName) : FindLocalDriverServiceLocation(executableName);

        private string FindLocalDriverServiceLocation(string executableName)
        {
            FileInfo[] file = Directory.GetParent(DriverPath).GetFiles(executableName, SearchOption.AllDirectories);

            return file.Length != 0 ? file[0].DirectoryName : DriverPath;
        }

        private string FindVstsDriverServiceLocation(string executableName)
        {
            switch (true)
            {
                case bool _ when (executableName == FirefoxDriverServiceName):
                    return _driverLocationConfig.GeckoWebDriver;
                case bool _ when (executableName == InternetExplorerDriverServiceName):
                    return _driverLocationConfig.IEWebDriver;
                default:
                    return _driverLocationConfig.ChromeWebDriver;
            }
        }
    }
}
