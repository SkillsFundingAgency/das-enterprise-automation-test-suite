using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class ConfirmationPage(ScenarioContext context) : PublicSectorReportingBasePage(context)
    {
        protected override string PageTitle => "Have you checked everything is correct?";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override By ContinueButton => By.CssSelector("#report-confirm-submit");

        public ReportSubmittedPage Confirm()
        {
            Continue();
            return new ReportSubmittedPage(context);
        }
    }
}