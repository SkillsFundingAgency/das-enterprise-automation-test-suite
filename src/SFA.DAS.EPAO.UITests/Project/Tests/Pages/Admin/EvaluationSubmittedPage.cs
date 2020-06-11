using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class EvaluationSubmittedPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Evaluation submitted";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EvaluationSubmittedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FinancialAssesmentPage ReturnToAccountHome()
        {
            formCompletionHelper.ClickLinkByText("Return to account home");
            return new FinancialAssesmentPage(_context);
        }

    }
}

