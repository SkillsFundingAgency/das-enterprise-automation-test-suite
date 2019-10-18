using System;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FrameworkConfig _frameworkConfig;
        private readonly IWebDriver _webDriver;
        private readonly ScreenShotTitleGenerator _screenShotTitleGenerator;
        private readonly string _directory;
        private readonly string _browser;
        #endregion

        protected virtual By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title");

        protected abstract string PageTitle { get; }

        public BasePage(ScenarioContext context)
        {
            _frameworkConfig = context.Get<FrameworkConfig>();
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _screenShotTitleGenerator = context.Get<ScreenShotTitleGenerator>();
            var objectContext = context.Get<ObjectContext>();
            _directory = objectContext.GetDirectory();
            _browser = objectContext.GetBrowser();
        }

        protected bool VerifyPage()
        {
            if (_frameworkConfig.TakeEveryPageScreenShot && !_browser.IsCloudExecution())
            {
                ScreenshotHelper.TakeScreenShot(_webDriver, _directory, _screenShotTitleGenerator.GetNextCount());
            }

            return _pageInteractionHelper.VerifyPage(PageHeader, PageTitle);
        }

        protected bool VerifyPage(Action beforeAction)
        {
            return _pageInteractionHelper.VerifyPage(PageHeader, PageTitle, beforeAction);
        }
    }
}