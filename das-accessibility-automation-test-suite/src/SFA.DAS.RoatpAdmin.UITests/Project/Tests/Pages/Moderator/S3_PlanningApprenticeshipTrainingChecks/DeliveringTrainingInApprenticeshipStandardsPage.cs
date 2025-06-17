using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class DeliveringTrainingInApprenticeshipStandardsPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "standards";

        public EngagingWithEndpointAssessmentOrganisationsPage SelectPassAndContinueInDeliveringTraining()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(context);
        }

        public EngagingWithEndpointAssessmentOrganisationsPage SelectFailAndContinueInDeliveringTraining()
        {
            SelectFailAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(context);
        }

    }
}