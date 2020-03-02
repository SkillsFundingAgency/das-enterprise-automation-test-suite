using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class RegisterMyInterestSuccessPage : CampaingnsBasePage
    {
        protected override string PageTitle => "SUCCESS";

        protected override By PageHeader => By.CssSelector(".heading-l");

        public RegisterMyInterestSuccessPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
