using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}";

        protected override string AccessibilityPageTitle => "Apprentice home page";

        private static By PageHeadings => By.CssSelector(".govuk-heading-m");

        private static By CmadDashboardLinkWhenIncompleteOrUnConfirmed => By.XPath($"//ul[@class='dashboard-nav dashboard-li']/li/h2/a[contains(text(),'{HomePageHelper.UnConfirmedCmadSectionTitle}')]");
        private static By UnConfimredApprenticeshipDetailsSubText => By.XPath($"//ul[@class='dashboard-nav dashboard-li']/li/h2/a[contains(text(),'{HomePageHelper.UnConfirmedCmadSectionTitle}')]/..//following-sibling::p");
        private static By CmadDashboardLinkAfterFullyConfirmed => By.XPath($"//ul[@class='dashboard-nav dashboard-li']/li/h2/a[contains(text(),'{HomePageHelper.ConfirmedCmadSectionTitle}')]");
        private static By ConfimredApprenticeshipDetailsSubText => By.XPath($"//ul[@class='dashboard-nav dashboard-li']/li/h2/a[contains(text(),'{HomePageHelper.ConfirmedCmadSectionTitle}')]/..//following-sibling::p");
        private static By HelpAndSupportDashboardLink => By.CssSelector(".govuk-heading-m a[href='/HelpAndSupport']");
        private static By CmadDashboardText => By.XPath("(//ul[@class='dashboard-nav dashboard-li']/li/h2/following-sibling::p)[1]");
        private static By CurrentApprenticeshipStatusSelector => By.CssSelector("#dashboard-section strong.govuk-tag--yellow");

        public ApprenticeHomePage(ScenarioContext context, bool verifyConfirmMyApprenticeLink = true) : base(context)
        {
            VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}");

            if (verifyConfirmMyApprenticeLink)
            {
                VerifySucessNotification();
                VerifyDashboardCMADSectionWhenInCompleteOnHomePage();
                VerifyDashboardHelpAndSupportSectionOnHomePage();
            }
        }

        public bool VerifyNotificationBannerIsNotDisplayed() => pageInteractionHelper.IsElementDisplayed(NotificationBanner);

        public ApprenticeHomePage VerifySucessNotification()
        {
            VerifyNotificationBannerHeader("Success");
            VerifyNotificationBannerContent("You have created an account and we have found your apprenticeship.");
            return this;
        }

        public ApprenticeOverviewPage NavigateToOverviewPageWithCmadLinkOnTheHomePage()
        {
            formCompletionHelper.Click(CmadDashboardLinkWhenIncompleteOrUnConfirmed);
            return new ApprenticeOverviewPage(context, false);
        }

        public FullyConfirmedOverviewPage NavigateToFullyConfirmedOverviewPageWithMyApprenticeshipDetailsLinkOnTheHomePage()
        {
            formCompletionHelper.Click(CmadDashboardLinkAfterFullyConfirmed);
            return new FullyConfirmedOverviewPage(context);
        }

        public HelpAndSupportPage NavigateToHelpAndSupportPageWithTheLinkOnHomePage()
        {
            formCompletionHelper.Click(HelpAndSupportDashboardLink);
            return new HelpAndSupportPage(context);
        }

        public ApprenticeHomePage VerifyCMADCardOnHomePageOnceFullyConfirmed()
        {
            VerifyElement(CmadDashboardLinkAfterFullyConfirmed);
            VerifyElement(CmadDashboardText, HomePageHelper.CmadSectionTextWhenFullyConfirmed);
            return this;
        }

        public ApprenticeHomePage VerifyDashboardCMADSectionWhenInCompleteOnHomePage()
        {
            VerifyElement(CurrentApprenticeshipStatusSelector, HomePageHelper.DashboardInCompleteStatus);
            VerifyElement(CmadDashboardLinkWhenIncompleteOrUnConfirmed);
            VerifyElement(CmadDashboardText, HomePageHelper.CmadSectionTextWhenInComplete);
            return this;
        }

        public ApprenticeHomePage VerifyDashboardHelpAndSupportSectionOnHomePage()
        {
            VerifyElement(HelpAndSupportDashboardLink);
            VerifyElement(() => pageInteractionHelper.FindElements(PageHeadings).Where(x => x.Text.Contains("Help and support", System.StringComparison.OrdinalIgnoreCase)).ToList(), HomePageHelper.HelpAndSupportSectionText);
            return this;
        }

        public void VerifyConfirmedCoCPageViewAndNavigateToOverviewPage()
        {
            MultipleVerifyPage(
            [
                () => VerifyPage(CmadDashboardLinkWhenIncompleteOrUnConfirmed),
                () => VerifyPage(CurrentApprenticeshipStatusSelector, HomePageHelper.DashboardUnConfimredStatusForCoC),
                () => VerifyPage(UnConfimredApprenticeshipDetailsSubText, HomePageHelper.CmadSectionTextWhenUnConfirmed),
                () => VerifyPage(CmadDashboardLinkAfterFullyConfirmed),
                () => VerifyPage(ConfimredApprenticeshipDetailsSubText, HomePageHelper.CmadSectionTextWhenFullyConfirmed)
            ]);

            formCompletionHelper.Click(CmadDashboardLinkWhenIncompleteOrUnConfirmed);
        }
    }
}