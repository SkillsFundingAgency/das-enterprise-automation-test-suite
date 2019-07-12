using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    public class BrowserStackService
    {
        
        public static NameValueCollection Settings { get; set; }
        public static NameValueCollection Environments { get; set; }

        private static readonly string _buildDateTime;

        static BrowserStackService()
        {
            _buildDateTime = DateTime.Now.ToString("ddMMMyyyy HH:mm").ToUpper();
        }

        private static void CheckBrowserStackSettings()
        {
            if (Environments == null || Settings == null)
                throw new Exception("Invalid BrowserStack settings. Please, check available options in app.config or extend the last one.");
        }

        public static IWebDriver Init(JsonConfig config)
        {
            //CheckBrowserStackSettings();

            var chromeOption = new ChromeOptions();
            chromeOption.AcceptInsecureCertificates = true;
            chromeOption.AddAdditionalCapability("browser", config.BrowserstackBrowser, true);
            chromeOption.AddAdditionalCapability("browser_version", config.BrowserstackBrowserVersion,true);
            chromeOption.AddAdditionalCapability("os", config.BrowserstackOs, true);
            chromeOption.AddAdditionalCapability("os_version", config.BrowserstackOsversion, true);
            chromeOption.AddAdditionalCapability("resolution", config.Resolution, true);
            chromeOption.AddAdditionalCapability("browserstack.user", config.BrowserstackUsername, true);
            chromeOption.AddAdditionalCapability("browserstack.key", config.BrowserstackPassword, true);
            chromeOption.AddAdditionalCapability("project", config.BrowserstackProject, true);
            chromeOption.AddAdditionalCapability("browserstack.debug", "true", true);
            chromeOption.AddAdditionalCapability("name", config.TestName, true);
            return new RemoteWebDriver(new Uri($"http://{config.BrowserstackServerName}/wd/hub/"), chromeOption);
        }

        
    }
}
