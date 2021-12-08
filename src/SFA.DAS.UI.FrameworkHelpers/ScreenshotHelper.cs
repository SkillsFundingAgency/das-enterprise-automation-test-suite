using NUnit.Framework;
using OpenQA.Selenium;
using Polly;
using System;
using System.IO;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class ScreenshotHelper
    {
        public static void TakeFullPageScreenShot(IWebDriver webDriver, string screenshotsDirectory, string scenarioTitle)
        {
            var imageName = $"{DateTime.Now:HH-mm-ss}_{scenarioTitle}.png".RemoveSpace();
            var screenshotPath = Path.Combine(screenshotsDirectory, imageName);
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
                    .WaitAndRetry(Logging.ScreenshotTimeout(), 
                        (result, timespan, retryCount, context) => { Report(retryCount, screenshotPath, imageName, result); })
                    .Execute(() => (string)js.ExecuteScript("return canvasImgContentDecoded;"));

                pngContent = pngContent.Replace("data:image/png;base64,", string.Empty);

                File.WriteAllBytes(screenshotPath, Convert.FromBase64String(pngContent));

                TestContext.AddTestAttachment(screenshotPath, imageName);
            }
            catch (Exception exception)
            {
                TestContext.Progress.WriteLine($"Exception occurred while taking full screenshot - Path - '{screenshotPath}', ImageName - '{imageName}'" + exception);

                TakeScreenShot(webDriver, imageName, screenshotPath);
            }
        }

        private static void Report(int retryCount, string screenshotPath, string imageName, DelegateResult<string> result)
        {
            TestContext.Progress.WriteLine($"Exception or no result occurred on retry while taking full screenshot - {Environment.NewLine}" +
                $"RetryCount '{retryCount}' - Path - '{screenshotPath}', ImageName - '{imageName}'{Environment.NewLine}" +
                $"with exception - {result?.Exception?.Message}");
        }

        private static void TakeScreenShot(IWebDriver webDriver, string imageName, string screenshotPath)
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