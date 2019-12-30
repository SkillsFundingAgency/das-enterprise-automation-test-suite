using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AchievementDatePage : AS_GradeDateBasePage
    {
        protected override string PageTitle => "What is the apprenticeship achievement date?";
 
        public AS_AchievementDatePage(ScenarioContext context) : base(context)
        {
        }
    }
}
