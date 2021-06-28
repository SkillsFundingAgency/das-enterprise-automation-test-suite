using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class SupportingApprenticesPage : ModeratorBasePage
    {
        protected override string PageTitle => "Supporting apprentices during apprenticeship training";
        private readonly ScenarioContext _context;

        public SupportingApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public WaysOfSupportingApprenticesPage SelectPassAndContinueInSupportingApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new WaysOfSupportingApprenticesPage(_context);
        }
        public ModerationApplicationAssessmentOverviewPage SelectPassAndContinueInSupportingApprenticesPage_MainRoute()
        {
            SelectPassAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }
        public WaysOfSupportingApprenticesPage SelectFailAndContinueInSupportingApprenticesPage()
        {
            SelectFailAndContinueToSubSection();
            return new WaysOfSupportingApprenticesPage(_context);
        }
        public ModerationApplicationAssessmentOverviewPage SelectFailAndContinueInSupportingApprenticesPage_MainRoute()
        {
            SelectFailAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }
    }
}