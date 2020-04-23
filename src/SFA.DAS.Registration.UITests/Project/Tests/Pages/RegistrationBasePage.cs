using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using OpenQA.Selenium;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class RegistrationBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly RegistrationConfig config;
        protected readonly ObjectContext objectContext;
        protected readonly RegistrationDataHelper registrationDataHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        private By SettingsLink => By.LinkText("Settings");
        private By ChangePasswordLink => By.LinkText("Change your password");
        private By ChangeEmailAddressLink => By.LinkText("Change your email address");
        private By SignOutLink => By.LinkText("Sign out");
        #endregion

        protected RegistrationBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            config = context.GetRegistrationConfig<RegistrationConfig>();
            objectContext = context.Get<ObjectContext>();
            registrationDataHelper = context.Get<RegistrationDataHelper>();
        }

        public HomePage GoToHomePage() => new HomePage(_context, true);

        public HomePage ClickBackLink()
        {
            NavigateBack();
            return new HomePage(_context);
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

        public YouveLoggedOutPage SignOut()
        {
            formCompletionHelper.Click(SignOutLink);
            return new YouveLoggedOutPage(_context);
        }
    }
}
