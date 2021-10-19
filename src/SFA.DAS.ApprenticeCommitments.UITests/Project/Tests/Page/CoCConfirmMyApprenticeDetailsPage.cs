using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CoCConfirmMyApprenticeDetailsPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Confirm my apprenticeship details";

        private string YourApprenticeshipDetailsLinkText => SectionHelper.Section3;

        private By Status => By.CssSelector(".govuk-tag");

        private By NotificationBanner => By.CssSelector(".govuk-notification-banner");

        private string AppStatusTableIdentifier => ".govuk-list.app-status-list";

        private string AppStatusRowIdentifier => ".app-status-list__list-item";

        private readonly ScenarioContext _context;

        public CoCConfirmMyApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public (string sectionName, string sectionStatus) GetConfirmYourEmployerStatus() => (SectionHelper.Section1, GetConfirmationStatus(SectionHelper.Section1));

        public (string sectionName, string sectionStatus) GetConfirmYourTrainingProviderStatus() => (SectionHelper.Section2, GetConfirmationStatus(SectionHelper.Section2));

        public (string sectionName ,string sectionStatus) GetConfirmYourApprenticeshipStatus() => (SectionHelper.Section3, GetConfirmationStatus(SectionHelper.Section3));

        public (string sectionName, string sectionStatus) GetConfirmYourApprenticeshipDeliveryStatus() => (SectionHelper.Section4, GetConfirmationStatus(SectionHelper.Section4));

        public (string sectionName, string sectionStatus) GetConfirmYourRolesAndResponsibilityStatus() => (SectionHelper.Section5, GetConfirmationStatus(SectionHelper.Section5));

        public ConfirmYourApprenticeshipDetailsPage ConfirmYourApprenticeshipDetails()
        {
            formCompletionHelper.ClickLinkByText(YourApprenticeshipDetailsLinkText);
            return new ConfirmYourApprenticeshipDetailsPage(_context);
        }

        public void VerifyEmployerOnlyCoCNotification() => VerifyCocNotification("Your employer details been corrected. Please review and confirm the changes to your apprenticeship details");

        public void VerifyApprenticeshipOnlyCoCNotification() => VerifyCocNotification("The details of your apprenticeship have been corrected. Please review and confirm the changes to your apprenticeship details");

        private void VerifyCocNotification(string expected) => VerifyPage(NotificationBanner, expected);

        private string GetConfirmationStatus(string section) => pageInteractionHelper.GetText(() => tableRowHelper.GetColumn(section, Status, AppStatusTableIdentifier, AppStatusRowIdentifier));
    }
}
