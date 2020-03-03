using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ThanksForSubscribingPage : CampaingnsBasePage
    {
        protected override string PageTitle => "THANKS FOR SUBSCRIBING!";

        protected override By PageHeader => By.CssSelector(".heading-xl");

        private By NameDetails => By.CssSelector(".heading-emphasise");

        public ThanksForSubscribingPage(ScenarioContext context) : base(context) => VerifyPage();

        public void VerifyDetail() => pageInteractionHelper.VerifyText(NameDetails, $"{campaignsDataHelper.FullName.ToUpper()}");
    }
}
