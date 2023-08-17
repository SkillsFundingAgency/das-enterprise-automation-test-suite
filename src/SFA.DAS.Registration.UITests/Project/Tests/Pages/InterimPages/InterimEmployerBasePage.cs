using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using SFA.DAS.UI.Framework;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public abstract class InterimEmployerBasePage : Navigate
    {

        #region Locators
        private static By SettingsLink => By.LinkText("Settings");
        private static By YourAccountsLink => By.LinkText("Your accounts");
        private static By HelpLink => By.LinkText("Help");
        private static By RenameAccountLink => By.LinkText("Rename account");
        private static By NotificationSettingsLink => By.PartialLinkText("Notification");
        private static By SignOutLink => By.LinkText("Sign out");
        #endregion

        protected InterimEmployerBasePage(ScenarioContext context, bool navigate) : this(context, navigate, false) { }

        protected InterimEmployerBasePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, navigate, GoToUrl(gotourl))
        {
            VerifyPage();
        }

        protected InterimEmployerBasePage(ScenarioContext context, Action navigate, bool gotourl) : base(context, navigate, GoToUrl(gotourl))
        {
            VerifyPage();
        }

        private static string GoToUrl(bool gotourl) => gotourl ? UrlConfig.EmployerApprenticeshipService_BaseUrl : string.Empty;

        public HomePage GoToHomePage() => new(context, true);

        public YourOrganisationsAndAgreementsPage GoToYourOrganisationsAndAgreementsPage() => new(context, true);

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

        public YourTeamPage GotoYourTeamPage() => new(context, true);

        public PAYESchemesPage GotoPAYESchemesPage() => new(context, true);

        private void NavigateToSettings(By by) => RetryClickOnException(SettingsLink, () => pageInteractionHelper.FindElement(by));
    }
}