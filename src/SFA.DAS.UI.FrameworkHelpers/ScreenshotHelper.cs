using NUnit.Framework;
using OpenQA.Selenium;
using Polly;
using System;
using System.IO;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class ScreenshotHelper
    {
        public static void TakeScreenShot(IWebDriver webDriver, string screenshotsDirectory, string scenarioTitle, bool isFullpage)
        {
            var imageName = $"{DateTime.Now:HH-mm-ss}_{scenarioTitle}.png".RemoveSpace();
            var screenshotPath = Path.Combine(screenshotsDirectory, imageName);

            if (isFullpage) TakeFullPageScreenShot(webDriver, imageName, screenshotPath);
            else TakeNormalScreenShot(webDriver, imageName, screenshotPath);
        }

        private static void TakeFullPageScreenShot(IWebDriver webDriver, string imageName, string screenshotPath)
        {
            var html2canvasJs = File.ReadAllText($"{Path.Combine(FileHelper.GetAssemblyDirectory(), "html2canvas.js")}");
            var generateScreenshotJS = @"function genScreenshot () { var canvasImgContentDecoded; html2canvas(document.body).then(function(canvas) { window.canvasImgContentDecoded = canvas.toDataURL(""image/png""); }); } genScreenshot();";

            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                    
                js.ExecuteScript(html2canvasJs);
                
                js.ExecuteScript(generateScreenshotJS);

                var pngContent = Policy
                    .Handle<WebDriverException>()
                    .OrResult<string>(r => string.IsNullOrEmpty(r))
                    .WaitAndRetry(10, x => TimeSpan.FromMilliseconds(250))
                    .Execute(() => (string)js.ExecuteScript("return canvasImgContentDecoded;"));

                pngContent = pngContent.Replace("data:image/png;base64,", string.Empty);

                File.WriteAllBytes(screenshotPath, Convert.FromBase64String(pngContent));

                TestContext.AddTestAttachment(screenshotPath, imageName);
            }
            catch (Exception exception)
            {
                TestContext.Progress.WriteLine($"Exception occurred while taking full screenshot - Path - '{screenshotPath}', ImageName - '{imageName}'" + exception);

                TakeNormalScreenShot(webDriver, imageName, screenshotPath);
            }
        }

        private static void TakeNormalScreenShot(IWebDriver webDriver, string imageName, string screenshotPath)
        {
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
    }
}