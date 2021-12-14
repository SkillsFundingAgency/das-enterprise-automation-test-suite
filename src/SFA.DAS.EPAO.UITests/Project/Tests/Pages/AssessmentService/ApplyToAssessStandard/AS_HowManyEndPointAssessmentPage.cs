using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_HowManyEndPointAssessmentPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How many end-point assessments will you be able to deliver annually?";

        public AS_HowManyEndPointAssessmentPage(ScenarioContext context) : base(context) { }

        public AS_VolumeEndPointAssessmentPage EnterHowManyEndPointAssessment()
        {
            formCompletionHelper.EnterText(InputNumber, standardDataHelper.GenerateRandomWholeNumber(1));
            Continue();
            return new AS_VolumeEndPointAssessmentPage(context);
        }
    }
}
