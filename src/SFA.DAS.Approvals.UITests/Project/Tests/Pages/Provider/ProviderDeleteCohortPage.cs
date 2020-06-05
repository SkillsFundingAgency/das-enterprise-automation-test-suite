using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDeleteCohortPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Cohort deleted";

        protected override By PageHeader => By.CssSelector(".green-box-alert");

        public ProviderDeleteCohortPage(ScenarioContext context) : base(context) { }
    }
}
