using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class NotificationSettingsPage : BasePage
    {
        protected override string PageTitle => "Notification Settings";
        
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        public NotificationSettingsPage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        private By NotificationOptions => By.CssSelector(".selection-button-radio");
        private By UpdateButton => By.CssSelector(".button");

        public NotificationSettingsPage ChooseToReceiveEmails()
        {
            SelectReceiveEmailsOptions("NotificationSettings-true-0");
            return this;
        }

        public NotificationSettingsPage ChooseNotToReceiveEmails()
        {
            SelectReceiveEmailsOptions("NotificationSettings-false-0");
            return this;
        }

        public bool IsSettingsUpdated()
        {
            return _pageInteractionHelper.IsElementDisplayed(By.CssSelector(".success-summary"));
        }

        private NotificationSettingsPage SelectReceiveEmailsOptions(string option)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(NotificationOptions, option);
            _formCompletionHelper.ClickElement(UpdateButton);
            return this;
        }
    }
}