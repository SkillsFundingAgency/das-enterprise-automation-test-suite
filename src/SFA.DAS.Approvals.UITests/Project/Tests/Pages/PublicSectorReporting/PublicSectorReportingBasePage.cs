using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public abstract class PublicSectorReportingBasePage : ApprovalsBasePage
    {
        protected override By PageHeader => By.CssSelector("#content .heading-large");

        protected By Textarea => By.CssSelector("textarea");

        protected override By ContinueButton => By.CssSelector("button.button[type='submit']");

        protected PublicSectorReportingBasePage(ScenarioContext context, bool verifypage = true) : base(context) { }
    }
}