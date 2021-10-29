using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ApprenticeCommitmentsBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly ApprenticeLoginSqlDbHelper loginInvitationsSqlDbHelper;
        protected readonly ObjectContext objectContext;
        private readonly ScenarioContext _context;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly ApprenticeCommitmentsConfig apprenticeCommitmentsConfig;
        protected readonly ApprenticeCommitmentsDataHelper apprenticeCommitmentsDataHelper;
        #endregion

        protected virtual By ServiceHeader => By.CssSelector(".govuk-header__link--service-name");
        protected By ConfirmingEntityNamePageHeader => By.CssSelector(".govuk-heading-l");
        protected By TopBlueBannerHeader => By.CssSelector(".app-user-header__name");
        private By CookieBanner => By.CssSelector(".das-cookie-banner");
        private By FeedbackLinkOnBetaBanner => By.XPath("//div[contains(@class,'govuk-phase-banner')]/p/span/a[text()='feedback']");
        private By PrivacyFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Privacy']");
        private By CookiesFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Cookies']");
        private By TermsOfUseFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Terms of use']");
        protected override By ContinueButton => By.XPath("//button[text()='Continue']");
        protected string ServiceName => "My apprenticeship";
        protected By NonClickableServiceHeader => By.CssSelector(".das-header__span");
        private By HomeTopNavigationLink => By.XPath("//a[text()='Home']");
        private By CMADTopNavigationLink => By.XPath("//a[text()='Confirm my apprenticeship details']");
        private By HelpTopNavigationLink => By.XPath("//a[text()='Help and support']");
        private string SignOutLinkText => "Sign out";

        private By NavigationLink => By.CssSelector(".app-user-header a.das-user-navigation__link");

        protected By NavigationSubLink => By.CssSelector(".app-user-header a.das-user-navigation__sub-menu-link");


        public ApprenticeCommitmentsBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            loginInvitationsSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            apprenticeCommitmentsConfig = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
            apprenticeCommitmentsDataHelper = context.Get<ApprenticeCommitmentsDataHelper>();
            if (verifypage) VerifyPage();
            VerifyPage(CookieBanner);
            VerifyPage(FeedbackLinkOnBetaBanner);
            VerifyPage(ServiceHeader, ServiceName);
            VerifyFooterLinks();
        }

        public virtual List<string> AccountSettingList() => new List<string> { "Change your personal details", "Change your password", "Change your email address" };

        public ChangeYourPersonalDetailsPage NavigateToChangeYourPersonalDetails()
        {
            NavigateToSettings("Change your personal details");
            return new ChangeYourPersonalDetailsPage(_context);
        }

        public ChangeYourPasswordPage NavigateToChangeYourPassword()
        {
            NavigateToSettings("Change your password");
            return new ChangeYourPasswordPage(_context);
        }

        public ChangeYourEmailAddressPage NavigateToChangeYourEmailAddress()
        {
            NavigateToSettings("Change your email address");
            return new ChangeYourEmailAddressPage(_context);
        }

        public ApprenticeOverviewPage ContinueToHomePage()
        {
            Continue();
            return new ApprenticeOverviewPage(_context);
        }

        public ApprenticeHomePage NavigateToHomePageFromTopNavigationLink()
        {
            formCompletionHelper.Click(HomeTopNavigationLink);
            return new ApprenticeHomePage(_context);
        }

        public ApprenticeOverviewPage NavigateToOverviewPageFromTopNavigationLink()
        {
            formCompletionHelper.Click(CMADTopNavigationLink);
            return new ApprenticeOverviewPage(_context, false);
        }

        public HelpAndSupportPage NavigateToHelpPageFromTopNavigationLink()
        {
            formCompletionHelper.Click(HelpTopNavigationLink);
            return new HelpAndSupportPage(_context);
        }

        private void VerifyFooterLinks()
        {
            VerifyPage(PrivacyFooterLink);
            VerifyPage(CookiesFooterLink);
            VerifyPage(TermsOfUseFooterLink);
        }

        public SignedOutPage SignOutFromTheService()
        {
            formCompletionHelper.ClickLinkByText(SignOutLinkText);
            return new SignedOutPage(_context);
        }

        protected void ClickAccountSettings() => formCompletionHelper.ClickLinkByText(NavigationLink, "Account settings");

        private void NavigateToSettings(string settingsName)
        {
            ClickAccountSettings();
            formCompletionHelper.ClickLinkByText(NavigationSubLink, settingsName);
        }
    }
}
