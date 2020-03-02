using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class TheCallingPage : CampaingnsBasePage
    {
        protected override string PageTitle => "#THECALLING";

        protected override By PageHeader => By.CssSelector(".thecalling-site-heading");

        public TheCallingPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
