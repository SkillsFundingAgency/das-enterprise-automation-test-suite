using OpenQA.Selenium;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class JavaScriptHelper
    {
        private readonly IWebDriver _webDriver;
        private readonly IFrameHelper _iframeHelper;

        public JavaScriptHelper(IWebDriver webDriver, IFrameHelper iframeHelper)
        {
            _webDriver = webDriver;
            _iframeHelper = iframeHelper;
        }

        public bool IsDocumentReady(IWebDriver driver) => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");

        public string GetTextUsingJavaScript(By iFrameBodyLocator)
        {
            var text = ((IJavaScriptExecutor)_webDriver).ExecuteScript($"return arguments[0].innerHTML", _webDriver.FindElement(iFrameBodyLocator));
            return (string)text;
        }

        public void SetTextUsingJavaScript(By locator, string text)
        {
            ((IJavaScriptExecutor)_webDriver).ExecuteScript($"arguments[0].value='{text}'", _webDriver.FindElement(locator));
        }

        public void SwitchFrameAndEnterText(By iFrameFieldLocator, By iFrameBodyLocator, string text)
        {
            _iframeHelper.SwitchToFrame(iFrameFieldLocator);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript($"arguments[0].innerHTML = '{text}'", _webDriver.FindElement(iFrameBodyLocator));
            _iframeHelper.SwitchToDefaultContent();
        }

        public void ClickElement(By locator)
        {
            var webElement = _webDriver.FindElement(locator);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].click();", webElement);
        }

        public void ScrollToTheBottom()
        {
            var jse = (IJavaScriptExecutor)_webDriver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }
    }
}
