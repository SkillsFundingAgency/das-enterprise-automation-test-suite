using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AccountSettings
    {
        private readonly ProviderStepsHelper _providerStepsHelper;
        private ProviderNotificationSettingsPage _providerNotification;

        public AccountSettings(ScenarioContext context)
        {
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Given(@"Provider navigates to notification settings page")]
        public void GivenProviderNavigatesToNotificationSettingsPage()
        {
            _providerNotification = _providerStepsHelper.GoToProviderHomePage()
                                    .GoToProviderNotificationSettingsPage();
        }

        [Then(@"Provider is able to choose to receive notification emails")]
        public void ThenProviderIsAbleToChooseToReceiveNotificationEmails()
        {
            _providerNotification.ChooseToReceiveEmails();

            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose to receive notification emails success message is not displayed");
        }

        [Then(@"Provider is able to choose No notification emails")]
        public void ThenProviderIsAbleToChooseNoNotificationEmails()
        {
            _providerNotification.ChooseNotToReceiveEmails();

            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose not to receive notification emails success message is not displayed");
        }
    }
}
