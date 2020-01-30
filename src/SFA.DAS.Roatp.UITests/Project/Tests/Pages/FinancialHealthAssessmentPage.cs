using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class FinancialHealthAssessmentPage : RoatpBasePage
    {
        protected override string PageTitle => "Financial health assessment";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinancialHealthAssessmentPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage ContinueOnFinancialHealthAssessment()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
