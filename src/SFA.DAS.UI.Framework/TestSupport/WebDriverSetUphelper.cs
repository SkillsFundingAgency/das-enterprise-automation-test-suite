using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public class WebDriverSetupHelper(ScenarioContext context) : WebdriverAddCapabilities(context)
{
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
    private readonly FrameworkConfig _frameworkConfig = context.Get<FrameworkConfig>();

    public IWebDriver SetupWebDriver()
    {
        var WebDriver = GetWebDriver(_objectContext.GetBrowser());

        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_frameworkConfig.TimeOutConfig.ImplicitWait);
        WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_frameworkConfig.TimeOutConfig.PageLoad);
        WebDriver.Manage().Cookies.DeleteAllCookies();

        WebDriver.SwitchTo().Window(WebDriver.CurrentWindowHandle);

        context.SetWebDriver(WebDriver);

        return WebDriver;
    }

    private IWebDriver GetWebDriver(string browser)
    {
        return true switch
        {
            _ when browser.IsFirefox() => FirefoxDriver(),
            _ when browser.IsChrome() => ChromeDriver([]),
            _ when browser.IsEdge() => EdgeDriver(),
            _ when browser.IsZap() => InitialiseZapProxyChrome(),
            _ when browser.IsChromeHeadless() => ChromeDriver(["--headless"]),
            _ => throw new Exception("Driver name - " + browser + " does not match OR this framework does not support the webDriver specified")
        };
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

    private FirefoxDriver FirefoxDriver()
    {
        var webdriver = new FirefoxDriver(_objectContext.GetFireFoxDriverLocation());

        AddFireFoxCapabilities(webdriver);

        return webdriver;
    }

    private EdgeDriver EdgeDriver()
    {
        var edgeOptions = new EdgeOptions();

        AddDownloadsDirectory(edgeOptions);

        var webdriver = new EdgeDriver(_objectContext.GetEdgeDriverLocation(), edgeOptions);

        AddEdgeCapabilities(webdriver);

        return webdriver;
    }

    private ChromeDriver ChromeDriver(List<string> arguments)
    {
        var webdriver = new ChromeDriver(_objectContext.GetChromeDriverLocation(), AddArguments(arguments), TimeSpan.FromMinutes(_frameworkConfig.TimeOutConfig.CommandTimeout));

        AddChromeCapabilities(webdriver);

        return webdriver;
    }

    private ChromeOptions AddArguments(List<string> arguments)
    {
        var chromeOptions = new ChromeOptions();

        arguments.ForEach(chromeOptions.AddArgument);

        AddDownloadsDirectory(chromeOptions);

        chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;

        chromeOptions.PageLoadStrategy = PageLoadStrategy.None;

        return chromeOptions;
    }

    private void AddDownloadsDirectory(ChromiumOptions chromiumOptions)
    {
        if (tags.Contains("setdownloadsdirectory"))
        {
            chromiumOptions.AddUserProfilePreference("download.default_directory", FileHelper.GetDownloadsDirectoryPath());
        }
    }
}
