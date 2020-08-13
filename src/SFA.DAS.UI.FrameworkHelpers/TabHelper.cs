using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class TabHelper
    {
        private IWebDriver _webDriver;

        public TabHelper(IWebDriver webDriver) => _webDriver = webDriver;

        private By Iframe => By.CssSelector("iframe");

        public void SwitchToFrame() => SwitchToFrame(Iframe);

        public void SwitchToFrame(By by) => _webDriver.SwitchTo().Frame(_webDriver.FindElement(by));

        public void SwitchToDefaultContent() => _webDriver.SwitchTo().DefaultContent();

        public void OpenInNewTab(Action action)
        {
            var existingTabs = ExistingTabs();

            action.Invoke();

            var newtabs = ExistingTabs();

            var newtab = newtabs.Except(existingTabs).Single();

            _webDriver = _webDriver.SwitchTo().Window(newtab);
        }

        public void SwitchToFirstTab() => _webDriver = _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());

        public void OpenInNewTab(string uriString, string relativeUri) => OpenInNewTab(GetUrl(uriString, relativeUri));

        public void GoToUrl(string uriString, string relativeUri) => GoToUrl(GetUrl(uriString, relativeUri));
        
        public void OpenInNewTab(string url) => OpenInNewTab(() => ((IJavaScriptExecutor)_webDriver).ExecuteScript($"window.open('{url}','_blank');"));

        public void GoToUrl(string url) => _webDriver.Navigate().GoToUrl(url);

        public void NavigateBrowserBack() => _webDriver.Navigate().Back();

        private ReadOnlyCollection<string> ExistingTabs() => _webDriver.WindowHandles;

        private string GetUrl(string uriString, string relativeUri) => new Uri(new Uri(uriString), relativeUri).AbsoluteUri;
    }
}
