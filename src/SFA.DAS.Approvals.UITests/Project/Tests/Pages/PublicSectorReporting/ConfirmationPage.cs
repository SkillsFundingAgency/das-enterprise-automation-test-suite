using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class ConfirmationPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Have you checked everything is correct?";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        protected override By ContinueButton => By.CssSelector("#report-confirm-submit");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmationPage(ScenarioContext context) : base(context) => _context = context;

        public ReportSubmittedPage Confirm()
        {
            Continue();
            return new ReportSubmittedPage(_context);
        }
    }
}