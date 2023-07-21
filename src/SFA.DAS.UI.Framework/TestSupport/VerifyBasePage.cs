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
        private readonly ScreenShotTitleGenerator _screenShotTitleGenerator;
        private bool _takescreenshot;
        #endregion

        public bool IsPageCurrent => pageInteractionHelper.CheckText(PageHeader, PageTitle).Item1;

        protected virtual bool CaptureUrl => true;

        protected virtual bool TakeFullScreenShot => true;

        protected virtual bool CanAnalyzePage => true;

        protected VerifyBasePage(ScenarioContext context) : base(context)
        {
            _takescreenshot = true;

            _screenShotTitleGenerator = context.Get<ScreenShotTitleGenerator>();

            if (CanCaptureUrl()) objectContext.SetAuthUrl(GetUrl());
        }

        protected bool IsAccessibilityTesting() => frameworkConfig.IsAccessibilityTesting;

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

        protected bool VerifyWithoutRefresh() => VerifyPage(() => pageInteractionHelper.Verify(() => 
        {
            var result = pageInteractionHelper.CheckText(PageHeader, PageTitle);

            return result.Item1 ? result.Item1 : throw new Exception(ExceptionMessageHelper.GetExceptionMessage("Page", PageTitle, result.Item2));

        }, null));

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

        private bool VerifyPage(Func<bool> func)
        {
            int GetCounter() => _screenShotTitleGenerator.GetCounter();

            int counter = GetCounter();
            try
            {
                var result = func(); 
                
                TakeScreenShot();

                if (IsAccessibilityTesting() && CanAnalyzePage) new AnalyzePageHelper(context).AnalyzePage(PageTitle);

                return result;
            }
            catch (Exception)
            {
                if (tags.Contains("authtests") && counter == GetCounter()) TakeScreenShot();

                throw;
            }
        }

        private void TakeScreenShot()
        {
            if (frameworkConfig.IsVstsExecution && !tags.Contains("donottakescreenshot") && _takescreenshot && !frameworkConfig.IsAccessibilityTesting)
            {
                string counter = _screenShotTitleGenerator.GetTitle();

                ScreenshotHelper.TakeScreenShot(context.GetWebDriver(), objectContext.GetDirectory(), $"{counter}{(CaptureUrl ? string.Empty : $"_{PageTitle}_{counter}_AuthStep")}", CanTakeFullScreenShot(), false);
            }
        }
    }
}