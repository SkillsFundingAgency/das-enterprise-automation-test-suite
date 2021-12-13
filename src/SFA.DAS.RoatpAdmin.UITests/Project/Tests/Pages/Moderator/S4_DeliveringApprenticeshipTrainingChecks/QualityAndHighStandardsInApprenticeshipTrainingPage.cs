using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class QualityAndHighStandardsInApprenticeshipTrainingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Management hierarchy's expectations for quality and high standards in apprenticeship training";
        
        public QualityAndHighStandardsInApprenticeshipTrainingPage(ScenarioContext context) : base(context) { }

        public HowExpectationsForQualityPage SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
        {
            objectContext.SetIsUploadFile();
            SelectPassAndContinueToSubSection();
            return new HowExpectationsForQualityPage(context);
        }

        public HowExpectationsForQualityPage SelectFailAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
        {
            objectContext.SetIsUploadFile();
            SelectFailAndContinueToSubSection();
            return new HowExpectationsForQualityPage(context);
        }

        public HowExpectationsForQualityPage SelectContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
        {
            Continue();
            return new HowExpectationsForQualityPage(context);
        }
    }
}