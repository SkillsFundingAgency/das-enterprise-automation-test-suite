using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    public abstract class WebDriverSetupBase
    {
        protected readonly string DriverPath;

        protected readonly ScenarioContext _context;

        protected readonly ObjectContext _objectContext;

        protected readonly WebDriverSetupHelper _webDriverSetupHelper;

        protected readonly FrameworkConfig _frameworkConfig;

        protected readonly DriverLocationConfig _driverLocationConfig;

        protected const string ChromeDriverServiceName = "chromedriver.exe";

        protected const string FirefoxDriverServiceName = "geckodriver.exe";

        protected const string InternetExplorerDriverServiceName = "IEDriverServer.exe";

        public WebDriverSetupBase(ScenarioContext context)
        {
            _context = context;
            DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _objectContext = context.Get<ObjectContext>();
            _webDriverSetupHelper = new WebDriverSetupHelper(context);
            _frameworkConfig = context.Get<FrameworkConfig>();
            _driverLocationConfig = context.Get<DriverLocationConfig>();
        }

        protected void AddCapabilities(IWebDriver webDriver)
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
        }

        protected string FindDriverServiceLocation(string executableName) => _frameworkConfig.IsVstsExecution ? FindVstsDriverServiceLocation(executableName) : FindLocalDriverServiceLocation(executableName);

        protected string FindLocalDriverServiceLocation(string executableName)
        {
            FileInfo[] file = Directory.GetParent(Directory.GetParent(DriverPath).FullName).GetFiles(executableName, SearchOption.AllDirectories);

            return file.Length != 0 ? file.Last().DirectoryName : DriverPath;
        }

        protected string FindVstsDriverServiceLocation(string executableName)
        {
            return true switch
            {
                bool _ when (executableName == FirefoxDriverServiceName) => _driverLocationConfig.GeckoWebDriver,
                bool _ when (executableName == InternetExplorerDriverServiceName) => _driverLocationConfig.IEWebDriver,
                _ => _driverLocationConfig.ChromeWebDriver,
            };
        }
    }
}
