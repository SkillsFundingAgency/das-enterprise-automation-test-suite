using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.DeliveringApprenticeshipTrainingChecks
{
    public class HowExpectationsForQualityPage : AssessorBasePage
    {
        protected override string PageTitle => "How expectations for quality and high standards in apprenticeship training are monitored and evaluated";
        private readonly ScenarioContext _context;

        public HowExpectationsForQualityPage(ScenarioContext context) : base(context) => _context = context;

        public OverallResponsibilityForMaintainingExpectationsPage SelectPassAndContinueInHowExpectationsForQualityPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForMaintainingExpectationsPage(_context);
        }
    }
}