using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersHubPage : InfluencersBasePage
    {
        protected override string PageTitle => "INFLUENCERS";

        protected override By PageHeader => PageHeaderTag;

        public InfluencersHubPage(ScenarioContext context) : base(context) { }

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToInfluencersHubPage());
    }
}
