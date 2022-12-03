using SFA.DAS.ConfigurationBuilder;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
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

        protected void SetDriverLocation(bool isLocal)
        {
            SetFireFoxDriverLocation(isLocal);

            SetChromeDriverLocation(isLocal);

            SetIeDriverLocation(isLocal);

            SetEdgeDriverLocation(isLocal);
        }

        protected void SetFireFoxDriverLocation(bool isLocal) => objectContext.SetFireFoxDriverLocation(GetDriverLocation(isLocal, FirefoxDriverServiceName));

        protected void SetChromeDriverLocation(bool isLocal) => objectContext.SetChromeDriverLocation(GetDriverLocation(isLocal, ChromeDriverServiceName));

        protected void SetIeDriverLocation(bool isLocal) => objectContext.SetIeDriverLocation(GetDriverLocation(isLocal, IEDriverServiceName));

        protected void SetEdgeDriverLocation(bool isLocal) => objectContext.SetEdgeDriverLocation(GetDriverLocation(isLocal, EdgeDriverServiceName));

        private string GetDriverLocation(bool isLocal, string executableName) => isLocal ? FindLocalDriverServiceLocation(executableName) : FindDriverServiceLocation(executableName);

        private string FindDriverServiceLocation(string executableName) => frameworkConfig.IsVstsExecution ? FindVstsDriverServiceLocation(executableName) : FindLocalDriverServiceLocation(executableName);

        private string FindLocalDriverServiceLocation(string executableName)
        {
            string[] file = Directory.GetFiles(Regex.Replace(DriverPath, "SFA.DAS.[A-Za-z]*.[A-Za-z]*Tests", "SFA.DAS.UI.FrameworkHelpers"), executableName);

            var match = Regex.Match(DriverPath, "SFA.DAS.[A-Za-z]*.[A-Z0-9a-z]*Tests");

            return file.Length != 0 ? Directory.GetParent(file.Last()).FullName : DriverPath;
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
