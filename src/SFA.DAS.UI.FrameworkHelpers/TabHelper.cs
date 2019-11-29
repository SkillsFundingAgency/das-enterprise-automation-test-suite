using OpenQA.Selenium;
using System.Linq;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class TabHelper
    {
        private IWebDriver _webDriver;

        public TabHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void OpenInNewtab(string url)
        {
            var existingTabs = _webDriver.WindowHandles;

            ((IJavaScriptExecutor)_webDriver).ExecuteScript($"window.open('{url}','_blank');");

            var newtabs = _webDriver.WindowHandles;

            var newtab = newtabs.Except(existingTabs).Single();

            _webDriver = _webDriver.SwitchTo().Window(newtab);
        }

        public void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public void NavigateBrowserBack()
        {
            _webDriver.Navigate().Back();
        }
    }
}
