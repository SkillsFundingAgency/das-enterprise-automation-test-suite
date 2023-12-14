using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers;

public class TabHelper(IWebDriver webDriver, ObjectContext objectContext)
{
    public void OpenInNewTab(Action action)
    {
        var existingTabs = ExistingTabs();

        action.Invoke();

        var newtabs = ExistingTabs();

        var newtab = newtabs.Except(existingTabs).Single();

        webDriver = webDriver.SwitchTo().Window(newtab);
    }

    public void OpenInNewTab(string uriString, string relativeUri) => OpenInNewTab(GetUrl(uriString, relativeUri));

    public void GoToUrl(string uriString, string relativeUri) => GoToUrl(GetUrl(uriString, relativeUri));

    public void OpenNewTab() => webDriver.SwitchTo().NewWindow(WindowType.Tab);

    public void OpenInNewTab(string url) { OpenNewTab(); GoToUrl(url); }

    public void GoToUrl(string url)
    {
        webDriver.Navigate().GoToUrl(url);

        objectContext.SetDebugInformation($"Navigated to {url}");
    }

    public void NavigateBrowserBack() => webDriver.Navigate().Back();

    public void SwitchToFirstTab() => webDriver = webDriver.SwitchTo().Window(webDriver.WindowHandles.First());

    private ReadOnlyCollection<string> ExistingTabs() => webDriver.WindowHandles;

    private string GetUrl(string uriString, string relativeUri) => UriHelper.GetAbsoluteUri(uriString, relativeUri);
}
