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

        public YourAccountsPage GoToYourAccountsPage()
        {
            formCompletionHelper.ClickElement(SettingsLink);
            formCompletionHelper.ClickElement(YourAccountsLink);
            return new YourAccountsPage(_context);
        }
    }
}