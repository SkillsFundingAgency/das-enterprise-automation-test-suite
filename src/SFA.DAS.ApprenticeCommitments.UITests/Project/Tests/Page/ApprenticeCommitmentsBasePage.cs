using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class ApprenticeCommitmentsBasePage : TopBannerSettingsPage
    {
        protected virtual By ServiceHeader => By.CssSelector(".govuk-header__link--service-name");
        protected static By NotificationBanner => By.CssSelector(".govuk-notification-banner");
        protected static By NotificationBannerHeader => By.CssSelector(".govuk-notification-banner__header");
        protected static By NotificationBannerContent => By.CssSelector(".govuk-notification-banner__content");
        protected static By ConfirmingEntityNamePageHeader => By.CssSelector("main div .govuk-heading-m");
        protected static By TopBlueBannerHeader => By.CssSelector(".app-user-header__name");
        protected static By PrivacyLinkInTheBody => By.XPath("//a[@href='/Privacy']");
        protected static By SubmitButton => By.CssSelector("button.govuk-button[type='submit']");
        protected override By ContinueButton => By.XPath("//button[text()='Continue']");
        protected static By ConfirmButton => By.Id("employer-provider-confirm");
        protected static string ServiceName => "My apprenticeship";
        protected static By HomeTopNavigationLink => By.XPath("//a[text()='Home']");
        protected static By CMADTopNavigationLink => By.XPath("//a[@class='app-navigation__link']/text[contains(text(),'Confirm my apprenticeship details')]");
        protected static By CMADTopNavigationLinkAfterFullyConfirmed => By.XPath("//a[@class='app-navigation__link']/text[contains(text(),'My apprenticeship details')]");
        protected static By HelpTopNavigationLink => By.XPath("//a[@class='app-navigation__link' and text()='Help and support']");
        private static By FeedbackLinkOnBetaBanner => By.XPath("//div[contains(@class,'govuk-phase-banner')]/p/span/a[text()='feedback']");
        private static By PrivacyFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Privacy']");
        private static By CookiesFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Cookies']");
        private static By TermsOfUseFooterLink => By.XPath("//a[@class='govuk-footer__link' and text()='Terms of use']");
        private static string SignOutLinkText => "Sign out";
        protected static By Password => By.CssSelector("#Password");
        protected static By ErrorSummaryTitle => By.Id("error-summary-title");
        protected static By ErrorSummaryText => By.CssSelector(".govuk-error-summary__list a");
        protected static By FieldValidtionError => By.CssSelector(".field-validation-error");
        private static By ApprenticeshipLevelInfo => By.XPath("//th[text()='Level']/following-sibling::td");
        private static By PlannedStartDateInfo => By.XPath("//th[text()='Planned start date for training']/following-sibling::td");
        private static By PlannedStartDateInfoForPortable => By.XPath("//th[text()='Planned training start date']/following-sibling::td");
        private static By PlannedEndDate => By.XPath("//th[text()='Planned training end date']/following-sibling::td");
        private static By DeliveryModel => By.XPath("//th[text()='Delivery model']/following-sibling::td");

        public ApprenticeCommitmentsBasePage(ScenarioContext context, bool verifypage = true, bool verifyserviceheader = true) : base(context)
        {
            bool verifyPage(bool verify) { if (verify) return VerifyPage(); else return true; }

            bool verifyServiceHeader(bool verify) { if (verify) return VerifyPage(ServiceHeader, ServiceName); else return true; }

            MultipleVerifyPage(
            [
                () => verifyPage(verifypage),
                () => VerifyPage(FeedbackLinkOnBetaBanner),
                () => verifyServiceHeader(verifyserviceheader),
                () => { VerifyFooterLinks(); return true; }
            ]);
        }

        protected void VerifyNotificationBannerHeader(string expected) => VerifyElement(NotificationBannerHeader, expected);

        protected void VerifyNotificationBannerContent(string expected) => VerifyElement(NotificationBannerContent, expected);

        public ApprenticeOverviewPage ContinueToCMADOverviewPage()
        {
            Continue();
            return new ApprenticeOverviewPage(context);
        }

        public ApprenticeHomePage NavigateToHomePageFromTopNavigationLink()
        {
            formCompletionHelper.Click(HomeTopNavigationLink);
            return new ApprenticeHomePage(context, false);
        }

        public ApprenticeOverviewPage NavigateToOverviewPageFromTopNavigationLink()
        {
            formCompletionHelper.Click(CMADTopNavigationLink);
            return new ApprenticeOverviewPage(context, false);
        }

        public FullyConfirmedOverviewPage NavigateToOverviewPageFromTopNavigationLinkForDbConfirmedDetails()
        {
            formCompletionHelper.Click(CMADTopNavigationLink);
            return new FullyConfirmedOverviewPage(context, false);
        }

        public FullyConfirmedOverviewPage NavigateToFullyConfirmedOverviewPageFromTopNavigationLink()
        {
            formCompletionHelper.Click(CMADTopNavigationLinkAfterFullyConfirmed);
            return new FullyConfirmedOverviewPage(context);
        }

        public HelpAndSupportPage NavigateToHelpPageFromTopNavigationLink()
        {
            formCompletionHelper.Click(HelpTopNavigationLink);
            return new HelpAndSupportPage(context);
        }

        private void VerifyFooterLinks()
        {
            VerifyElement(PrivacyFooterLink);
            VerifyElement(CookiesFooterLink);
            VerifyElement(TermsOfUseFooterLink);
        }

        public SignedOutPage SignOutFromTheService()
        {
            formCompletionHelper.ClickLinkByText(SignOutLinkText);
            return new SignedOutPage(context);
        }

        public void VerifyErrorSummaryTitle() => VerifyPage(ErrorSummaryTitle, "There is a problem");

        public string GetApprenticeshipPlannedStartDateInfo() => pageInteractionHelper.GetText(PlannedStartDateInfo);

        public string GetPortableApprenticeshipPlannedStartDateInfo() => pageInteractionHelper.GetText(PlannedStartDateInfoForPortable);

        public string GetApprenticeshipEndDateInfo() => pageInteractionHelper.GetText(PlannedEndDate);

        public string GetApprenticeshipLevelInfo() => pageInteractionHelper.GetText(ApprenticeshipLevelInfo);

        public string GetDeliveryModelInfo() => pageInteractionHelper.GetText(DeliveryModel);

        protected void AssertTopNavigationLinksNotToBePresent()
        {
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(HomeTopNavigationLink), "Home Top navigation link is present and it should not be on this page");
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(CMADTopNavigationLink), "CMAD Top navigation link is present and it should not be on this page");
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(HelpTopNavigationLink), "Help Top navigation link is present and it should not be on this page");
        }

        protected override void Continue() => formCompletionHelper.Click(ContinueButton);
    }
}
