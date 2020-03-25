using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ApplyToStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Apply to assess a standard";

        private readonly ScenarioContext _context;

        public AS_ApplyToStandardPage(ScenarioContext context) : base(context) => _context = context;
    }
}
