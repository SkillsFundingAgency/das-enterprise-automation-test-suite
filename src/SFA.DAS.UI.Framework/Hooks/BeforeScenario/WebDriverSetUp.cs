using NUnit.Framework;
using OpenQA.Selenium.Remote;
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

        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly WebDriverSetupHelper _webDriverSetupHelper;
        
        private const string ChromeDriverServiceName = "chromedriver.exe";

        private const string FirefoxDriverServiceName = "geckodriver.exe";

        private const string InternetExplorerDriverServiceName = "IEDriverServer.exe";

        public WebDriverSetup(ScenarioContext context)
        {
            DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _webDriverSetupHelper = new WebDriverSetupHelper(context);
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

        private string FindDriverServiceLocation(string executableName)
        {
            TestContext.Progress.WriteLine($"DriverPath : {DriverPath}, Executable Name : {executableName}");

            FileInfo[] file = Directory.GetParent(DriverPath).GetFiles(executableName, SearchOption.AllDirectories);

            var info = file.Length != 0 ? file[0].DirectoryName : DriverPath;

            TestContext.Progress.WriteLine($"Driver Service should be available under: {info}");

            return info;
        }
    }
}
