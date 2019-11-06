using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class ScreenshotHelper
    {
        public static void TakeScreenShot(IWebDriver webDriver, string screenshotsDirectory, string scenarioTitle)
        {
            try
            {
                DateTime dateTime = DateTime.Now;

                String failureImageName = dateTime.ToString("HH-mm-ss")
                    + "_"
                    + scenarioTitle
                    + ".png";

                ITakesScreenshot screenshotHandler = webDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotHandler.GetScreenshot();
                String screenshotPath = Path.Combine(screenshotsDirectory, failureImageName);
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(screenshotPath, failureImageName);
            }
            catch (Exception exception)
            {
                TestContext.Progress.WriteLine("Exception occurred while taking screenshot - " + exception);
            }
        }
    }
}
