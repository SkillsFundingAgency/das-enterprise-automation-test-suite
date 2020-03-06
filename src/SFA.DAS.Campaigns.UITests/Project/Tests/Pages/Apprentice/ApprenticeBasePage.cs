using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public abstract class ApprenticeBasePage : ApprenticeHubPage
    {
        protected override By PageHeader => By.CssSelector(".heading-xl");

        protected ApprenticeBasePage(ScenarioContext context) : base(context) { }
    }
}
