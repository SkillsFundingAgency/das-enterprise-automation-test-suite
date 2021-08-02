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

        public CoCConfirmMyApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyCocNotification();
        }

        public (string sectionName ,string sectionStatus) GetConfirmYourApprenticeshipStatus() => (SectionHelper.Section3, GetConfirmationStatus(SectionHelper.Section3));

        public ConfirmYourApprenticeshipDetailsPage ConfirmYourApprenticeshipDetails()
        {
            formCompletionHelper.ClickLinkByText(YourApprenticeshipDetailsLinkText);
            return new ConfirmYourApprenticeshipDetailsPage(_context);
        }

        public void VerifyCocNotification() => VerifyPage(NotificationBanner, "Changes have been made to your apprenticeship. Please review and confirm your new details.");

        private string GetConfirmationStatus(string section) => pageInteractionHelper.GetText(() => tableRowHelper.GetColumn(section, Status, AppStatusTableIdentifier, AppStatusRowIdentifier));
    }
}
