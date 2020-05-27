using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PublicSectorReportingSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PublicSectorReportingSqlDataHelper _publicSectorReportingSqlDataHelper;

        public PublicSectorReportingSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _publicSectorReportingSqlDataHelper = context.Get<PublicSectorReportingSqlDataHelper>();
        }

        [Then(@"the employer can create a new report")]
        public void ThenTheEmployerCanCreateANewReport()
        {
            _publicSectorReportingSqlDataHelper.RemovePublicSectorReporting(_objectContext.GetAccountId());

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
