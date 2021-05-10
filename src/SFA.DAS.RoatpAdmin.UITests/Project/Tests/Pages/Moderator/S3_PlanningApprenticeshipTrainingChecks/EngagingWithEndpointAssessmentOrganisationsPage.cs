using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class EngagingWithEndpointAssessmentOrganisationsPage : ModeratorBasePage
    {
        protected override string PageTitle => "Engaging with end-point assessment organisations (EPAOs)";
        private readonly ScenarioContext _context;

        public EngagingWithEndpointAssessmentOrganisationsPage(ScenarioContext context) : base(context) => _context = context;

        public EngagingAndWorkWithAwardingBodiesPage SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage_FrameWorksOnly()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingAndWorkWithAwardingBodiesPage(_context);
        }
        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
        {
            SelectPassAndContinueToSubSection();
            return new TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(_context);
        }
        
        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage SelectFailAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
        {
            SelectFailAndContinueToSubSection();
            return new TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(_context);
        }
        public EngagingAndWorkWithAwardingBodiesPage SelectFailAndContinueInEngagingWithEndpointAssessmentOrganisationsPage_FrameWorksOnly()
        {
            SelectFailAndContinueToSubSection();
            return new EngagingAndWorkWithAwardingBodiesPage(_context);
        }
        public EngagingAndWorkWithAwardingBodiesPage SelectFailAndContinueInEngagingWithEndpointAssessmentOrganisationsPage_FrameworksOnly()
        {
            SelectFailAndContinueToSubSection();
            return new EngagingAndWorkWithAwardingBodiesPage(_context);
        }
    }
}