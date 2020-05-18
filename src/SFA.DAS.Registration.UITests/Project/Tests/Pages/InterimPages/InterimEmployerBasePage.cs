using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public abstract class InterimEmployerBasePage : Navigate
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly RegistrationConfig config;
        protected readonly ObjectContext objectContext;
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
        private By YourTeamLink => By.LinkText("Your team");
        private By PAYESchemesLink => By.LinkText("PAYE schemes");
        #endregion

        protected InterimEmployerBasePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            config = context.GetRegistrationConfig<RegistrationConfig>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        protected InterimEmployerBasePage(ScenarioContext context, bool navigate, bool gotourl) : base(context, navigate, UrlConfig.EmployerApprenticeshipServiceBaseURL) { }

        public HomePage GoToHomePage() => new HomePage(_context, true);

        public YourOrganisationsAndAgreementsPage GoToYourOrganisationsAndAgreementsPage() => new YourOrganisationsAndAgreementsPage(_context, true);

        public YourAccountsPage GoToYourAccountsPage()
        {
            NavigateToSettings();
            formCompletionHelper.ClickElement(YourAccountsLink);
            return new YourAccountsPage(_context);
        }

        public HelpArticlesPage GoToHelpPage()
        {
            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickElement(HelpLink));
            return new HelpArticlesPage(_context);
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

        public YourTeamPage GotoYourTeamPage()
        {
            formCompletionHelper.Click(YourTeamLink);
            return new YourTeamPage(_context);
        }

        public PAYESchemesPage GotoPAYESchemesPage()
        {
            OpenSubMenu();
            formCompletionHelper.Click(PAYESchemesLink);
            return new PAYESchemesPage(_context);
        }

        private void NavigateToSettings() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SettingsLink));
    }
}