using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersRequestSupportPage : InfluencersBasePage
    {
        protected override string PageTitle => "Request support";

        public InfluencersRequestSupportPage(ScenarioContext context) : base(context) { }

        public void VerifyInfluencersRequestSupportPageSubHeadings() => VerifyFiuCards(() => NavigateToRequestSupportPage());
    }
}