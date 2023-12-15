using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract class WebdriverAddCapabilities(ScenarioContext context)
{
    protected readonly ObjectContext objectContext = context.Get<ObjectContext>();

    protected readonly ScenarioContext context = context;

    protected void AddChromeCapabilities(IWebDriver webDriver)
    {
        var cap = AddBrowserCapabilities(webDriver);

        foreach (var item in cap["chrome"] as Dictionary<string, object>) objectContext.Replace(item.Key, item.Value);
    }

    protected void AddEdgeCapabilities(IWebDriver webDriver) => AddBrowserCapabilities(webDriver);

    protected void AddFireFoxCapabilities(IWebDriver webDriver) => AddBrowserCapabilities(webDriver);

    protected void AddIeCapabilities(IWebDriver webDriver) => AddBrowserCapabilities(webDriver);

    private ICapabilities AddBrowserCapabilities(IWebDriver webDriver)
    {
        var cap = (webDriver as WebDriver).Capabilities;

        objectContext.SetBrowserName(cap["browserName"]);

        objectContext.SetBrowserVersion(cap["browserVersion"]);

        return cap;
    }
}
