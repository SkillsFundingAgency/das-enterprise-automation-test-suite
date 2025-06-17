using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class PublicSectorReportingHomePage(ScenarioContext context, bool navigate = false) : InterimPublicSectorReportingHomePage(context, navigate)
    {
        protected override By RadioLabels => By.CssSelector("label");

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        public PublicSectorTargetDatePage CreateNewReport()
        {
            SelectRadioOptionByText("Create a new report");
            Continue();
            return new PublicSectorTargetDatePage(context);
        }

        public SubmittedReportspage ViewSubmittedReport()
        {
            SelectRadioOptionByText("View a submitted report");
            Continue();
            return new SubmittedReportspage(context);
        }
    }
}