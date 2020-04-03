using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ImproveTheQualityPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How do you continuously improve the quality of your assessment practice?";

        private readonly ScenarioContext _context;

        public AS_ImproveTheQualityPage(ScenarioContext context) : base(context) => _context = context;

        public AS_EngagementWithTrailblazersAndEmployersPage EnterImproveTheQuality()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_EngagementWithTrailblazersAndEmployersPage(_context);
        }

    }
}
