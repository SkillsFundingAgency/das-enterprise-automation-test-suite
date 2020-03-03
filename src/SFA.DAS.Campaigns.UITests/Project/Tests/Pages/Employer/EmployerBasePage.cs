using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public abstract class EmployerBasePage : EmployerHubPage
    {
        protected override By PageHeader => By.CssSelector(".heading-xl");

        public EmployerBasePage(ScenarioContext context) : base(context) { }
    }
}
