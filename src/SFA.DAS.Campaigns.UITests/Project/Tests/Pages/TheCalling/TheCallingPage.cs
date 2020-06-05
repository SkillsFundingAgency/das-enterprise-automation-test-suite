using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.TheCalling
{
    public class TheCallingPage : CampaingnsPage
    {
        protected override string PageTitle => "#THECALLING";

        protected override By PageHeader => By.CssSelector(".thecalling-site-heading");

        public TheCallingPage(ScenarioContext context) : base(context) { }
    }
}
