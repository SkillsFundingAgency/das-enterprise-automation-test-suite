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
        private static By CmadDashboardLinkAfterFullyConfirmed => By.XPath("//a[text()='My apprenticeship details']");
        private static By CmadDashboardText => By.XPath("(//ul[@class='dashboard-nav dashboard-li']/li/h2/following-sibling::p)[1]");
        private static By HelpAndSupportSectionLink => By.XPath("//a[text()='help and support section']");
        private static By InCompleteStatusSelector => By.CssSelector("#dashboard-section strong.govuk-tag--yellow");

        public ApprenticeHomePage(ScenarioContext context, bool verifyConfirmYourApprenticeLink = true) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(TopBlueBannerHeader, $"{objectContext.GetFirstName()} {objectContext.GetLastName()}"),
                () => { if (verifyConfirmYourApprenticeLink) VerifySucessNotification(); return true; }
            });
        }

        public bool VerifyNotificationBannerIsNotDisplayed() => pageInteractionHelper.IsElementDisplayed(NotificationBanner);

        public ApprenticeHomePage VerifySucessNotification()
        {
            VerifyNotificationBannerHeader("Success");
            VerifyNotificationBannerContent("You have created an account and we have found your apprenticeship.");
            VerifyElement(InCompleteStatusSelector, StatusHelper.DashboardInCompleteStatus);
            return VerifyDashboardCMADSectionWhenInCompleteOrUnConfirmedOnHomePage();
        }

        public ApprenticeOverviewPage NavigateToOverviewPageWithCmadLinkOnTheHomePage()
        {
            formCompletionHelper.Click(CmadDashboardLinkWhenIncompleteOrUnConfirmed);
            return new ApprenticeOverviewPage(context, false);
        }

        public HelpAndSupportPage NavigateToHelpAndSupportPageWithTheLinkOnHomePage()
        {
            formCompletionHelper.Click(HelpAndSupportSectionLink);
            return new HelpAndSupportPage(context);
        }

        public ApprenticeHomePage VerifyCMADCardOnHomePageOnceFullyConfirmed()
        {
            VerifyElement(CmadDashboardLinkAfterFullyConfirmed);
            VerifyElement(CmadDashboardText, StatusHelper.DashboardCmadSectionTextWhenFullyConfirmed);
            return this;
        }

        public ApprenticeHomePage VerifyDashboardCMADSectionWhenInCompleteOrUnConfirmedOnHomePage() 
        {
            VerifyElement(CmadDashboardLinkWhenIncompleteOrUnConfirmed);
            VerifyElement(CmadDashboardText, StatusHelper.DashboardCmadSectionTextWhenInCompleteOrUnConfirmed);
            return this; 
        }
    }
}
