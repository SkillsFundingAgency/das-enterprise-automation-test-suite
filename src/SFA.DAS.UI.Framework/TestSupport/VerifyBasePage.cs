using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.TestDataExport;
using System.Linq;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class VerifyBasePage : BasePage
    {
        #region Helpers and Context
        private readonly IWebDriver _webDriver;
        private readonly ScreenShotTitleGenerator _screenShotTitleGenerator;
        private readonly string _directory;
        private bool _takescreenshot;
        #endregion

        protected VerifyBasePage(ScenarioContext context) : base(context)
        {
            _takescreenshot = true;
            _webDriver = context.GetWebDriver();
            _screenShotTitleGenerator = context.Get<ScreenShotTitleGenerator>();
            _directory = objectContext.GetDirectory();

            if (CanCaptureUrl()) objectContext.SetAuthUrl(_webDriver.Url);
        }

        protected bool MultipleVerifyPage(List<Func<bool>> testDelegate)
        {
            return VeriFyPage(() => 
            {
                _takescreenshot = false;

                bool result = true;

                foreach (var item in testDelegate)
                {
                    result = result && item();
                }

                _takescreenshot = true;

                return result;
            });
        }

        protected bool VerifyPage() => VerifyPage(PageHeader, PageTitle);

        protected bool VerifyPageAfterRefresh(By locator) => VeriFyPage(() => pageInteractionHelper.VerifyPageAfterRefresh(locator));

        protected bool VerifyPage(Func<List<IWebElement>> func) => VerifyPage(func, PageTitle);

        protected bool VerifyPage(Func<List<IWebElement>> func, string expected) => VeriFyPage(() => pageInteractionHelper.VerifyPage(func, expected));

        protected bool VerifyElement(Func<IWebElement> func, string text, Action retryAction) => VeriFyPage(() => pageInteractionHelper.VerifyPage(func, text, retryAction));

        protected bool VerifyPage(By locator) => VeriFyPage(() => pageInteractionHelper.VerifyPage(locator));

        protected bool VerifyPage(By locator, Action retryAction) => VeriFyPage(() => pageInteractionHelper.VerifyPage(locator, retryAction));

        protected bool VerifyPage(Action retryAction) => VeriFyPage(() => pageInteractionHelper.VerifyPage(PageHeader, PageTitle, retryAction));

        protected bool VerifyPage(Func<IWebElement> func, List<string> text, Action retryAction = null) => VeriFyPage(() => pageInteractionHelper.VerifyPage(func, text, retryAction));

        protected bool VerifyPage(By locator, string text) => VeriFyPage(() => pageInteractionHelper.VerifyPage(locator, text));

        protected bool VerifyPage(By locator, string text, Action retryAction) => VeriFyPage(() => pageInteractionHelper.VerifyPage(locator, text, retryAction));

        private bool CanCaptureUrl() => (frameworkConfig.CanCaptureUrl && CaptureUrl);

        private bool VeriFyPage(Func<bool> func) { var result = func(); TakeScreenShot(); return result; }

        private void TakeScreenShot()
        {
            if (frameworkConfig.IsVstsExecution && !tags.Contains("donottakescreenshot") && _takescreenshot)
                ScreenshotHelper.TakeScreenShot(_webDriver, _directory, $"{_screenShotTitleGenerator.GetNextCount()}{(CaptureUrl ? string.Empty : $"_{PageTitle}_AuthStep")}", TakeFullScreenShot);
        }
    }
}