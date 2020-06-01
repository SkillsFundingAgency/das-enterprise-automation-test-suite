using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class SubmittedReportspage : PublicSectorReportingBasePage
    {
        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        protected override string PageTitle => "Submitted reports";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SubmittedReportspage(ScenarioContext context) : base(context) => _context = context;

        public SubmittedDetailsPage ViewReport()
        {
            tableRowHelper.SelectRowFromTable("View", registrationConfig.RE_OrganisationName);
            return new SubmittedDetailsPage(_context);
        }
    }
}