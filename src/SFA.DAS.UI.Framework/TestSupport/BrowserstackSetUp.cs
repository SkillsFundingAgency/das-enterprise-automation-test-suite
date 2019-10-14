using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium.Chrome;

namespace SFA.DAS.UI.Framework.Project.Tests.TestSupport
{
    public class BrowserStackSetup
    {
        private static readonly string _buildDateTime;

        static BrowserStackSetup()
        {
            _buildDateTime = DateTime.Now.ToString("ddMMMyyyy_HH:mm:ss").ToUpper();
        }

        public static IWebDriver Init(BrowserStackSetting options, EnvironmentConfig executionConfig)
        {
            CheckBrowserStackLogin(options);

            var chromeOption = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };
            AddAdditionalCapability(chromeOption, "browser", options.Browser);
            AddAdditionalCapability(chromeOption, "browser_version", options.BrowserVersion);
            AddAdditionalCapability(chromeOption, "os", options.Os);
            AddAdditionalCapability(chromeOption, "os_version", options.Osversion);
            AddAdditionalCapability(chromeOption, "resolution", options.Resolution);
            AddAdditionalCapability(chromeOption, "browserstack.user", options.User);
            AddAdditionalCapability(chromeOption, "browserstack.key", options.Key);
            AddAdditionalCapability(chromeOption, "build", $"{options.Build}_{executionConfig.EnvironmentName.ToUpper()}_{_buildDateTime}");
            AddAdditionalCapability(chromeOption, "project", options.Project);
            AddAdditionalCapability(chromeOption, "browserstack.debug", "true");
            AddAdditionalCapability(chromeOption, "name", options.Name);
            AddAdditionalCapability(chromeOption, "browserstack.networkLogs", options.EnableNetworkLogs);
            AddAdditionalCapability(chromeOption, "browserstack.timezone", options.TimeZone);
            AddAdditionalCapability(chromeOption, "browserstack.console", "info");

            return new RemoteWebDriver(new Uri(options.ServerName), chromeOption);
        }

        private static void CheckBrowserStackLogin(BrowserStackSetting options)
        {
            if (options.User == null || options.Key == null)
                throw new Exception("Please enter browserstack credentials");
        }

        private static void AddAdditionalCapability(ChromeOptions chromeOptions, string capabilityName, object capabilityValue)
        {
            chromeOptions.AddAdditionalCapability(capabilityName, capabilityValue, true);
        }
    }
}
