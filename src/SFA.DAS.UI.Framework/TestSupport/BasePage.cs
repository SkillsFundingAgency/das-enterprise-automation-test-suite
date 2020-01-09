using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly FrameworkConfig _frameworkConfig;
        private readonly IWebDriver _webDriver;
        private readonly ScreenShotTitleGenerator _screenShotTitleGenerator;
        private readonly string _directory;
        private readonly string _browser;
        #endregion

        protected virtual By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title");
        protected virtual By ContinueButton => By.CssSelector(".govuk-button");

        protected abstract string PageTitle { get; }

        public BasePage(ScenarioContext context)
        {
            _frameworkConfig = context.Get<FrameworkConfig>();
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _screenShotTitleGenerator = context.Get<ScreenShotTitleGenerator>();
            var objectContext = context.Get<ObjectContext>();
            _directory = objectContext.GetDirectory();
            _browser = objectContext.GetBrowser();
        }

        protected bool VerifyPageAfterRefresh(By locator) => VerifyPage(() => _pageInteractionHelper.VerifyPageAfterRefresh(locator));

        protected bool VerifyPage(Func<List<IWebElement>> func) => VerifyPage(() => _pageInteractionHelper.VerifyPage(func, PageTitle));

        protected bool VerifyPage(By locator) => VerifyPage(() => _pageInteractionHelper.VerifyPage(locator));

        protected bool VerifyPage() => VerifyPage(PageHeader, PageTitle);

        protected bool VerifyPage(By locator, string text) => VerifyPage(() => _pageInteractionHelper.VerifyPage(locator, text));

        protected void Continue() => _formCompletionHelper.Click(ContinueButton);
        
        private bool VerifyPage(Func<bool> func)
        {
            if (_frameworkConfig.IsVstsExecution && !_browser.IsCloudExecution())
            {
                ScreenshotHelper.TakeScreenShot(_webDriver, _directory, _screenShotTitleGenerator.GetNextCount());
            }

            return func.Invoke();
        }
    }
}
