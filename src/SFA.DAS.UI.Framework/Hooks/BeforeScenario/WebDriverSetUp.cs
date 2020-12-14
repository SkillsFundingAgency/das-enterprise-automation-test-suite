using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class WebDriverSetup
    {
        private readonly string DriverPath;

        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly WebDriverSetupHelper _webDriverSetupHelper;

        private readonly FrameworkConfig _frameworkConfig;

        private readonly DriverLocationConfig _driverLocationConfig;

        private const string ChromeDriverServiceName = "chromedriver.exe";

        private const string FirefoxDriverServiceName = "geckodriver.exe";

        private const string InternetExplorerDriverServiceName = "IEDriverServer.exe";

        public WebDriverSetup(ScenarioContext context)
        {
            _context = context;
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
                var chromecap = AddCapabilities(webDriver);

                if (_frameworkConfig.IsVstsExecution && IsUnsupportedChromeDriverVersion(chromecap))
                {
                    _objectContext.SetFireFoxDriverLocation(FindLocalDriverServiceLocation(FirefoxDriverServiceName));

                    _objectContext.SetChromeDriverLocation(FindLocalDriverServiceLocation(ChromeDriverServiceName));

                    _objectContext.SetIeDriverLocation(FindLocalDriverServiceLocation(InternetExplorerDriverServiceName));

                    webDriver = new RestartWebDriverHelper(_context).RestartWebDriver();

                    AddCapabilities(webDriver);
                }
            }
        }


        private Dictionary<string, object> AddCapabilities(IWebDriver webDriver)
        {
            var wb = webDriver as RemoteWebDriver;
            var cap = wb.Capabilities;

            _objectContext.SetBrowserName(cap["browserName"]);
            _objectContext.SetBrowserVersion(cap["browserVersion"]);

            var chromecap = cap["chrome"] as Dictionary<string, object>;

            foreach (var item in chromecap)
            {
                _objectContext.Replace(item.Key, item.Value);
            }

            return chromecap;
        }

        private string FindDriverServiceLocation(string executableName) => _frameworkConfig.IsVstsExecution ? FindVstsDriverServiceLocation(executableName) : FindLocalDriverServiceLocation(executableName);

        private string FindLocalDriverServiceLocation(string executableName)
        {
            FileInfo[] file = Directory.GetParent(DriverPath).GetFiles(executableName, SearchOption.AllDirectories);

            return file.Length != 0 ? file.Last().DirectoryName : DriverPath;
        }

        private string FindVstsDriverServiceLocation(string executableName)
        {
            return true switch
            {
                bool _ when (executableName == FirefoxDriverServiceName) => _driverLocationConfig.GeckoWebDriver,
                bool _ when (executableName == InternetExplorerDriverServiceName) => _driverLocationConfig.IEWebDriver,
                _ => _driverLocationConfig.ChromeWebDriver,
            };
        }

        private bool IsUnsupportedChromeDriverVersion(Dictionary<string, object> chromecap) => chromecap.GetValue<string>("chromedriverVersion").StartsWith("87.0.4280.20");
    }
}
