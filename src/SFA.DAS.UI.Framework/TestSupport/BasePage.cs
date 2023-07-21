using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class BasePage : InitialiseBasePage
    {
        protected static string PageHeaderSelector => ".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading";
        protected virtual By PageHeader => By.CssSelector(PageHeaderSelector);
        protected virtual By PageCaptionXl => By.CssSelector(".govuk-caption-xl");
        protected virtual By ContinueButton => By.CssSelector(".govuk-button");
        protected virtual By BackLink => By.CssSelector(".govuk-back-link, .back-link");
        protected virtual By RadioLabels => By.CssSelector(".govuk-radios__label");
        protected virtual By CheckBoxLabels => By.CssSelector(".govuk-checkboxes__label");

        protected static By PanelTitle => By.CssSelector(".govuk-panel__title");

        protected abstract string PageTitle { get; }

        protected virtual By AcceptCookieButton { get; }

        public BasePage(ScenarioContext context) : base(context) { }
    
        protected static string EnvironmentName => EnvironmentConfig.EnvironmentName;

        protected string GetUrl() => pageInteractionHelper.GetUrl();

        protected virtual void Continue() => formCompletionHelper.Click(ContinueButton);

        protected void SelectRadioOptionByForAttribute(string value) => formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, value);

        protected void SelectRadioOptionByText(string value) => formCompletionHelper.SelectRadioOptionByText(RadioLabels, value);

        protected void SelectCheckBoxByText(string value) => formCompletionHelper.SelectCheckBoxByText(CheckBoxLabels, value);

        protected void NavigateBack() => formCompletionHelper.Click(BackLink);

        protected void AcceptCookies() => ClickIfDisplayed(AcceptCookieButton);

        protected void ClickIfDisplayed(By by)
        {
            if (pageInteractionHelper.IsElementDisplayed(by)) 
                formCompletionHelper.ClickElement(by);
        }
    }
}