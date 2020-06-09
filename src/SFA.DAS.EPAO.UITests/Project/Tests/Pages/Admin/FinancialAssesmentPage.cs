using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class FinancialAssesmentPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "New assessments";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FinancialAssesmentPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FinancialHealthEvaluationPage GoToNewApplicationOverviewPage()
        {
            formCompletionHelper.ClickLinkByText(ApplyOrganisationName);
            return new FinancialHealthEvaluationPage(_context);
        }

        public new StaffDashboardPage ReturnToDashboard() => base.ReturnToDashboard();
    }
}