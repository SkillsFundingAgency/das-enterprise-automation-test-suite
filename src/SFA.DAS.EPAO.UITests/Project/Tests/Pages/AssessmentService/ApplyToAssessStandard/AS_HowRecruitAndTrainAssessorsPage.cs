using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_HowRecruitAndTrainAssessorsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How do you recruit and train assessors?";

        private readonly ScenarioContext _context;

        public AS_HowRecruitAndTrainAssessorsPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ExperiencePage EnterHowRecruitAndTrainAssessors()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_ExperiencePage(_context);
        }
    }
}
