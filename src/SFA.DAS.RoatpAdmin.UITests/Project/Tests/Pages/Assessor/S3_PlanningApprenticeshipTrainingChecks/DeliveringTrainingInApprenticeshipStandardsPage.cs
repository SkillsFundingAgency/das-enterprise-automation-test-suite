using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class DeliveringTrainingInApprenticeshipStandardsPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "standards";

        public EngagingWithEndpointAssessmentOrganisationsPage SelectPassAndContinueInDeliveringTraining()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(context);
        }
    }
}