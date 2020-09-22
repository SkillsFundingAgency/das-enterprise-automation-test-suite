using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage : ModeratorBasePage
    {
        protected override string PageTitle => "Transitioning from apprenticeship frameworks to apprenticeship standards";

        private readonly ScenarioContext _context;
        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(ScenarioContext context) : base(context) => _context = context;

        public EngagingWithEndpointAssessmentOrganisationsPage SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(_context);
        }
    }
}
