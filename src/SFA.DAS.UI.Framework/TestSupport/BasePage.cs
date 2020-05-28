using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport;

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
        #endregion

        protected virtual By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title");
        protected virtual By ContinueButton => By.CssSelector(".govuk-button");
        protected virtual By BackLink => By.CssSelector(".govuk-back-link, .back-link");
        protected virtual By RadioLabels => By.CssSelector(".govuk-radios__label");
        protected virtual By CheckBoxLabels => By.CssSelector(".govuk-checkboxes__label");
        protected abstract string PageTitle { get; }

        protected virtual By AcceptCookieButton { get; }

        protected BasePage(ScenarioContext context)
        {
            _frameworkConfig = context.Get<FrameworkConfig>();
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _screenShotTitleGenerator = context.Get<ScreenShotTitleGenerator>();
            var objectContext = context.Get<ObjectContext>();
            _directory = objectContext.GetDirectory();
            
            if (_frameworkConfig.IsVstsExecution)
                ScreenshotHelper.TakeScreenShot(_webDriver, _directory, _screenShotTitleGenerator.GetNextCount());
        }

        protected bool VerifyPageAfterRefresh(By locator) => _pageInteractionHelper.VerifyPageAfterRefresh(locator);

        protected bool VerifyPage(Func<List<IWebElement>> func) => _pageInteractionHelper.VerifyPage(func, PageTitle);

        protected bool VerifyPage(Func<List<IWebElement>> func, string expected) => _pageInteractionHelper.VerifyPage(func, expected);

        protected bool VerifyElement(Func<IWebElement> func, string text, Action retryAction) => _pageInteractionHelper.VerifyPage(func, text, retryAction);

        protected bool VerifyPage(By locator) => _pageInteractionHelper.VerifyPage(locator);

        protected bool VerifyPage() => VerifyPage(PageHeader, PageTitle);

        protected bool VerifyPage(By locator, string text) => _pageInteractionHelper.VerifyPage(locator, text);

        protected void Continue() => _formCompletionHelper.Click(ContinueButton);

        protected void SelectRadioOptionByForAttribute(string value) => _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, value);

        protected void SelectRadioOptionByText(string value) => _formCompletionHelper.SelectRadioOptionByText(RadioLabels, value);

        protected void SelectCheckBoxByText(string value) => _formCompletionHelper.SelectCheckBoxByText(CheckBoxLabels, value);

        protected void NavigateBack() => _formCompletionHelper.Click(BackLink);

        protected void AcceptCookies()
        {
            if (_pageInteractionHelper.IsElementDisplayed(AcceptCookieButton))
            {
                _formCompletionHelper.Click(AcceptCookieButton);
            }
        }
    }
}