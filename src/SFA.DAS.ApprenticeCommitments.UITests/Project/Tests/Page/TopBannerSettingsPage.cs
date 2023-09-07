using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class TopBannerSettingsPage : VerifyBasePage
    {
        private static By NavigationLink => By.CssSelector(".app-user-header a.das-user-navigation__link");
        private static By NavigationSubLink => By.CssSelector(".app-user-header a.das-user-navigation__sub-menu-link");
        protected override string PageTitle => string.Empty;

        protected override string AccessibilityPageTitle => "Apprentice top banner settings page";

        public TopBannerSettingsPage(ScenarioContext context) : base(context)  { }

        public ChangeYourPersonalDetailsPage NavigateToChangeYourPersonalDetails()
        {
            NavigateToSettings("Change your personal details");
            return new ChangeYourPersonalDetailsPage(context);
        }

        public ForgottenYourPasswordPage NavigateToChangeYourPassword()
        {
            NavigateToSettings("Change your password");
            return new ForgottenYourPasswordPage(context);
        }

        public ChangeYourEmailAddressPage NavigateToChangeYourEmailAddress()
        {
            NavigateToSettings("Change your email address");
            return new ChangeYourEmailAddressPage(context);
        }

        protected void ClickAccountSettings() => formCompletionHelper.ClickLinkByText(NavigationLink, "Account settings");

        protected void NavigateToSettings(string settingsName)
        {
            ClickAccountSettings();
            formCompletionHelper.ClickLinkByText(NavigationSubLink, settingsName);
        }
    }
}
