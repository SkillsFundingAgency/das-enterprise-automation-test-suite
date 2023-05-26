using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class SubmittedReportspage : PublicSectorReportingBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override string PageTitle => "Submitted reports";

        public SubmittedReportspage(ScenarioContext context) : base(context) { }

        public SubmittedDetailsPage ViewReport()
        {
            tableRowHelper.SelectRowFromTable("View", registrationDataHelper.CompanyTypeOrg);
            return new SubmittedDetailsPage(context);
        }
    }
}