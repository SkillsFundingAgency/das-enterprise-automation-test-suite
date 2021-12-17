using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class BasePage
    {
        #region Helpers and Context
        protected readonly ScenarioContext context;
        protected readonly string[] tags;
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly IFrameHelper frameHelper;
        protected readonly JavaScriptHelper javaScriptHelper;
        protected readonly TabHelper tabHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly FrameworkConfig frameworkConfig;
        #endregion

        protected virtual By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading");
        protected virtual By PageCaptionXl => By.CssSelector(".govuk-caption-xl");
        protected virtual By ContinueButton => By.CssSelector(".govuk-button");
        protected virtual By BackLink => By.CssSelector(".govuk-back-link, .back-link");
        protected virtual By RadioLabels => By.CssSelector(".govuk-radios__label");
        protected virtual By CheckBoxLabels => By.CssSelector(".govuk-checkboxes__label");

        protected abstract string PageTitle { get; }

        protected virtual By AcceptCookieButton { get; }

        public BasePage(ScenarioContext context)
        {
            this.context = context;
            objectContext = context.Get<ObjectContext>();
            tags = context.ScenarioInfo.Tags;
            frameworkConfig = context.Get<FrameworkConfig>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            frameHelper = context.Get<IFrameHelper>();
            javaScriptHelper = context.Get<JavaScriptHelper>();
            tabHelper = context.Get<TabHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
        }

        protected string GetUrl() => pageInteractionHelper.GetUrl();

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
    }
}