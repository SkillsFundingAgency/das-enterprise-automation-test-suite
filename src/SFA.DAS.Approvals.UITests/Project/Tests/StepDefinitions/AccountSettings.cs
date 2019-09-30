using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
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
        private readonly EmployerStepsHelper _employerStepsHelper;
        private ApprenticesHomePage _apprenticesHomePage;
        private ProviderNotificationSettingsPage _providerNotification;
        private NotificationSettingsPage _employerNotification;
        private readonly ScenarioContext _context;

        public AccountSettings(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [Given(@"Employer navigates to Apprentices home page")]
        public void GivenEmployerNavigatesToApprenticesHomePage()
        {
            _apprenticesHomePage = _employerStepsHelper.GoToEmployerApprenticesHomePage();
        }

        [Then(@"Employer should be able to navigate to help page")]
        public void ThenEmployerShouldBeAbleToNavigateToHelpPage()
        {
            _apprenticesHomePage.GoToHelpPage();
        }

        [When(@"Employer revisited Apprentices home page")]
        public void WhenEmployerRevisitedApprenticesHomePage()
        {
            _apprenticesHomePage = new ApprenticesHomePage(_context, true);
        }

        [Then(@"Employer should be able to navigate to Your accounts page")]
        public void ThenEmployerShouldBeAbleToNavigateToYourAccountsPage()
        {
            _apprenticesHomePage.GoToYourAccountsPage()
                .GoToHomePage();
        }

        [Then(@"Employer should be able to navigate to Rename account page")]
        public void ThenEmployerShouldBeAbleToNavigateToRenameAccountPage()
        {
            _apprenticesHomePage.GoToRenameAccountPage();
        }

        [Then(@"Employer should be able to navigate to Change your password page")]
        public void ThenEmployerShouldBeAbleToNavigateToChangeYourPasswordPage()
        {
            _apprenticesHomePage.GoToChangeYourPasswordPage();
        }

        [Then(@"Employer should be able to navigate to Change your email address page")]
        public void ThenEmployerShouldBeAbleToNavigateToChangeYourEmailAddressPage()
        {
            _apprenticesHomePage.GoToChangeYourEmailAddressPage();
        }

        [Then(@"Employer should be able to navigate to Notigication settings page")]
        public void ThenEmployerShouldBeAbleToNavigateToNotigicationSettingsPage()
        {
            _employerNotification = _apprenticesHomePage.GoToNotificationSettingsPage();
        }

        [Then(@"Employer is able to choose to receive notification emails")]
        public void ThenEmployerIsAbleToChooseToReceiveNotificationEmails()
        {
            _employerNotification = _employerNotification.ChooseToReceiveEmails();

            Assert.IsTrue(_employerNotification.IsSettingsUpdated(), $"Choose to receive notification emails success message is not displayed");
        }

        [Then(@"Employer is able to choose No notification emails")]
        public void ThenEmployerIsAbleToChooseNoNotificationEmails()
        {
            _employerNotification = _employerNotification.ChooseNotToReceiveEmails();

            Assert.IsTrue(_employerNotification.IsSettingsUpdated(), $"Choose not to receive notification emails success message is not displayed");
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
            _providerNotification = _providerNotification.ChooseToReceiveEmails();

            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose to receive notification emails success message is not displayed");
        }

        [Then(@"Provider is able to choose No notification emails")]
        public void ThenProviderIsAbleToChooseNoNotificationEmails()
        {
            _providerNotification = _providerNotification.ChooseNotToReceiveEmails();

            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose not to receive notification emails success message is not displayed");
        }
    }
}
