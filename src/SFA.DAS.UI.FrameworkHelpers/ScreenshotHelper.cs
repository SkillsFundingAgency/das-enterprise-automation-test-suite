using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class ScreenshotHelper
    {
        public static void TakeScreenShot(IWebDriver webDriver, string screenshotsDirectory, string scenarioTitle)
        {
            var imageName = $"{DateTime.Now:HH-mm-ss}_{scenarioTitle}.png".RemoveSpace();
            var screenshotPath = Path.Combine(screenshotsDirectory, imageName);

            try
            {
                ITakesScreenshot screenshotHandler = webDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotHandler.GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(screenshotPath, imageName);
            }
            catch (Exception exception)
            {
                TestContext.Progress.WriteLine($"Exception occurred while taking screenshot - Path - '{screenshotPath}', ImageName - '{imageName}'" + exception);
            }
        }

        public static void TakeFullPageScreenShot(IWebDriver webDriver, string screenshotsDirectory, string scenarioTitle)
        {
            var imageName = $"{DateTime.Now:HH-mm-ss}_{scenarioTitle}.png".RemoveSpace();
            var screenshotPath = Path.Combine(screenshotsDirectory, imageName);
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                var html2canvasJs = File.ReadAllText($"{GetAssemblyDirectory()}html2canvas.js");
                js.ExecuteScript(html2canvasJs);
                string generateScreenshotJS = @"function genScreenshot () { var canvasImgContentDecoded; html2canvas(document.body).then(function(canvas) { window.canvasImgContentDecoded = canvas.toDataURL(""image/png""); }); } genScreenshot();";
                js.ExecuteScript(generateScreenshotJS);
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                wait.IgnoreExceptionTypes(typeof(InvalidOperationException));
                wait.Until(
                wd =>
                {
                    string response = (string)js.ExecuteScript("return (typeof canvasImgContentDecoded === 'undefined' || canvasImgContentDecoded === null)");

                    return string.IsNullOrEmpty(response) ? false : bool.Parse(response);
                });

                wait.Until(wd => !string.IsNullOrEmpty((string)js.ExecuteScript("return canvasImgContentDecoded;")));

                var pngContent = (string)js.ExecuteScript("return canvasImgContentDecoded;");

                pngContent = pngContent.Replace("data:image/png;base64,", string.Empty);

                var tempFilePath = Path.GetTempFileName().Replace(".tmp", ".png");

                File.WriteAllBytes(tempFilePath, Convert.FromBase64String(pngContent));

                File.Copy(tempFilePath, screenshotPath);

                TestContext.AddTestAttachment(screenshotPath, imageName);
            }
            catch (Exception exception)
            {

                TestContext.Progress.WriteLine($"Exception occurred while taking screenshot - Path - '{screenshotPath}', ImageName - '{imageName}'" + exception);
            }
        }

        private static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().Location;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}