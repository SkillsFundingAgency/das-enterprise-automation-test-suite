using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ApprenticeFailedDatePage : AS_GradeDateBasePage
    {
        protected override string PageTitle => "What is the date the apprentice failed?";

        public AS_ApprenticeFailedDatePage(ScenarioContext context) : base(context)
        {
        }
    }
}
