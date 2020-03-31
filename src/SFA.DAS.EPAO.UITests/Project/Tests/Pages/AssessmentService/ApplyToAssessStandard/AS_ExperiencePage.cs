using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ExperiencePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "What experience, skills and qualifications will your assessors have?";

        private readonly ScenarioContext _context;

        public AS_ExperiencePage(ScenarioContext context) : base(context) => _context = context;

        public AS_OccupationalExpertisePage EnterExperience()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_OccupationalExpertisePage(_context);
        }
    }
}
