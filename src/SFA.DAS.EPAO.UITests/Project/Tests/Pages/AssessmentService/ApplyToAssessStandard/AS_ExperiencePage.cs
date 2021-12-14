using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ExperiencePage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "What experience, skills and qualifications will your assessors have?";

        public AS_ExperiencePage(ScenarioContext context) : base(context) { }

        public AS_OccupationalExpertisePage EnterExperience()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_OccupationalExpertisePage(context);
        }
    }
}
