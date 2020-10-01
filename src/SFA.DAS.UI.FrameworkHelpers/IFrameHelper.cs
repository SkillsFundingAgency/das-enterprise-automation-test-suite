using OpenQA.Selenium;
using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class IFrameHelper
    {
        private readonly IWebDriver _webDriver;

        public IFrameHelper(IWebDriver webDriver) => _webDriver = webDriver;

        public By Iframe => By.CssSelector("iframe");

        public void SwitchToFrame() => SwitchToFrame(Iframe);

        public void SwitchToFrame(By by) => _webDriver.SwitchTo().Frame(_webDriver.FindElement(by));

        public void SwitchToDefaultContent() => _webDriver.SwitchTo().DefaultContent();

        public void SwitchFrameAndAction(Action action)
        {
            SwitchToFrame();
            action.Invoke();
            SwitchToDefaultContent();
        }
    }
}
