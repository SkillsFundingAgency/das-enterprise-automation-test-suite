using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AchievementDatePage : AS_GradeDateBasePage
    {
        protected override string PageTitle => "What is the apprenticeship achievement date?";
        private readonly ScenarioContext _context;

        public AS_AchievementDatePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }
    }
}
