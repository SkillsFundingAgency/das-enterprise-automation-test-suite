using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class InterimEmployerBasePage : Navigate
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly RegistrationConfig config;
        protected readonly ObjectContext objectContext;
        protected readonly TabHelper _tabHelper;
        #endregion

        #region Locators
        private By SettingsLink => By.LinkText("Settings");
        private By YourAccountsLink => By.LinkText("Your accounts");
        private By HelpLink => By.LinkText("Help");
        private By RenameAccountLink => By.LinkText("Rename account");
        private By ChangePasswordLink => By.LinkText("Change your password");
        private By ChangeEmailAddressLink => By.LinkText("Change your email address");
        private By NotificationSettingsLink => By.LinkText("Notifications settings");
        private By SignOutLink => By.LinkText("Sign out");
        private By YourTeamLink => By.LinkText("Your team");
        #endregion

        protected InterimEmployerBasePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _tabHelper = _context.Get<TabHelper>();
            config = context.GetRegistrationConfig<RegistrationConfig>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public HomePage GoToHomePage() => new HomePage(_context, true);

        public HomePage HomePage() => new HomePage(_context);

        public YourOrganisationsAndAgreementsPage GoToYourOrganisationsAndAgreementsPage()
        {
            return new YourOrganisationsAndAgreementsPage(_context, true);
        }

        public YourAccountsPage GoToYourAccountsPage()
        {
            formCompletionHelper.ClickElement(SettingsLink);
            formCompletionHelper.ClickElement(YourAccountsLink);
            return new YourAccountsPage(_context);
        }

        public ManageApprenticeshipsServiceHelpPage GoToHelpPage()
        {
            _tabHelper.OpenInNewTab(() => formCompletionHelper.ClickElement(HelpLink));
            return new ManageApprenticeshipsServiceHelpPage(_context);
        }

        public RenameAccountPage GoToRenameAccountPage()
        {
            formCompletionHelper.ClickElement(SettingsLink);
            formCompletionHelper.ClickElement(RenameAccountLink);
            return new RenameAccountPage(_context);
        }

        public ChangeYourPasswordPage GoToChangeYourPasswordPage()
        {
            formCompletionHelper.ClickElement(SettingsLink);
            formCompletionHelper.ClickElement(ChangePasswordLink);
            return new ChangeYourPasswordPage(_context);
        }

        public ChangeYourEmailAddressPage GoToChangeYourEmailAddressPage()
        {
            formCompletionHelper.ClickElement(SettingsLink);
            formCompletionHelper.ClickElement(ChangeEmailAddressLink);
            return new ChangeYourEmailAddressPage(_context);
        }

        public NotificationSettingsPage GoToNotificationSettingsPage()
        {
            formCompletionHelper.ClickElement(SettingsLink);
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
    }
}