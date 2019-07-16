using OpenQA.Selenium;
using System;
using System.IO;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class ScreenshotHelper
    {
        public static void TakeScreenShot(IWebDriver webDriver, string scenarioTitle)
        {
            try
            {
                DateTime dateTime = DateTime.Now;

                String failureImageName = dateTime.ToString("HH-mm-ss")
                    + "_"
                    + scenarioTitle
                    + ".png";
                String screenshotsDirectory = AppDomain.CurrentDomain.BaseDirectory
                    + "../../"
                    + "\\Project\\Screenshots\\"
                    + dateTime.ToString("dd-MM-yyyy")
                    + "\\";
                if (!Directory.Exists(screenshotsDirectory))
                {
                    Directory.CreateDirectory(screenshotsDirectory);
                }

                ITakesScreenshot screenshotHandler = webDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotHandler.GetScreenshot();
                String screenshotPath = Path.Combine(screenshotsDirectory, failureImageName);
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                Console.WriteLine($"{scenarioTitle} -- Scenario under feature failed and the screenshot is available at -- {screenshotPath}");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occurred while taking screenshot - " + exception);
            }
        }
    }
}
