using OpenQA.Selenium;

namespace SFA.DAS.UI.FrameworkHelpers;

public class JavaScriptHelper(IWebDriver webDriver, IFrameHelper iframeHelper)
{
    public static bool IsDocumentReady(IWebDriver driver) => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");

    public void SetTextUsingJavaScript(By locator, string text)
    {
        ((IJavaScriptExecutor)webDriver).ExecuteScript($"arguments[0].value='{text}'", webDriver.FindElement(locator));
    }

    public void SwitchFrameAndEnterText(By iFrameFieldLocator, By iFrameBodyLocator, string text)
    {
        iframeHelper.SwitchToFrame(iFrameFieldLocator);
        ((IJavaScriptExecutor)webDriver).ExecuteScript($"arguments[0].innerHTML = '{text}'", webDriver.FindElement(iFrameBodyLocator));
        iframeHelper.SwitchToDefaultContent();
    }

    public void ClickElement(By locator)
    {
        var webElement = webDriver.FindElement(locator);
        ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", webElement);
    }

    public void ScrollToTheBottom()
    {
        var jse = (IJavaScriptExecutor)webDriver;
        jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
    }
}