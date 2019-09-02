using OpenQA.Selenium;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    internal class TabHelper
    {
        private readonly IWebDriver _webDriver;

        internal TabHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        internal void OpenInNewtab(string url)
        {
            var existingTabs = _webDriver.WindowHandles;

            ((IJavaScriptExecutor)_webDriver).ExecuteScript($"window.open('{url}','_blank');");

            var newtabs = _webDriver.WindowHandles;

            var newtab = newtabs.Except(existingTabs).Single();

            _webDriver.SwitchTo().Window(newtab);
        }
    }
}
