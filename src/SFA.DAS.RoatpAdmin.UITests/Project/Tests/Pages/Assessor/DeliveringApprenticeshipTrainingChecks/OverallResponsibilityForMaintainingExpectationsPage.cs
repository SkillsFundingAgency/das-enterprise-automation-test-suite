using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.DeliveringApprenticeshipTrainingChecks
{
    public class OverallResponsibilityForMaintainingExpectationsPage : AssessorBasePage
    {
        protected override string PageTitle => "Overall responsibility for maintaining expectations for quality and high standards in apprenticeship training";
        private readonly ScenarioContext _context;

        public OverallResponsibilityForMaintainingExpectationsPage(ScenarioContext context) : base(context) => _context = context;

        public ExpectationsForQualityAndHighStandardsPage SelectPassAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
        {
            SelectPassAndContinueToSubSection();
            return new ExpectationsForQualityAndHighStandardsPage(_context);
        }
    }
}