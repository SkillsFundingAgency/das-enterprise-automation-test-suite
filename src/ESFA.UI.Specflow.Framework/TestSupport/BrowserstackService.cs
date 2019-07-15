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
        
           

        private static readonly string _buildDateTime;

        static BrowserStackService()
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

            var chromeOption = new ChromeOptions();
            chromeOption.AcceptInsecureCertificates = true;
            chromeOption.AddAdditionalCapability("browser", options.BrowserstackBrowser, true);
            chromeOption.AddAdditionalCapability("browser_version", options.BrowserstackBrowserVersion,true);
            chromeOption.AddAdditionalCapability("os", options.BrowserstackOs, true);
            chromeOption.AddAdditionalCapability("os_version", options.BrowserstackOsversion, true);
            chromeOption.AddAdditionalCapability("resolution", options.Resolution, true);
            chromeOption.AddAdditionalCapability("browserstack.user", options.BrowserstackUsername, true);
            chromeOption.AddAdditionalCapability("browserstack.key", options.BrowserstackPassword, true);
            chromeOption.AddAdditionalCapability("project", options.BrowserstackProject, true);
            chromeOption.AddAdditionalCapability("browserstack.debug", "true", true);
            chromeOption.AddAdditionalCapability("name", options.TestName, true);
            return new RemoteWebDriver(new Uri($"http://{options.BrowserstackServerName}/wd/hub/"), chromeOption);
        }

        
    }
}
