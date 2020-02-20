using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class FinancialHealthAssessmentPage : RoatpApplyBasePage
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
