using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class DashboardPage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector("#main_navigation");

        public DashboardPage(ScenarioContext context) : base(context)
        {
            VerifyPage(PageHeader);
        }

        protected override string PageTitle { get; }
    }
}
