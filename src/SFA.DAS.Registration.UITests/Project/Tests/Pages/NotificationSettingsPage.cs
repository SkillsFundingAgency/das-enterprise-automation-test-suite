using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class NotificationSettingsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Notification Settings";

        #region Locators
        private By NotificationOptions => By.CssSelector(".selection-button-radio");
        private By UpdateButton => By.CssSelector(".button");
        #endregion

        public NotificationSettingsPage(ScenarioContext context) : base(context) => VerifyPage();

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
            return pageInteractionHelper.IsElementDisplayed(By.CssSelector(".success-summary"));
        }

        private NotificationSettingsPage SelectReceiveEmailsOptions(string option)
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(NotificationOptions, option);
            formCompletionHelper.ClickElement(UpdateButton);
            return this;
        }
    }
}