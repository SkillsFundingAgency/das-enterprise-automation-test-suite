using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage : ModeratorBasePage
    {
        protected override string PageTitle => "";
        //Remove page title due to a bug and awaiting fix. Bug no:- APR-2437

        private readonly ScenarioContext _context;
        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(ScenarioContext context) : base(context) => _context = context;

        public EngagingWithEndpointAssessmentOrganisationsPage SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(_context);
        }
        public EngagingAndWorkWithAwardingBodiesPage SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage_IncludesFrameworks()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingAndWorkWithAwardingBodiesPage(_context);
        }

        public EngagingWithEndpointAssessmentOrganisationsPage SelectFailAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
        {
            SelectFailAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(_context);
        }
        public EngagingAndWorkWithAwardingBodiesPage SelectFailAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage_DeliveryIncludesFrameworks()
        {
            SelectFailAndContinueToSubSection();
            return new EngagingAndWorkWithAwardingBodiesPage(_context);
        }
    }
}
