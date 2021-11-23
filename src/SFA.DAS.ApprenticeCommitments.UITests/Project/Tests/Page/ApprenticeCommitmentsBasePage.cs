using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ApprenticeCommitmentsBasePage : TopBannerSettingsPage
    {
        #region Helpers and Context
        protected readonly ApprenticeLoginSqlDbHelper loginInvitationsSqlDbHelper;
        protected readonly ObjectContext objectContext;
        private readonly ScenarioContext _context;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly ApprenticeCommitmentsConfig apprenticeCommitmentsConfig;
        protected readonly ApprenticeCommitmentsDataHelper apprenticeCommitmentsDataHelper;
        #endregion

        protected virtual By ServiceHeader => By.CssSelector(".govuk-header__link--service-name");
        protected By NotificationBanner => By.CssSelector(".govuk-notification-banner");
        protected By NotificationBannerHeader => By.CssSelector(".govuk-notification-banner__header");
        protected By NotificationBannerContent => By.CssSelector(".govuk-notification-banner__content");
        protected By ConfirmingEntityNamePageHeader => By.CssSelector(".govuk-heading-l");
        protected By TopBlueBannerHeader => By.CssSelector(".app-user-header__name");
        protected By PrivacyLinkInTheBody => By.XPath("//a[@href='/Privacy']");
        protected By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");
        protected override By ContinueButton => By.XPath("//button[text()='Continue']");
        protected string ServiceName => "My apprenticeship";
        protected By NonClickableServiceHeader => By.CssSelector(".das-header__span");
        protected By HomeTopNavigationLink => By.XPath("//a[text()='Home']");
        protected By CMADTopNavigationLink => By.XPath("//a[text()='Confirm my apprenticeship details']");
        protected By HelpTopNavigationLink => By.XPath("//a[text()='Help and support']");
        private By CookieBanner => By.CssSelector(".das-cookie-banner");
        private By FeedbackLinkOnBetaBanner => By.XPath("//div[contains(@class,'govuk-phase-banner')]/p/span/a[text()='feedback']");
        private By PrivacyFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Privacy']");
        private By CookiesFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Cookies']");
        private By TermsOfUseFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Terms of use']");
        private string SignOutLinkText => "Sign out";
        protected By Password => By.CssSelector("#Password");

        public ApprenticeCommitmentsBasePage(ScenarioContext context, bool verifypage = true, bool verifyServiceHeader = true) : base(context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            loginInvitationsSqlDbHelper = context.Get<ApprenticeLoginSqlDbHelper>();
            apprenticeCommitmentsConfig = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();
            apprenticeCommitmentsDataHelper = context.Get<ApprenticeCommitmentsDataHelper>();
            if (verifypage) VerifyPage();
            VerifyPage(CookieBanner);
            VerifyPage(FeedbackLinkOnBetaBanner);
            if (verifyServiceHeader) VerifyPage(ServiceHeader, ServiceName);
            VerifyFooterLinks();
        }

        protected void VerifyNotificationBannerHeader(string expected) => VerifyPage(NotificationBannerHeader, expected);

        protected void VerifyNotificationBannerContent(string expected) => VerifyPage(NotificationBannerContent, expected);

        public ApprenticeOverviewPage ContinueToHomePage()
        {
            Continue();
            return new ApprenticeOverviewPage(_context);
        }

        public ApprenticeHomePage NavigateToHomePageFromTopNavigationLink()
        {
            formCompletionHelper.Click(HomeTopNavigationLink);
            return new ApprenticeHomePage(_context, false);
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

        protected void AssertTopNavigationLinksNotToBePresent()
        {
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(HomeTopNavigationLink), "Home Top navigation link is present and it should not be on this page");
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(CMADTopNavigationLink), "CMAD Top navigation link is present and it should not be on this page");
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(HelpTopNavigationLink), "Help Top navigation link is present and it should not be on this page");
        }

        protected override void Continue() => formCompletionHelper.Click(ContinueButton);
    }
}
