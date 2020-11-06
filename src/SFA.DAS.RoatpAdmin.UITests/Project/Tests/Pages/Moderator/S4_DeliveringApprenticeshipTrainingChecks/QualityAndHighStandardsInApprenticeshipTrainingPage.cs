using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class QualityAndHighStandardsInApprenticeshipTrainingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Management hierarchy's expectations for quality and high standards in apprenticeship training";
        private readonly ScenarioContext _context;

        public QualityAndHighStandardsInApprenticeshipTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public HowExpectationsForQualityPage SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
        {
            objectContext.SetIsUploadFile();
            SelectPassAndContinueToSubSection();
            return new HowExpectationsForQualityPage(_context);
        }
    }
}