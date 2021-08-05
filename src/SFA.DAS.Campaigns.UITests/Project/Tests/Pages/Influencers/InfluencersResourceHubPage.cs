using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersResourceHubPage : InfluencersBasePage
    {
        protected override string PageTitle => "Resource hub";

        public InfluencersResourceHubPage(ScenarioContext context) : base(context) { }

        public void VerifyInfluencersRequestSupportPageSubHeadings() => VerifyFiuCards(() => NavigateToResourceHubPage());
    }
}