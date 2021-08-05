using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public abstract class InfluencersBasePage : InfluencersHubPage
    {
        protected override By PageHeader => SubPageHeader;

        protected InfluencersBasePage(ScenarioContext context) : base(context) { }
    }
}