using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class ConfirmAmendReportPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "If you amend this submission, you will have to resubmit ";

        protected override By PageHeader => By.CssSelector("#content p");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#report-confirm-amend");

        public ConfirmAmendReportPage(ScenarioContext context) : base(context) => _context = context;

        public ReportYourProgressPage ConfirmAmend()
        {
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}