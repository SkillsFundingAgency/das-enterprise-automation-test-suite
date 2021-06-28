using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNotificationSettingsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Notification settings";
        
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Update')]");

        private By NotificationOptions => By.CssSelector(".selection-button-radio");
        
        private By Alert => By.CssSelector(".green-box-alert");

        public ProviderNotificationSettingsPage(ScenarioContext context) : base(context) { }

        public ProviderNotificationSettingsPage ChooseToReceiveEmails() => SelectReceiveEmailsOptions("NotificationSettings-true-0");

        public ProviderNotificationSettingsPage ChooseNotToReceiveEmails() => SelectReceiveEmailsOptions("NotificationSettings-false-0");

        public bool IsSettingsUpdated() => pageInteractionHelper.IsElementDisplayed(Alert);

        private ProviderNotificationSettingsPage SelectReceiveEmailsOptions(string option)
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(NotificationOptions, option);
            Continue();
            return this;
        }
    }
}
