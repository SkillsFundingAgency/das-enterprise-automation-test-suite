using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_VolumeEndPointAssessmentPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will the volume of end-point assessments be achieved with the number of assessors you will have?";

        private readonly ScenarioContext _context;

        public AS_VolumeEndPointAssessmentPage(ScenarioContext context) : base(context) => _context = context;

        public AS_HowRecruitAndTrainAssessorsPage EnterVolume()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_HowRecruitAndTrainAssessorsPage(_context);
        }
    }
}
