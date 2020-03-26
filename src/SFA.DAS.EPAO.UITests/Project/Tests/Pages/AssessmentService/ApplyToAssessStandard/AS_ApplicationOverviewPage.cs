using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ApplicationOverviewPage : EPAO_BasePage
    {
        protected override string PageTitle => "Application overview";

        private readonly ScenarioContext _context;

        public AS_ApplicationOverviewPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ApplyToStandardPage GoToApplyToStandard()
        {
            formCompletionHelper.ClickLinkByText("Go to apply to assess a standard");
            return new AS_ApplyToStandardPage(_context);
        }

        public AS_ApplicationSubmittedPage Submit()
        {
            Continue();
            return new AS_ApplicationSubmittedPage(_context);
        }
    }
}
