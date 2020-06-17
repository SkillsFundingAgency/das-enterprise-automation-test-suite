using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.DeliveringApprenticeshipTrainingChecks
{
    public class QualityAndHighStandardsInApprenticeshipTrainingPage : AssessorBasePage
    {
        protected override string PageTitle => "Management hierarchy's expectations for quality and high standards in apprenticeship training";
        private readonly ScenarioContext _context;

        public QualityAndHighStandardsInApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public HowExpectationsForQualityPage SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new HowExpectationsForQualityPage(_context);
        }
    }
}