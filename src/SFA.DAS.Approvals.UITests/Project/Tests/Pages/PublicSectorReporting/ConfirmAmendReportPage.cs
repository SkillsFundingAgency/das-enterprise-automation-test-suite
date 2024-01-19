using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class ConfirmAmendReportPage(ScenarioContext context) : PublicSectorReportingBasePage(context)
    {
        protected override string PageTitle => "If you amend this submission, you will have to resubmit ";

        protected override By PageHeader => By.CssSelector(".govuk-grid-column-two-thirds p");

        protected override By ContinueButton => By.CssSelector("#report-confirm-amend");

        public ReportYourProgressPage ConfirmAmend()
        {
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}