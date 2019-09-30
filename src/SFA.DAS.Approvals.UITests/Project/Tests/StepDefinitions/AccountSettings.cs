using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
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
        private readonly ScenarioContext _context;

        private readonly EmployerPortalLoginHelper _loginHelper;
        private ApprenticesHomePage _apprenticesHomePage;
        private NotificationSettingsPage _employerNotification;

        private readonly ProviderStepsHelper _providerStepsHelper;
        private ProviderNotificationSettingsPage _providerNotification;
        
        
        public AccountSettings(ScenarioContext context)
        {
            _context = context;
            _loginHelper = new EmployerPortalLoginHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(_context);
        }

        [Given(@"Employer navigates to Apprentices home page")]
        public void EmployerNavigatesToApprenticesHomePage()
        {
            _loginHelper.Login(_context.GetUser<LevyUser>(), true);

            _apprenticesHomePage = new ApprenticesHomePage(_context, true);
        }

        [Then(@"Employer should be able to navigate to help page")]
        public void EmployerShouldBeAbleToNavigateToHelpPage()
        {
            _apprenticesHomePage.GoToHelpPage();
        }

        [Then(@"Employer should be able to navigate to Rename account page")]
        public void EmployerShouldBeAbleToNavigateToRenameAccountPage()
        {
            _apprenticesHomePage.GoToRenameAccountPage();
        }

        [Then(@"Employer should be able to navigate to Change your password page")]
        public void EmployerShouldBeAbleToNavigateToChangeYourPasswordPage()
        {
            _apprenticesHomePage.GoToChangeYourPasswordPage();
        }

        [Then(@"Employer should be able to navigate to Change your email address page")]
        public void EmployerShouldBeAbleToNavigateToChangeYourEmailAddressPage()
        {
            _apprenticesHomePage.GoToChangeYourEmailAddressPage();
        }

        [When(@"Employer navigates to notification settings page")]
        public void EmployerNavigatesToNotificationSettingsPage()
        {
            _employerNotification = _apprenticesHomePage.GoToNotificationSettingsPage();
        }

        [Then(@"Employer is able to choose to receive notification emails")]
        public void EmployerIsAbleToChooseToReceiveNotificationEmails()
        {
            _employerNotification = _employerNotification.ChooseToReceiveEmails();

            Assert.IsTrue(_employerNotification.IsSettingsUpdated(), $"Choose to receive notification emails success message is not displayed");
        }

        [Then(@"Employer is able to choose No notification emails")]
        public void EmployerIsAbleToChooseNoNotificationEmails()
        {
            _employerNotification = _employerNotification.ChooseNotToReceiveEmails();

            Assert.IsTrue(_employerNotification.IsSettingsUpdated(), $"Choose not to receive notification emails success message is not displayed");
        }

        [Given(@"Provider navigates to notification settings page")]
        public void ProviderNavigatesToNotificationSettingsPage()
        {
            _providerNotification = _providerStepsHelper.GoToProviderHomePage()
                .GoToProviderNotificationSettingsPage();
        }

        [Then(@"Provider is able to choose to receive notification emails")]
        public void ProviderIsAbleToChooseToReceiveNotificationEmails()
        {
            _providerNotification = _providerNotification.ChooseToReceiveEmails();

            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose to receive notification emails success message is not displayed");
        }

        [Then(@"Provider is able to choose No notification emails")]
        public void ProviderIsAbleToChooseNoNotificationEmails()
        {
            _providerNotification = _providerNotification.ChooseNotToReceiveEmails();

            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose not to receive notification emails success message is not displayed");
        }
    }
}
