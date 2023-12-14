using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class QualityAndHighStandardsInApprenticeshipTrainingPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Management hierarchy's expectations for quality and high standards in apprenticeship training";

        public HowExpectationsForQualityPage SelectPassAndContinueInQualityAndHighStandardsInApprenticeshipTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new HowExpectationsForQualityPage(context);
        }
    }
}