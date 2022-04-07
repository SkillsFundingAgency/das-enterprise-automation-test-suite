using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class WebDriverSetupBase
    {
        protected readonly string DriverPath;

        protected readonly ScenarioContext context;

        protected readonly ObjectContext objectContext;

        protected readonly WebDriverSetupHelper webDriverSetupHelper;

        protected readonly FrameworkConfig frameworkConfig;

        private const string ChromeDriverServiceName = "chromedriver.exe";
        private const string FirefoxDriverServiceName = "geckodriver.exe";
        private const string IEDriverServiceName = "iedriverserver.exe";
        private const string EdgeDriverServiceName = "msedgedriver.exe";

        public WebDriverSetupBase(ScenarioContext context)
        {
            this.context = context;
            DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            objectContext = context.Get<ObjectContext>();
            webDriverSetupHelper = new WebDriverSetupHelper(context);
            frameworkConfig = context.Get<FrameworkConfig>();
        }

        protected void SetFireFoxDriverLocation(bool isLocal) => objectContext.SetFireFoxDriverLocation(isLocal ? FindLocalDriverServiceLocation(FirefoxDriverServiceName) : FindDriverServiceLocation(FirefoxDriverServiceName));

        protected void SetChromeDriverLocation(bool isLocal) => objectContext.SetChromeDriverLocation(isLocal ? FindLocalDriverServiceLocation(ChromeDriverServiceName) : FindDriverServiceLocation(ChromeDriverServiceName));

        protected void SetIeDriverLocation(bool isLocal) => objectContext.SetIeDriverLocation(isLocal ? FindLocalDriverServiceLocation(IEDriverServiceName) : FindDriverServiceLocation(IEDriverServiceName));

        protected void SetEdgeDriverLocation(bool isLocal) => objectContext.SetEdgeDriverLocation(isLocal ? FindLocalDriverServiceLocation(EdgeDriverServiceName) : FindDriverServiceLocation(EdgeDriverServiceName));

        protected bool IsCloudExecution() => objectContext.GetBrowser().IsCloudExecution();

        private string FindDriverServiceLocation(string executableName) => frameworkConfig.IsVstsExecution ? FindVstsDriverServiceLocation(executableName) : FindLocalDriverServiceLocation(executableName);

        private string FindLocalDriverServiceLocation(string executableName)
        {
            FileInfo[] file = Directory.GetParent(Directory.GetParent(DriverPath).FullName).GetFiles(executableName, SearchOption.AllDirectories);

            return file.Length != 0 ? file.Last().DirectoryName : DriverPath;
        }

        private string FindVstsDriverServiceLocation(string executableName)
        {
            var (chromeWebDriver, geckoWebDriver, iEWebDriver, edgeWebDriver) = context.Get<DriverLocationConfig>().DriverLocation;

            return true switch
            {
                bool _ when executableName == FirefoxDriverServiceName => geckoWebDriver,
                bool _ when executableName == IEDriverServiceName => iEWebDriver,
                bool _ when executableName == EdgeDriverServiceName => edgeWebDriver,
                _ => chromeWebDriver,
            };
        }
    }
}
