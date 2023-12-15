using OpenQA.Selenium;
using System;

namespace SFA.DAS.UI.FrameworkHelpers;

public class IFrameHelper(IWebDriver webDriver)
{
    public static By Iframe => By.CssSelector("iframe");

    public void SwitchToFrame() => SwitchToFrame(Iframe);

    public void SwitchToFrame(By by) => webDriver.SwitchTo().Frame(webDriver.FindElement(by));

    public void SwitchToDefaultContent() => webDriver.SwitchTo().DefaultContent();

    public void SwitchFrameAndAction(Action action)
    {
        SwitchToFrame();
        action.Invoke();
        SwitchToDefaultContent();
    }
}
