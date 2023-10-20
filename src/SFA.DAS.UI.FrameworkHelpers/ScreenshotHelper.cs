using NUnit.Framework;
using OpenQA.Selenium;
using Polly;
using SFA.DAS.FrameworkHelpers;
using System;
using System.IO;

namespace SFA.DAS.UI.FrameworkHelpers;

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
            TestContext.Progress.WriteLine($"Exception occurred while taking full screenshot - Path - '{screenshotPath}', ImageName - '{imageName}'" + exception);

            TakeNormalScreenShot(webDriver, imageName, screenshotPath, throwException);
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
            var message = $"Exception occurred while taking screenshot - Path - '{screenshotPath}', ImageName - '{imageName}'" + exception;

            if (throwException) throw new Exception(message);
            else TestContext.Progress.WriteLine(message);
        }
    }

    private static void AddTestAttachment(string screenshotPath, string imageName) => TestContext.AddTestAttachment(screenshotPath, imageName);

    private static (string screenshotPath, string imageName) GetScreenShotDetails(string screenshotsDirectory, string scenarioTitle)
    {           
        var imageName = $"{DateTime.Now:HH-mm-ss}_{scenarioTitle}.png".RemoveSpace();

        (string screenshotPath, string fileName) = new WindowsFileHelper().GetFileDetails(screenshotsDirectory, imageName);

        return (screenshotPath, fileName);
    }

}
