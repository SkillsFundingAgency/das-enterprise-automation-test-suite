using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage : ModeratorBasePage
    {
        protected override string PageTitle => "Transitioning from apprenticeship frameworks to apprenticeship standards";

        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(ScenarioContext context) : base(context) { }

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
