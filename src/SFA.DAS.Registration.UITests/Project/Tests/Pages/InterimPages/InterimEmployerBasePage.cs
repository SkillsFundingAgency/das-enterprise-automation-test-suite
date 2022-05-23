using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;
using SFA.DAS.UI.Framework;
using System;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public abstract class InterimEmployerBasePage : Navigate
    {
        #region Helpers and Context
        protected readonly RegistrationConfig config;
        #endregion

        #region Locators
        private By SettingsLink => By.LinkText("Settings");
        private By YourAccountsLink => By.LinkText("Your accounts");
        private By HelpLink => By.LinkText("Help");
        private By RenameAccountLink => By.LinkText("Rename account");
        private By ChangePasswordLink => By.LinkText("Change your password");
        private By ChangeEmailAddressLink => By.LinkText("Change your email address");
        private By NotificationSettingsLink => By.PartialLinkText("Notification");
        private By SignOutLink => By.LinkText("Sign out");
        #endregion

        protected InterimEmployerBasePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        protected InterimEmployerBasePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, navigate, GoToUrl(gotourl))
        {
            config = context.GetRegistrationConfig<RegistrationConfig>();
            VerifyPage();
        }

        protected InterimEmployerBasePage(ScenarioContext context, Action navigate, bool gotourl) : base(context, navigate, GoToUrl(gotourl))
        {            
            config = context.GetRegistrationConfig<RegistrationConfig>();
            VerifyPage();
        }

        private static string GoToUrl(bool gotourl) => gotourl ? UrlConfig.EmployerApprenticeshipService_BaseUrl : string.Empty;

        public HomePage GoToHomePage() => new HomePage(context, true);

        public YourOrganisationsAndAgreementsPage GoToYourOrganisationsAndAgreementsPage() => new YourOrganisationsAndAgreementsPage(context, true);

        public YourAccountsPage GoToYourAccountsPage()
        {
            NavigateToSettings(YourAccountsLink);
            return new YourAccountsPage(context);
        }

        public EmployerHelpPage GoToHelpPage()
        {
            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickElement(HelpLink));
            return new EmployerHelpPage(context);
        }

        public RenameAccountPage GoToRenameAccountPage()
        {
            NavigateToSettings(RenameAccountLink);
            return new RenameAccountPage(context);
        }

        public ChangeYourPasswordPage GoToChangeYourPasswordPage()
        {
            NavigateToSettings(ChangePasswordLink);
            return new ChangeYourPasswordPage(context);
        }

        public ChangeYourEmailAddressPage GoToChangeYourEmailAddressPage()
        {
            NavigateToSettings(ChangeEmailAddressLink);
            return new ChangeYourEmailAddressPage(context);
        }

        public NotificationSettingsPage GoToNotificationSettingsPage()
        {
            NavigateToSettings(NotificationSettingsLink);
            return new NotificationSettingsPage(context);
        }

        public YouveLoggedOutPage SignOut()
        {
            formCompletionHelper.Click(SignOutLink);
            return new YouveLoggedOutPage(context);
        }

        public YourTeamPage GotoYourTeamPage() => new YourTeamPage(context, true);

        public PAYESchemesPage GotoPAYESchemesPage() => new PAYESchemesPage(context, true);

        private void NavigateToSettings(By by) => RetryClickOnException(SettingsLink, () => pageInteractionHelper.FindElement(by));
    }
}