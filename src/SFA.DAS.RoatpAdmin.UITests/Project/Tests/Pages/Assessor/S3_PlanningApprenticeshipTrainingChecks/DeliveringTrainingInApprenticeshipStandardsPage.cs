using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class DeliveringTrainingInApprenticeshipStandardsPage : AssessorBasePage
    {
        protected override string PageTitle => "standards";

        public DeliveringTrainingInApprenticeshipStandardsPage(ScenarioContext context) : base(context) { }

        public EngagingWithEndpointAssessmentOrganisationsPage SelectPassAndContinueInDeliveringTraining()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(context);
        }
    }
}