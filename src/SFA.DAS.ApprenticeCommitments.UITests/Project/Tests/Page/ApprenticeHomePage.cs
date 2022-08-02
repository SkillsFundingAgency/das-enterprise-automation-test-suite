using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeHomePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => $"Welcome, {objectContext.GetFirstName()} {objectContext.GetLastName()}";
        private static By CmadDashboardLinkWhenIncompleteOrUnConfirmed => By.XPath("//ul[@class='dashboard-nav dashboard-li']/li/h2/a[contains(text(),'Confirm my apprenticeship details')]");
        private static By HelpAndSupportDashboardLink => By.XPath("//ul[@class='dashboard-nav dashboard-li']/li/h2/a[contains(text(),'Help and support')]");
        private static By CmadDashboardLinkAfterFullyConfirmed => By.XPath("//a[contains(text(),'My apprenticeship details')]");
        private static By CmadDashboardText => By.XPath("(//ul[@class='dashboard-nav dashboard-li']/li/h2/following-sibling::p)[1]");
        private static By HelpAndSupportDashboardText => By.XPath("(//ul[@class='dashboard-nav dashboard-li']/li/h2/following-sibling::p)[2]");
        private static By InCompleteStatusSelector => By.CssSelector("#dashboard-section strong.govuk-tag--yellow");
        private static By MyApprenticeshipDetailsLink => By.XPath("//a[contains(text(),'My apprenticeship details')]");

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
            formCompletionHelper.Click(MyApprenticeshipDetailsLink);
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
            VerifyElement(CmadDashboardText, StatusHelper.DashboardCmadSectionTextWhenFullyConfirmed);
            return this;
        }

        public ApprenticeHomePage VerifyDashboardCMADSectionWhenInCompleteOnHomePage()
        {
            VerifyElement(InCompleteStatusSelector, StatusHelper.DashboardInCompleteStatus);
            VerifyElement(CmadDashboardLinkWhenIncompleteOrUnConfirmed);
            VerifyElement(CmadDashboardText, StatusHelper.DashboardCmadSectionTextWhenInCompleteOrUnConfirmed);
            return this;
        }

        public ApprenticeHomePage VerifyDashboardHelpAndSupportSectionOnHomePage()
        {
            VerifyElement(HelpAndSupportDashboardLink);
            VerifyElement(HelpAndSupportDashboardText, StatusHelper.DashboardHelpAndSupportDashboardText);
            return this;
        }
    }
}
