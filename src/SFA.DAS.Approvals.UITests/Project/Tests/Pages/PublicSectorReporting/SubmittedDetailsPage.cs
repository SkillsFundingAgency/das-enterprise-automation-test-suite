using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class SubmittedDetailsPage : PublicSectorReportingBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override string PageTitle => "Submitted details";

        protected override By ContinueButton => By.CssSelector("#report-summary-amend");

        public SubmittedDetailsPage(ScenarioContext context) : base(context)  { }

        public ConfirmAmendReportPage AmendReport()
        {
            Continue();
            return new ConfirmAmendReportPage(context);
        }
    }
}