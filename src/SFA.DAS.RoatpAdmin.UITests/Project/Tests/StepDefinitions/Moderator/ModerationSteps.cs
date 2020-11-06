using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.Moderator
{
    [Binding]
    public class ModerationSteps
    {
        private readonly ScenarioContext _context;
        private readonly ModeratorEndtoEndStepsHelper _moderatorEndtoEndStepsHelper;
        private ModerationApplicationsPage _moderationApplicationsPage;
        private ModerationApplicationAssessmentOverviewPage _moderationApplicationAssessmentOverviewPage;
        private ApplicationRoute _applicationRoute;

        public ModerationSteps(ScenarioContext context)
        {
            _context = context;
            _moderatorEndtoEndStepsHelper = new ModeratorEndtoEndStepsHelper();
        }

        [When(@"selects the (Main Provider Route|Supporting Provider Route|Employer Provider Route) application from Moderation Tab")]
        public void WhenSelectsTheMainProviderRouteApplicationFromModerationTab(ApplicationRoute applicationroute)
        {
            _applicationRoute = applicationroute;

            _moderationApplicationAssessmentOverviewPage = new StaffDashboardPage(_context).AccessAssessorAndModerationApplications().ModeratorSelectsAssignToMe();
        }

        [Then(@"the Moderator assesses all the sections of the application as PASS")]
        public void TheModeratorAssessesAllTheSectionsOfTheApplicationAsPASS()
        {
            _moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.CompleteAllSectionsWithPass(_moderationApplicationAssessmentOverviewPage, _applicationRoute);
        }

        [Then(@"the Moderator assesses the outcome as PASS")]
        public void ThenTheModeratorAssessesTheOutcomeAsPASS()
        {
            _moderationApplicationsPage = _moderatorEndtoEndStepsHelper.CompleteModeratorOutcomeSectionAsPass(_moderationApplicationAssessmentOverviewPage);
        }

        [Then(@"the Moderator FAILS few sections")]
        public void ThenTheModeratorFAILSFewSections()
        {
            _moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.FailWorkingWithSubcontractors(_moderationApplicationAssessmentOverviewPage);
            _moderationApplicationAssessmentOverviewPage = _moderatorEndtoEndStepsHelper.FailTypeOfApprenticeshipTraining(_moderationApplicationAssessmentOverviewPage, _applicationRoute);
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
