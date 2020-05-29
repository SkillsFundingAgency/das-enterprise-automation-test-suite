using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class SubmittedDetailsPage : PublicSectorReportingBasePage
    {
        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        protected override string PageTitle => "Submitted details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#report-summary-amend");

        public SubmittedDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public ConfirmAmendReportPage AmendReport()
        {
            Continue();
            return new ConfirmAmendReportPage(_context);
        }
    }
}