using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PublicSectorReportingSteps
    {
        private readonly ScenarioContext _context;

        public PublicSectorReportingSteps(ScenarioContext context) => _context = context;

        [Then(@"the employer can create a new report")]
        public void ThenTheEmployerCanCreateANewReport()
        {
            var reportYourProgressPage = new PublicSectorReportingHomePage(_context, true)
                .CreateNewReport()
                .Start()
                .GoToYourOrganisationNamePage()
                .EnterNameOftheOrganisation();

            CreateOrAmendReport(reportYourProgressPage);
        }

        [Then(@"then employer can edit a submitted report")]
        public void ThenThenEmployerCanEditASubmittedReport()
        {
            var reportYourProgressPage = new PublicSectorReportingHomePage(_context, true)
                .ViewSubmittedReport()
                .ViewReport()
                .AmendReport()
                .ConfirmAmend();

            CreateOrAmendReport(reportYourProgressPage);
        }

        private void CreateOrAmendReport(ReportYourProgressPage reportYourProgressPage)
        {
            reportYourProgressPage
                .GoToYourEmployeesPage()
                .EnterEmployeesDetails()
                .GoToYourApprenticesPage()
                .EnterApprenticeDetails()
                .GoToYourFullTimeEquivalentsPage()
                .EnterFullTimeEmployeesDetails()
                .GoToWhatActionsHaveYouTakenPage()
                .EnterActionDetails()
                .GoToWhatChallengesHaveYouFacedPage()
                .EnterChallengesDetails()
                .GoToHowAreYouPlanningToMeetTheTargetPage()
                .EnterPlanningDetails()
                .GoToDoYouHaveAnythingToTellUsPage()
                .EnterCommentsDetails()
                .GoToReviewPage()
                .GoToConfirmationPage()
                .Confirm();
        }
    }
}
