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
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _datahelper;
        #endregion


        public ProviderNotificationSettingsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _datahelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        private By NotificationOptions => By.CssSelector(".selection-button-radio");
        private By UpdateButton => By.CssSelector(".button");

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
            return _pageInteractionHelper.IsElementDisplayed(By.CssSelector(".green-box-alert"));
        }

        private ProviderNotificationSettingsPage SelectReceiveEmailsOptions(string option)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(NotificationOptions, option);
            _formCompletionHelper.ClickElement(UpdateButton);
            return this;
        }
    }
}
