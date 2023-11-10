using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers;

public class TabHelper
{
    private IWebDriver _webDriver;
    private readonly ObjectContext _objectContext;

    public TabHelper(IWebDriver webDriver, ObjectContext objectContext)
    {
        _webDriver = webDriver;

        _objectContext = objectContext;
    }
    
    public void OpenInNewTab(Action action)
    {
        var existingTabs = ExistingTabs();

        action.Invoke();

        var newtabs = ExistingTabs();

        var newtab = newtabs.Except(existingTabs).Single();

        _webDriver = _webDriver.SwitchTo().Window(newtab);
    }

    public void OpenInNewTab(string uriString, string relativeUri) => OpenInNewTab(GetUrl(uriString, relativeUri));

    public void GoToUrl(string uriString, string relativeUri) => GoToUrl(GetUrl(uriString, relativeUri));

    public void OpenNewTab() => _webDriver.SwitchTo().NewWindow(WindowType.Tab);

    public void OpenInNewTab(string url) { OpenNewTab(); GoToUrl(url); }

    public void GoToUrl(string url)
    {
        _webDriver.Navigate().GoToUrl(url);

        _objectContext.SetDebugInformation($"Navigated to {url}");
    }

    public void NavigateBrowserBack() => _webDriver.Navigate().Back();

    public void SwitchToFirstTab() => _webDriver = _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());

    private ReadOnlyCollection<string> ExistingTabs() => _webDriver.WindowHandles;

    private string GetUrl(string uriString, string relativeUri) => UriHelper.GetAbsoluteUri(uriString, relativeUri);
}
