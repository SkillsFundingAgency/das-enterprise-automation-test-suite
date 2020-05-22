using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourFullTimeEquivalentsPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your full-time equivalents";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public YourFullTimeEquivalentsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterFullTimeEmployeesDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Number of full-time equivalents (optional)", dataHelper.NoofFullTimeEmployees);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}