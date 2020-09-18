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

    }
}
