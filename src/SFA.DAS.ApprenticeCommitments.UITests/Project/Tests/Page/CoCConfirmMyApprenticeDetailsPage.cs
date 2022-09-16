using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public partial class ApprenticeOverviewPage : ApprenticeCommitmentsBasePage
    {
        private By Status => By.CssSelector(".govuk-tag");
        private string AppStatusTableIdentifier => ".govuk-list.app-status-list";
        private string AppStatusRowIdentifier => ".app-status-list__list-item";

        public ApprenticeOverviewPage(ScenarioContext context) : base(context)  { }

        public (string sectionName, string sectionStatus) GetConfirmYourEmployerStatus() => (OverviewPageHelper.Section1, GetConfirmationStatus(OverviewPageHelper.Section1));

        public (string sectionName, string sectionStatus) GetConfirmYourTrainingProviderStatus() => (OverviewPageHelper.Section2, GetConfirmationStatus(OverviewPageHelper.Section2));

        public (string sectionName, string sectionStatus) GetConfirmYourApprenticeshipStatus() => (OverviewPageHelper.Section3, GetConfirmationStatus(OverviewPageHelper.Section3));

        public (string sectionName, string sectionStatus) GetConfirmYourApprenticeshipDeliveryStatus() => (OverviewPageHelper.Section4, GetConfirmationStatus(OverviewPageHelper.Section4));

        public (string sectionName, string sectionStatus) GetConfirmYourRolesAndResponsibilityStatus() => (OverviewPageHelper.Section5, GetConfirmationStatus(OverviewPageHelper.Section5));

        public ApprenticeOverviewPage VerifyEmployerCoCNotification() => VerifyEmpCocNotification(OverviewPageHelper.CoCNotificationText);

        public ApprenticeOverviewPage VerifyApprenticeshipOnlyCoCNotification() => VerifyCocNotification(OverviewPageHelper.CoCNotificationText);

        public ApprenticeOverviewPage VerifyCoCNotificationIsNotDisplayed()
        {
            Assert.AreEqual(false, pageInteractionHelper.IsElementDisplayed(NotificationBanner), "CoC notification banner is displayed");
            return this;
        }

        public bool IsCoCNotificationDisplayed() => pageInteractionHelper.IsElementDisplayed(NotificationBanner);

        private ApprenticeOverviewPage VerifyCocNotification(string expected) { VerifyElement(NotificationBanner, expected); return this; }

        private ApprenticeOverviewPage VerifyEmpCocNotification(string expected) { VerifyElement(NotificationBanner, expected); return this; }

        private string GetConfirmationStatus(string section) => pageInteractionHelper.GetText(() => tableRowHelper.GetColumn(section, Status, AppStatusTableIdentifier, AppStatusRowIdentifier));
    }
}
