using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest
{
    public class RegisterMyInterestSuccessPage : CampaingnsPage
    {
        protected override string PageTitle => "SUCCESS";

        protected override By PageHeader => By.CssSelector(".heading-l");

        public RegisterMyInterestSuccessPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
