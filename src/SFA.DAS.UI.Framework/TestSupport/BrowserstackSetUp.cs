using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium.Chrome;

namespace SFA.DAS.UI.Framework.Project.Tests.TestSupport
{
    public class BrowserStackSetUp
    {
        private static readonly string _buildDateTime;

        static BrowserStackSetUp()
        {
            _buildDateTime = DateTime.Now.ToString("ddMMMyyyy HH:mm").ToUpper();
        }

        private static void CheckBrowserStackLogin(JsonConfig options)
        {
            if (options.BrowserstackUsername == null || options.BrowserstackPassword == null)
                throw new Exception("Please enter browserstack credentials");
        }

        public static IWebDriver Init(JsonConfig options)
        {
            CheckBrowserStackLogin(options);

            var chromeOption = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };
            AddAdditionalCapability(chromeOption, "browser", options.BrowserstackBrowser);
            AddAdditionalCapability(chromeOption, "browser_version", options.BrowserstackBrowserVersion);
            AddAdditionalCapability(chromeOption, "os", options.BrowserstackOs);
            AddAdditionalCapability(chromeOption, "os_version", options.BrowserstackOsversion);
            AddAdditionalCapability(chromeOption, "resolution", options.Resolution);
            AddAdditionalCapability(chromeOption, "browserstack.user", options.BrowserstackUsername);
            AddAdditionalCapability(chromeOption, "browserstack.key", options.BrowserstackPassword);
            AddAdditionalCapability(chromeOption, "project", options.BrowserstackProject);
            AddAdditionalCapability(chromeOption, "browserstack.debug", "true");
            AddAdditionalCapability(chromeOption, "name", options.TestName);

            return new RemoteWebDriver(new Uri($"http://{options.BrowserstackServerName}/wd/hub/"), chromeOption);
        }

        private static void AddAdditionalCapability(ChromeOptions chromeOptions, string capabilityName, object capabilityValue)
        {
            chromeOptions.AddAdditionalCapability(capabilityName, capabilityValue, true);
        }
    }
}
