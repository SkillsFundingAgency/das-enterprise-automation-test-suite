using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Moderator
{
    [Binding]
    public class ModerationSteps
    {
        private ScenarioContext _context;
        private ModerationApplicationAssessmentOverviewPage _moderationApplicationAssessmentOverviewPage;
        private ModeratorEndtoEndStepsHelper _moderatorEndtoEndStepsHelper;
        private ModerationApplicationsPage _moderationApplicationsPage;

        public ModerationSteps(ScenarioContext context)
        {
            _context = context;
            _moderatorEndtoEndStepsHelper = new ModeratorEndtoEndStepsHelper(context);
        }

        [When(@"selects the (Main|Employer|Supporting) provider route application from Moderation Tab")]
        public void WhenSelectsTheMainProviderRouteApplicationFromModerationTab(string Route)
        {
            StaffDashboardPage staffDashboardPage = new StaffDashboardPage(_context);
            staffDashboardPage.AccessAssessorAndModerationApplications();

            AssessorApplicationsPage assessorApplicationsPage = new AssessorApplicationsPage(_context);

            if (Route.Equals("Main"))
            {
                assessorApplicationsPage.ModeratorSelectsAssignToMeForMainProvider();
            }
            else if (Route.Equals("Employer"))
            {
                assessorApplicationsPage.ModeratorSelectsAssignToMeForEmployerProvider();
            }
            else if (Route.Equals("Supporting"))
            {
                assessorApplicationsPage.ModeratorSelectsAssignToMeForSupportingProvider();
            }
        }

        [Then(@"the Moderator assesses all the sections of the application as PASS")]
        public void ThenTheModeratorAssessesAllTheSectionsOfTheApplicationAsPASS() =>
            _moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.CompleteAllSectionsWithPass((new ModerationApplicationAssessmentOverviewPage(_context)));


        [Then(@"the Moderator assesses the outcome as PASS")]
        public void ThenTheModeratorAssessesTheOutcomeAsPASS()
        {
            _moderationApplicationsPage = _moderatorEndtoEndStepsHelper.CompleteModeratorOutcomeSectionAsPass(_moderationApplicationAssessmentOverviewPage);
        }

        [Then(@"the Moderator FAILS few sections")]
        public void ThenTheModeratorFAILSFewSections()
        {
            _moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.FailWorkingWithSubcontractors(_moderationApplicationAssessmentOverviewPage);
            _moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.FailTypeOfApprenticeshipTraining(_moderationApplicationAssessmentOverviewPage);
            _moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.FailYourSectorsAndEmployees(_moderationApplicationAssessmentOverviewPage);
        }

        [Then(@"the Moderator assesses the outcome as FAIL")]
        public void ThenTheModeratorAssessesTheOutcomeAsFAIL()
        {
               _moderationApplicationsPage = _moderatorEndtoEndStepsHelper.CompleteModeratorOutcomeSectionAsFail(_moderationApplicationAssessmentOverviewPage);
        }

        [Then(@"the Moderator assesses the outcome as CLARIFICATION")]
        public void ThenTheModeratorAssessesTheOutcomeAsCLARIFICATION()
        {
            _moderationApplicationsPage = _moderatorEndtoEndStepsHelper.CompleteModeratorOutcomeSectionAsAskClarification(_moderationApplicationAssessmentOverviewPage);
        }

        [Then(@"the Outcome tab is updated as (PASS|FAIL)")]
        public void ThenTheOutcomeTabIsUpdated(string expectedStatus) => _moderationApplicationsPage.VerifyOutcomeStatus(expectedStatus);

        [Then(@"the Clarification tab is updated")]
        public void ThenTheClarificationTabIsUpdated() => _moderationApplicationsPage.VerifyClarificationStatus();
    }
}
