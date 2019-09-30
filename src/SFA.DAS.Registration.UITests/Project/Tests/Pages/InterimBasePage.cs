using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class InterimBasePage : Navigate
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly ProjectConfig config;
        protected readonly ObjectContext objectContext;
        #endregion

        private By SettingsLink => By.LinkText("Settings");

        private By YourAccountsLink => By.LinkText("Your accounts");

        private By HelpLink => By.LinkText("Help");

        private By RenameAccountLink => By.LinkText("Rename account");

        private By ChangePasswordLink => By.LinkText("Change your password");

        private By ChangeEmailAddressLink => By.LinkText("Change your email address");

        private By NotificationSettingsLink => By.LinkText("Notification settings");
        public InterimBasePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            config = context.GetProjectConfig<ProjectConfig>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public HomePage GoToHomePage()
        {
            return new HomePage(_context, true);
        }

        public HomePage GoToHomePageUsingUrl()
        {
            return new HomePage(_context, true);
        }

        public HomePage HomePage()
        {
            return new HomePage(_context);
        }

        public AboutYourAgreementPage AboutYourAgreementPage()
        {
            return new AboutYourAgreementPage(_context);
        }

        public AboutYourAgreementPage GoToAboutYourAgreementPage()
        {
            return new AboutYourAgreementPage(_context, true);
        }

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
            formCompletionHelper.ClickElement(HelpLink);
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
    }
}