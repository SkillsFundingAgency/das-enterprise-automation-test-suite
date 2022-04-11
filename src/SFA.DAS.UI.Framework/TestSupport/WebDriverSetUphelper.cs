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
            var WebDriver = GetWebDriver(_objectContext.GetBrowser());

            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_frameworkConfig.TimeOutConfig.ImplicitWait);
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_frameworkConfig.TimeOutConfig.PageLoad);
            WebDriver.Manage().Cookies.DeleteAllCookies();

            WebDriver.SwitchTo().Window(WebDriver.CurrentWindowHandle);

            _context.SetWebDriver(WebDriver);

            return WebDriver;
        }

        private IWebDriver GetWebDriver(string browser)
        {
            return true switch
            {
                _ when browser.IsFirefox() => FirefoxDriver(),
                _ when browser.IsChrome() => ChromeDriver(new List<string>()),
                _ when browser.IsEdge() => EdgeDriver(),
                _ when browser.IsIe() => InternetExplorerDriver(),
                _ when browser.IsZap() => InitialiseZapProxyChrome(),
                _ when browser.IsChromeHeadless() => ChromeDriver(new List<string>() { "--headless" }),
                _ when browser.IsCloudExecution() => SetUpBrowserStack(),
                _ => throw new Exception("Driver name - " + browser + " does not match OR this framework does not support the webDriver specified")
            };
        }

        private IWebDriver SetUpBrowserStack()
        {
            _frameworkConfig.BrowserStackSetting.Name = _context.ScenarioInfo.Title;
            
            return BrowserStackSetup.Init(_frameworkConfig.BrowserStackSetting);
        }

        private ChromeDriver InitialiseZapProxyChrome()
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

            var webdriver = new ChromeDriver(_objectContext.GetChromeDriverLocation(), chromeOptions);

            AddChromeCapabilities(webdriver);

            return webdriver;
        }

        private InternetExplorerDriver InternetExplorerDriver()
        {
            var webdriver = new InternetExplorerDriver(_objectContext.GetIeDriverLocation());

            AddIeCapabilities(webdriver);

            return webdriver;
        }

        private FirefoxDriver FirefoxDriver()
        {
            var webdriver = new FirefoxDriver(_objectContext.GetFireFoxDriverLocation());

            AddFireFoxCapabilities(webdriver);

            return webdriver;
        }

        private EdgeDriver EdgeDriver()
        {
            var webdriver = new EdgeDriver(_objectContext.GetEdgeDriverLocation());

            AddEdgeCapabilities(webdriver);

            return webdriver;
        }

        private ChromeDriver ChromeDriver(List<string> arguments)
        {
            arguments.Add("no-sandbox");
            
            arguments.Add("ignore-certificate-errors");

            var webdriver = new ChromeDriver(_objectContext.GetChromeDriverLocation(), AddArguments(arguments), TimeSpan.FromMinutes(_frameworkConfig.TimeOutConfig.CommandTimeout));
            
            AddChromeCapabilities(webdriver);

            return webdriver;
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
