using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class ReportSubmittedPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Report submitted";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public ReportSubmittedPage(ScenarioContext context) : base(context) { }
    }
}