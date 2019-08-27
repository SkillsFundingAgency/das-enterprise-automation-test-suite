using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SFA.DAS.UI.Framework.Project.Tests.TestSupport;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class WebDriverSetup
    {
        private readonly string DriverPath;

        private IWebDriver WebDriver;

        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly FrameworkConfig _frameworkConfig;

        private const string ChromeDriverServiceName = "chromedriver.exe";

        private const string FirefoxDriverServiceName = "geckodriver.exe";

        private const string InternetExplorerDriverServiceName = "IEDriverServer.exe";

        public WebDriverSetup(ScenarioContext context)
        {
            DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _frameworkConfig = context.Get<FrameworkConfig>();
        }


        [BeforeScenario(Order = 3)]
        public void SetupWebDriver()
        {
            var browser = _objectContext.GetBrowser();
            
            switch (true)
            {
                case bool _ when browser.IsFirefox():
                    WebDriver = new FirefoxDriver(FindDriverService(FirefoxDriverServiceName));
                    WebDriver.Manage().Window.Maximize();
                    break;

                case bool _ when browser.IsChrome():

                    WebDriver = ChromeDriver(new List<string>());
                    break;

                case bool _ when browser.IsIe():
                    WebDriver = new InternetExplorerDriver(FindDriverService(InternetExplorerDriverServiceName));
                    WebDriver.Manage().Window.Maximize();
                    break;

                case bool _ when browser.IsZap():
                    InitialiseZapProxyChrome();
                    break;

                case bool _ when browser.IsChromeHeadless():
                    WebDriver = ChromeDriver(new List<string>() { "--headless" });
                    break;
               

                case bool _ when browser.IsCloudExecution():
                    _frameworkConfig.BrowserStackSetting.Name = _context.ScenarioInfo.Title;
                    WebDriver = BrowserStackSetup.Init(_frameworkConfig.BrowserStackSetting);
                    break;

                default:
                    throw new Exception("Driver name - " + browser + " does not match OR this framework does not support the webDriver specified");
            }

            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_frameworkConfig.TimeOutConfig.PageNavigation);
            var currentWindow = WebDriver.CurrentWindowHandle;
            WebDriver.SwitchTo().Window(currentWindow);
            WebDriver.Manage().Cookies.DeleteAllCookies();

            _context.SetWebDriver(WebDriver);
        }

        private string FindDriverService(string executableName)
        {
            TestContext.Progress.WriteLine($"DriverPath : {DriverPath}, Executable Name : {executableName}");

            FileInfo[] file = Directory.GetParent(DriverPath).GetFiles(executableName, SearchOption.AllDirectories);

            var info = file.Length != 0 ? file[0].DirectoryName : DriverPath;

            TestContext.Progress.WriteLine($"Driver Service should be available under: {info}");

            return info;
        }

        private void InitialiseZapProxyChrome()
        {
            const string PROXY = "localhost:8080";
            var chromeOptions = new ChromeOptions();
            var proxy = new Proxy
            {
                HttpProxy = PROXY,
                SslProxy = PROXY,
                FtpProxy = PROXY
            };
            chromeOptions.Proxy = proxy;

            WebDriver = new ChromeDriver(FindDriverService(ChromeDriverServiceName), chromeOptions);
        }

        private ChromeDriver ChromeDriver(List<string> arguments)
        {
            arguments.Add("no-sandbox");
            return new ChromeDriver(FindDriverService(ChromeDriverServiceName),
                                                 AddArguments(arguments),
                                                 TimeSpan.FromMinutes(_frameworkConfig.TimeOutConfig.CommandTimeout));
        }

        private ChromeOptions AddArguments(List<string> arguments)
        {
            var chromeOptions = new ChromeOptions();
            arguments.ForEach((x) => chromeOptions.AddArgument(x));
            return chromeOptions;
        }
    }
}
