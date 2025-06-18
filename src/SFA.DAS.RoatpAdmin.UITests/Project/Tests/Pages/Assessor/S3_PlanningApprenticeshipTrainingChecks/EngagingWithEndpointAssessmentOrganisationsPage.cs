using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class EngagingWithEndpointAssessmentOrganisationsPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Engaging with end-point assessment organisations (EPAOs)";

        public EngagingAndWorkWithAwardingBodiesPage SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage_FrameWorksOnly()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingAndWorkWithAwardingBodiesPage(context);
        }
        public TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
        {
            SelectPassAndContinueToSubSection();
            return new TransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage(context);
        }
    }
}