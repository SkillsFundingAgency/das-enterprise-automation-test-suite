using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersApprenticeAmbassadorNetworkPage : InfluencersBasePage
    {
        protected override string PageTitle => "Apprenticeship ambassador network";

        public InfluencersApprenticeAmbassadorNetworkPage(ScenarioContext context) : base(context) { }

        public void VerifyInfluencersApprenticeAmbassadorNetworkPageSubHeadings() => VerifyFiuCards(() => NavigateToApprenticeAmbassadorNetworkPage());
    }
}