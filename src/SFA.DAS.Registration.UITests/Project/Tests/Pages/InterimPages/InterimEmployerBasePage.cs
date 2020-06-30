using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
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
        private readonly ScenarioContext _context;
        protected readonly RegistrationConfig config;
        protected readonly ObjectContext objectContext;
        protected readonly string[] tags;
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
            _context = context;
            config = context.GetRegistrationConfig<RegistrationConfig>();
            objectContext = context.Get<ObjectContext>();
            tags = context.ScenarioInfo.Tags;
            VerifyPage();
        }

        protected InterimEmployerBasePage(ScenarioContext context, Action navigate, bool gotourl) : base(context, navigate, GoToUrl(gotourl))
        {
            _context = context;
            config = context.GetRegistrationConfig<RegistrationConfig>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        private static string GoToUrl(bool gotourl) => gotourl ? UrlConfig.EmployerApprenticeshipService_BaseUrl : string.Empty;

        public HomePage GoToHomePage() => new HomePage(_context, true);

        public YourOrganisationsAndAgreementsPage GoToYourOrganisationsAndAgreementsPage() => new YourOrganisationsAndAgreementsPage(_context, true);

        public YourAccountsPage GoToYourAccountsPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(YourAccountsLink);
            return new YourAccountsPage(_context);
        }

        public EmployerHelpPage GoToHelpPage()
        {
            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickElement(HelpLink));
            return new EmployerHelpPage(_context);
        }

        public RenameAccountPage GoToRenameAccountPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(RenameAccountLink);
            return new RenameAccountPage(_context);
        }

        public ChangeYourPasswordPage GoToChangeYourPasswordPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(ChangePasswordLink);
            return new ChangeYourPasswordPage(_context);
        }

        public ChangeYourEmailAddressPage GoToChangeYourEmailAddressPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(ChangeEmailAddressLink);
            return new ChangeYourEmailAddressPage(_context);
        }

        public NotificationSettingsPage GoToNotificationSettingsPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(NotificationSettingsLink);
            return new NotificationSettingsPage(_context);
        }

        public YouveLoggedOutPage SignOut()
        {
            formCompletionHelper.Click(SignOutLink);
            return new YouveLoggedOutPage(_context);
        }

        public YourTeamPage GotoYourTeamPage() => new YourTeamPage(_context, true);

        public PAYESchemesPage GotoPAYESchemesPage() => new PAYESchemesPage(_context, true);

        private void NavigateToSettings() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SettingsLink));
    }
}