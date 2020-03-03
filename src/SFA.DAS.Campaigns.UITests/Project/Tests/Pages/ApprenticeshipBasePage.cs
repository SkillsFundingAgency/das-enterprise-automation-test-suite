using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class ApprenticeshipBasePage : ApprenticeshipHubPage
    {
        protected override By PageHeader => By.CssSelector(".heading-xl");

        protected By Heading1 => By.CssSelector("#h1");
        protected By Heading2 => By.CssSelector("#h2");
        protected By Heading3 => By.CssSelector("#h3");

        public ApprenticeshipBasePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
