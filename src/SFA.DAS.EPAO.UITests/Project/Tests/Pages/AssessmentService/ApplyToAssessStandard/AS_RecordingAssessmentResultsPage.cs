using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_RecordingAssessmentResultsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Recording assessment results";

        public AS_RecordingAssessmentResultsPage(ScenarioContext context) : base(context) { }

        public AS_EnterYourWebAddressPage EnterAssessmentResutls()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_EnterYourWebAddressPage(context);
        }
    }
}
