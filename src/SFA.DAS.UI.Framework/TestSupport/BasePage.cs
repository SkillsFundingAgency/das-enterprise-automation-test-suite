using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport;
using System.Linq;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class BasePage
    {
        #region Helpers and Context
        protected readonly string[] tags;
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly IFrameHelper frameHelper;
        protected readonly JavaScriptHelper javaScriptHelper;
        protected readonly TabHelper tabHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly FrameworkConfig frameworkConfig;
        private readonly IWebDriver _webDriver;
        private readonly ScreenShotTitleGenerator _screenShotTitleGenerator;
        private readonly string _directory;
        private bool _takescreenshot;
        #endregion

        protected virtual By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading");
        protected virtual By PageCaptionXl => By.CssSelector(".govuk-caption-xl");
        protected virtual By ContinueButton => By.CssSelector(".govuk-button");
        protected virtual By BackLink => By.CssSelector(".govuk-back-link, .back-link");
        protected virtual By RadioLabels => By.CssSelector(".govuk-radios__label");
        protected virtual By CheckBoxLabels => By.CssSelector(".govuk-checkboxes__label");

        protected abstract string PageTitle { get; }

        protected virtual By AcceptCookieButton { get; }

        protected virtual bool CaptureUrl => true;

        protected BasePage(ScenarioContext context)
        {
            _takescreenshot = true;
            _webDriver = context.GetWebDriver();
            _screenShotTitleGenerator = context.Get<ScreenShotTitleGenerator>();
            _directory = objectContext.GetDirectory();

            objectContext = context.Get<ObjectContext>();
            tags = context.ScenarioInfo.Tags;
            frameworkConfig = context.Get<FrameworkConfig>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            frameHelper = context.Get<IFrameHelper>();
            javaScriptHelper = context.Get<JavaScriptHelper>();
            tabHelper = context.Get<TabHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            
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

        protected string GetUrl() => pageInteractionHelper.GetUrl();

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

        protected bool VerifyPage(By locator, string text, Action retryAction) => VeriFyPage(() =>pageInteractionHelper.VerifyPage(locator, text, retryAction));

        protected virtual void Continue() => formCompletionHelper.Click(ContinueButton);

        protected void SelectRadioOptionByForAttribute(string value) => formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, value);

        protected void SelectRadioOptionByText(string value) => formCompletionHelper.SelectRadioOptionByText(RadioLabels, value);

        protected void SelectCheckBoxByText(string value) => formCompletionHelper.SelectCheckBoxByText(CheckBoxLabels, value);

        protected void NavigateBack() => formCompletionHelper.Click(BackLink);

        protected void AcceptCookies()
        {
            if (pageInteractionHelper.IsElementDisplayed(AcceptCookieButton))
                formCompletionHelper.Click(AcceptCookieButton);
        }

        private bool CanCaptureUrl() => (frameworkConfig.CanCaptureUrl && CaptureUrl);

        private bool VeriFyPage(Func<bool> func) { var result = func(); TakeScreenShotMethod(); return result; }

        private void TakeScreenShotMethod()
        {
            if (frameworkConfig.IsVstsExecution && !tags.Contains("donottakescreenshot") && _takescreenshot)
                ScreenshotHelper.TakeScreenShot(_webDriver, _directory, $"{_screenShotTitleGenerator.GetNextCount()}{(CaptureUrl ? string.Empty : $"_{PageTitle}_AuthStep")}");
        }
    }
}