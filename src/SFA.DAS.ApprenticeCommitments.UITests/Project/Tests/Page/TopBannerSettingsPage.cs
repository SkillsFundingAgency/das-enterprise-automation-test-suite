using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class TopBannerSettingsPage : BasePage
    {
        private By NavigationLink => By.CssSelector(".app-user-header a.das-user-navigation__link");

        protected By NavigationSubLink => By.CssSelector(".app-user-header a.das-user-navigation__sub-menu-link");

        protected override string PageTitle => string.Empty;

        private readonly ScenarioContext _context;
        protected readonly FormCompletionHelper formCompletionHelper;

        public TopBannerSettingsPage(ScenarioContext context) : base(context)
        {
            _context = context;;
            formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public ChangeYourPersonalDetailsPage NavigateToChangeYourPersonalDetails()
        {
            NavigateToSettings("Change your personal details");
            return new ChangeYourPersonalDetailsPage(_context);
        }

        public ForgottenYourPasswordPage NavigateToChangeYourPassword()
        {
            NavigateToSettings("Change your password");
            return new ForgottenYourPasswordPage(_context);
        }

        public ChangeYourEmailAddressPage NavigateToChangeYourEmailAddress()
        {
            NavigateToSettings("Change your email address");
            return new ChangeYourEmailAddressPage(_context);
        }
        protected void ClickAccountSettings() => formCompletionHelper.ClickLinkByText(NavigationLink, "Account settings");

        protected void NavigateToSettings(string settingsName)
        {
            ClickAccountSettings();
            formCompletionHelper.ClickLinkByText(NavigationSubLink, settingsName);
        }
    }
}
