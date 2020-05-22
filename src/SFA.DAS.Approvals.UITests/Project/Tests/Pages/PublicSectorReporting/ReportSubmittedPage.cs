using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReportSubmittedPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Report submitted";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        public ReportSubmittedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}