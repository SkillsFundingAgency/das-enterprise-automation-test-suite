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
            var handle = _webDriver.CurrentWindowHandle;

            ((IJavaScriptExecutor)_webDriver).ExecuteScript($"window.open('{url}','_blank');");

            var handles = _webDriver.WindowHandles;

            var newWindow = handles.FirstOrDefault(x => x != handle);

            _webDriver.SwitchTo().Window(newWindow);
        }
    }
}
