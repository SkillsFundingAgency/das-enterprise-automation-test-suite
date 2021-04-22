using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class DeliveringTrainingInApprenticeshipStandardsPage : ModeratorBasePage
    {
        protected override string PageTitle => "Delivering training in apprenticeship standards";
        private readonly ScenarioContext _context;

        public DeliveringTrainingInApprenticeshipStandardsPage(ScenarioContext context) : base(context) => _context = context;

        public EngagingWithEndpointAssessmentOrganisationsPage SelectPassAndContinueInDeliveringTraining()
        {
            SelectPassAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(_context);
        }

        public EngagingWithEndpointAssessmentOrganisationsPage SelectFailAndContinueInDeliveringTraining()
        {
            SelectFailAndContinueToSubSection();
            return new EngagingWithEndpointAssessmentOrganisationsPage(_context);
        }

    }
}