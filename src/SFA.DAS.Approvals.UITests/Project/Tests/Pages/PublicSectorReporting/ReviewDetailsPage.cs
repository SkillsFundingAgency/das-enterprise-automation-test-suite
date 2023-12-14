using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class ReviewDetailsPage(ScenarioContext context) : PublicSectorReportingBasePage(context)
    {
        protected override string PageTitle => "Review details";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override By ContinueButton => By.CssSelector("#report-summary-continue");

        public ConfirmationPage GoToConfirmationPage()
        {
            Continue();
            return new ConfirmationPage(context);
        }
    }
}