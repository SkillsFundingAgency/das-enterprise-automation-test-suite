using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class OrgPage : UserOrgPage
    {
        protected override By PageHeader => By.CssSelector("[data-test-id='tabs-nav-item-organizations']");

        protected override string PageTitle => dataHelper.NewOrgName;

        public OrgPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
