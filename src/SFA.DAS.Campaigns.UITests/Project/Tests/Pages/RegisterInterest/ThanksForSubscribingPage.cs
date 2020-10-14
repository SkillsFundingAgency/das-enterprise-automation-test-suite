using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest
{
    public class ThanksForSubscribingPage : CampaingnsPage
    {
        protected override string PageTitle => "Thank you for signing up";

        public ThanksForSubscribingPage(ScenarioContext context) : base(context) { }
    }
}
