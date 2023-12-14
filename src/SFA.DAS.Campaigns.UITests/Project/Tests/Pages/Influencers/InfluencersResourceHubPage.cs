using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersResourceHubPage(ScenarioContext context) : InfluencersBasePage(context)
    {
        protected override string PageTitle => "Resource hub";

        public InfluencersResourceHubPage VerifySubHeadings() => VerifyFiuCards(() => NavigateToResourceHubPage());
    }
}