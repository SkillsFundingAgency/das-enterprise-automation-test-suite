using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_EngageWithEmployersPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you engage with employers and training organisations?";

        private readonly ScenarioContext _context;

        public AS_EngageWithEmployersPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ManageAnyPotentialConflictPage EnterEngageWithEmployers()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_ManageAnyPotentialConflictPage(_context);
        }
    }
}
