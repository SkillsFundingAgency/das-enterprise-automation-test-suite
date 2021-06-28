using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class SupportingApprenticesPage : AssessorBasePage
    {
        protected override string PageTitle => "Supporting apprentices during apprenticeship training";
        private readonly ScenarioContext _context;

        public SupportingApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public WaysOfSupportingApprenticesPage SelectPassAndContinueInSupportingApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new WaysOfSupportingApprenticesPage(_context);
        }
        public ApplicationAssessmentOverviewPage SelectPassAndContinueInSupportingApprenticesPage_MainRoute()
        {
            SelectPassAndContinueToSubSection();
            return new ApplicationAssessmentOverviewPage(_context);
        }
    }
}