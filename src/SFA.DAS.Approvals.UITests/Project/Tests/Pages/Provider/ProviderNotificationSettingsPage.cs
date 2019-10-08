using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNotificationSettingsPage : BasePage
    {
        protected override string PageTitle => "Notification Settings";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion
        private By NotificationOptions => By.CssSelector(".selection-button-radio");
        private By UpdateButton => By.CssSelector(".button");

        private By Alert => By.CssSelector(".green-box-alert");

        public ProviderNotificationSettingsPage(ScenarioContext context): base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ProviderNotificationSettingsPage ChooseToReceiveEmails()
        {
            return SelectReceiveEmailsOptions("NotificationSettings-true-0");
        }

        public ProviderNotificationSettingsPage ChooseNotToReceiveEmails()
        {
            return SelectReceiveEmailsOptions("NotificationSettings-false-0");
        }

        public bool IsSettingsUpdated()
        {
            return _pageInteractionHelper.IsElementDisplayed(Alert);
        }

        private ProviderNotificationSettingsPage SelectReceiveEmailsOptions(string option)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(NotificationOptions, option);
            _formCompletionHelper.ClickElement(UpdateButton);
            return this;
        }
    }
}
