using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SFA.DAS.UI.Framework.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.BeforeScenario
{
    [Binding]
    public class WebDriverSetUp
    {
        private static readonly string DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private IWebDriver WebDriver;

        private readonly ScenarioContext _context;

        public WebDriverSetUp(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 11)]
        public void SetUpWebDriver()
        {
            var options = _context.Get<JsonConfig>();
            var browser = options.Browser;
            
            switch (true)
            {
                case bool _ when browser.IsFirefox():
                    WebDriver = new FirefoxDriver(DriverPath);
                    WebDriver.Manage().Window.Maximize();
                    break;

                case bool _ when browser.IsChrome():
                    WebDriver = new ChromeDriver(DriverPath);
                    break;

                case bool _ when browser.IsIe():
                    WebDriver = new InternetExplorerDriver(DriverPath);
                    WebDriver.Manage().Window.Maximize();
                    break;

                case bool _ when browser.IsZap():
                    InitialiseZapProxyChrome();
                    break;

                case bool _ when browser.IsCloudExecution():
                    WebDriver = BrowserStackSetUp.Init(options.BrowserStackSetting);
                    break;

                default:
                    throw new Exception("Driver name - " + browser + " does not match OR this framework does not support the webDriver specified");
            }

            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var currentWindow = WebDriver.CurrentWindowHandle;
            WebDriver.SwitchTo().Window(currentWindow);
            WebDriver.Manage().Cookies.DeleteAllCookies();

            _context.Set(WebDriver, "webdriver");
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

            WebDriver = new ChromeDriver(DriverPath, chromeOptions);
        }
    }
}
