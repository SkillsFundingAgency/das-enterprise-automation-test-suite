using NUnit.Framework;
using OpenQA.Selenium;
using Polly;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class ScreenshotHelper
    {
        public static void TakeScreenShot(IWebDriver webDriver, string screenshotsDirectory, string scenarioTitle, bool isFullpage, bool throwException)
        {
            string screenshotPath, imageName;

            (screenshotPath, imageName) = GetScreenShotDetails(screenshotsDirectory, scenarioTitle);

            if (isFullpage) TakeFullPageScreenShot(webDriver, imageName, screenshotPath, throwException);
            else TakeNormalScreenShot(webDriver, imageName, screenshotPath, throwException);
        }

        private static void TakeFullPageScreenShot(IWebDriver webDriver, string imageName, string screenshotPath, bool throwException)
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

                AddTestAttachment(screenshotPath, imageName);
            }
            catch (Exception exception)
            {
                TestContext.Progress.WriteLine(GetMessage("Full", imageName, screenshotPath, exception));

                TakeDesktopScreenShot(imageName, screenshotPath, throwException);
            }
        }

        private static void TakeDesktopScreenShot(string imageName, string screenshotPath, bool throwException)
        {
            try
            {
                using var bitmap = new Bitmap(1920, 1080);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(0, 0, 0, 0,
                    bitmap.Size, CopyPixelOperation.SourceCopy);
                }
                bitmap.Save("filename.jpg", ImageFormat.Jpeg);
            }
            catch (Exception exception)
            {
                var message = GetMessage("Desktop", imageName, screenshotPath, exception);

                if (throwException) throw new Exception(message);

                else TestContext.Progress.WriteLine(message);
            }
            
        }

        private static void TakeNormalScreenShot(IWebDriver webDriver, string imageName, string screenshotPath, bool throwException)
        {
            try
            {
                ITakesScreenshot screenshotHandler = webDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotHandler.GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                AddTestAttachment(screenshotPath, imageName);
            }
            catch (Exception exception)
            {
                var message = GetMessage("Normal", imageName, screenshotPath, exception);

                if (throwException) throw new Exception(message);

                else TestContext.Progress.WriteLine(message);
            }
        }

        private static string GetMessage(string x, string imageName, string screenshotPath, Exception exception) => $"Exception occurred while taking {x} screenshot - Path - '{screenshotPath}', ImageName - '{imageName}'" + exception;

        private static void AddTestAttachment(string screenshotPath, string imageName) => TestContext.AddTestAttachment(screenshotPath, imageName);

        private static (string screenshotPath, string imageName) GetScreenShotDetails(string screenshotsDirectory, string scenarioTitle)
        {           
            var imageName = $"{DateTime.Now:HH-mm-ss}_{scenarioTitle}.png".RemoveSpace();

            (string screenshotPath, string fileName) = new WindowsFileHelper().GetFileDetails(screenshotsDirectory, imageName);

            return (screenshotPath, fileName);
        }

    }
} 