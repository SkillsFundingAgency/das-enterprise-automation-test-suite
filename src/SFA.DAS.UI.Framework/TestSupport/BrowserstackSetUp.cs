using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.UI.Framework.TestSupport;

public static class BrowserStackSetup
{
    private static readonly string _buildDateTime, _buildDate;

    static BrowserStackSetup()
    {
        var date = DateTime.Now;
        _buildDate = date.ToString("ddMMMyyyy").ToUpper();
        _buildDateTime = date.ToString("ddMMMyyyy_HH:mm:ss").ToUpper();
    }

    public static IWebDriver Init(BrowserStackSetting options)
    {
        CheckBrowserStackLogin(options);

        var remoteWebDriver = new RemoteWebDriver(new Uri(options.ServerName), GetDriverOptions(options));

        if (remoteWebDriver is IAllowsFileDetection allowsDetection) allowsDetection.FileDetector = new LocalFileDetector();

        return remoteWebDriver;
    }

    private static DriverOptions GetDriverOptions(BrowserStackSetting options)
    {
        string browser = options.Browser;
        DriverOptions capabilities = true switch
        {
            bool _ when browser.IsFirefox() => new FirefoxOptions(),
            bool _ when browser.IsEdge() => new EdgeOptions(),
            bool _ when browser.IsChrome() => new ChromeOptions(),
            _ => throw new Exception("Browserstack : Driver name - " + browser + " does not match OR this framework does not support the webDriver specified"),
        };

        capabilities.BrowserVersion = options.BrowserVersion;
        capabilities.AcceptInsecureCertificates = true;
        capabilities.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;

        capabilities.AddAdditionalOption("bstack:options", SetBrowserstackCapabilities(options));

        return capabilities;
    }

    private static Dictionary<string, object> SetBrowserstackCapabilities(BrowserStackSetting options) =>
        new()
        {
            { "userName", options.User },
            { "accessKey", options.Key },
            { "os", options.Os },
            { "osVersion", options.Osversion },
            { "resolution", options.Resolution },
            { "projectName", $"{options.Project}_{_buildDate}" },
            { "buildName", $"{options.Build}_{EnvironmentConfig.EnvironmentName.ToUpper()}_{_buildDateTime}" },
            { "sessionName", options.Name },
            { "debug", "true" },
            { "networkLogs", options.EnableNetworkLogs },
            { "timezone", options.TimeZone },
            { "consoleLogs", "info" },
            { "idleTimeout", "300" },
            { "autoWait", "35" },
            { "maskCommands", "setValues, getValues, setCookies, getCookies" }
        };

    private static void CheckBrowserStackLogin(BrowserStackSetting options)
    {
        if (options.User == null || options.Key == null) throw new Exception("Please enter browserstack credentials");
    }
}
