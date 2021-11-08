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

        public ApprenticeOverviewPage(ScenarioContext context) : base(context) => _context = context;

        public (string sectionName, string sectionStatus) GetConfirmYourEmployerStatus() => (SectionHelper.Section1, GetConfirmationStatus(SectionHelper.Section1));

        public (string sectionName, string sectionStatus) GetConfirmYourTrainingProviderStatus() => (SectionHelper.Section2, GetConfirmationStatus(SectionHelper.Section2));

        public (string sectionName ,string sectionStatus) GetConfirmYourApprenticeshipStatus() => (SectionHelper.Section3, GetConfirmationStatus(SectionHelper.Section3));

        public (string sectionName, string sectionStatus) GetConfirmYourApprenticeshipDeliveryStatus() => (SectionHelper.Section4, GetConfirmationStatus(SectionHelper.Section4));

        public (string sectionName, string sectionStatus) GetConfirmYourRolesAndResponsibilityStatus() => (SectionHelper.Section5, GetConfirmationStatus(SectionHelper.Section5));

        public ApprenticeOverviewPage VerifyEmployerAndApprenticehsipCoCNotification() => VerifyCocNotification("Your employer and apprenticeship details have been corrected. Please review and confirm the changes to your apprenticeship details.");

        public ApprenticeOverviewPage VerifyApprenticeshipOnlyCoCNotification() => VerifyCocNotification("The details of your apprenticeship have been corrected. Please review and confirm the changes to your apprenticeship details.");

        public ApprenticeOverviewPage VerifyCoCNotificationIsNotDisplayed()
        {
            Assert.AreEqual(false, pageInteractionHelper.IsElementDisplayed(NotificationBanner), "CoC notification banner is displayed");

            return this;
        }

        public bool IsCoCNotificationDisplayed() => pageInteractionHelper.IsElementDisplayed(NotificationBanner);

        private ApprenticeOverviewPage VerifyCocNotification(string expected) { VerifyPage(NotificationBanner, expected); return this; }

        private string GetConfirmationStatus(string section) => pageInteractionHelper.GetText(() => tableRowHelper.GetColumn(section, Status, AppStatusTableIdentifier, AppStatusRowIdentifier));
    }
}
