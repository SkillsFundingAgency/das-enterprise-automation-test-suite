using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using System.Linq;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class VerifyBasePage : InterimBasePage
    {
        #region Helpers and Context
        private readonly IWebDriver _webDriver;
        private readonly ScreenShotTitleGenerator _screenShotTitleGenerator;
        private readonly string _directory;
        private bool _takescreenshot;
        #endregion

        protected virtual bool CaptureUrl => true;

        protected virtual bool TakeFullScreenShot => true;

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
            return VerifyPage(() => 
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

        #region VerifyPage
        // VerifyPage methods are used to verify that the application landed on the expected page

        protected bool VerifyPage() => VerifyPage(() => VerifyElement());

        protected bool VerifyPageAfterRefresh(By locator) => VerifyPage(() => pageInteractionHelper.VerifyPageAfterRefresh(locator));

        protected bool VerifyPage(Func<List<IWebElement>> func) => VerifyPage(func, PageTitle);

        protected bool VerifyPage(Func<List<IWebElement>> func, string expected) => VerifyPage(() => VerifyElement(func, expected));

        protected bool VerifyPage(By locator) => VerifyPage(() => VerifyElement(locator));

        protected bool VerifyPage(By locator, Action retryAction) => VerifyPage(() => pageInteractionHelper.VerifyPage(locator, retryAction));

        protected bool VerifyPage(Action retryAction) => VerifyPage(() => pageInteractionHelper.VerifyPage(PageHeader, PageTitle, retryAction));

        protected bool VerifyPage(Func<IWebElement> func, List<string> text, Action retryAction = null) => VerifyPage(() => pageInteractionHelper.VerifyPage(func, text, retryAction));

        protected bool VerifyPage(By locator, string text) => VerifyPage(() => VerifyElement(locator, text));

        protected bool VerifyPage(By locator, string text, Action retryAction) => VerifyPage(() => VerifyElement(locator, text, retryAction));

        #endregion

        #region VerifyElement 
        // VerifyElement method are used to verify an element with in a page after the page verification happened.

        protected bool VerifyElement() => VerifyElement(PageHeader, PageTitle);

        protected bool VerifyElement(By locator, string text) => pageInteractionHelper.VerifyPage(locator, text);

        protected bool VerifyElement(By locator, string text, Action retryAction) => pageInteractionHelper.VerifyPage(locator, text, retryAction);

        protected bool VerifyElement(Func<List<IWebElement>> func, string expected) => pageInteractionHelper.VerifyPage(func, expected);

        protected bool VerifyElement(By locator) => pageInteractionHelper.VerifyPage(locator);

        #endregion

        private bool CanCaptureUrl() => (frameworkConfig.CanCaptureUrl && CaptureUrl);

        private bool CanTakeFullScreenShot() => (frameworkConfig.CanTakeFullScreenShot && TakeFullScreenShot);

        private bool VerifyPage(Func<bool> func) { var result = func(); TakeScreenShot(); return result; }

        private void TakeScreenShot()
        {
            if (frameworkConfig.IsVstsExecution && !tags.Contains("donottakescreenshot") && _takescreenshot)
                ScreenshotHelper.TakeScreenShot(_webDriver, _directory, $"{_screenShotTitleGenerator.GetNextCount()}{(CaptureUrl ? string.Empty : $"_{PageTitle}_AuthStep")}", CanTakeFullScreenShot());
        }
    }
}