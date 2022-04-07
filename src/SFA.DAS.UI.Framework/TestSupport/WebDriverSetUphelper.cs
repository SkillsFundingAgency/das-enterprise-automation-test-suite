using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class WebDriverSetupHelper : WebdriverAddCapabilities
    {
        private IWebDriver WebDriver;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly FrameworkConfig _frameworkConfig;

        public WebDriverSetupHelper(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _frameworkConfig = context.Get<FrameworkConfig>();
        }

        public IWebDriver SetupWebDriver()
        {
            var browser = _objectContext.GetBrowser();

            switch (true)
            {
                case bool _ when browser.IsFirefox():
                    WebDriver = FirefoxDriver();
                    break;

                case bool _ when browser.IsChrome():
                    WebDriver = ChromeDriver(new List<string>());
                    break;

                case bool _ when browser.IsEdge():
                    WebDriver = EdgeDriver();
                    break;

                case bool _ when browser.IsIe():
                    WebDriver = new InternetExplorerDriver(_objectContext.GetIeDriverLocation());
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
            WebDriver.SwitchTo().Window(WebDriver.CurrentWindowHandle);
            WebDriver.Manage().Cookies.DeleteAllCookies();

            _context.SetWebDriver(WebDriver);

            return WebDriver;
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

            WebDriver = new ChromeDriver(_objectContext.GetChromeDriverLocation(), chromeOptions);
        }

        private FirefoxDriver FirefoxDriver()
        {
            var firefoxDriver = new FirefoxDriver(_objectContext.GetFireFoxDriverLocation());

            AddEdgeCapabilities(firefoxDriver);

            return firefoxDriver;
        }

        private EdgeDriver EdgeDriver()
        {
            var edgedriver = new EdgeDriver(_objectContext.GetEdgeDriverLocation());

            AddEdgeCapabilities(edgedriver);

            return edgedriver;
        }

        private ChromeDriver ChromeDriver(List<string> arguments)
        {
            arguments.Add("no-sandbox");
            
            arguments.Add("ignore-certificate-errors");
            
            var chromedriver =  new ChromeDriver(_objectContext.GetChromeDriverLocation(),AddArguments(arguments),TimeSpan.FromMinutes(_frameworkConfig.TimeOutConfig.CommandTimeout));
            
            AddChromeCapabilities(chromedriver);

            return chromedriver;
        }

        private ChromeOptions AddArguments(List<string> arguments)
        {
            var chromeOptions = new ChromeOptions();
            arguments.ForEach((x) => chromeOptions.AddArgument(x));
            chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            chromeOptions.PageLoadStrategy = PageLoadStrategy.None;
            return chromeOptions;
        }
    }
}
