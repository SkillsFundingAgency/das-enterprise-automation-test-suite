using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersApprenticeAmbassadorNetworkPage(ScenarioContext context) : InfluencersBasePage(context)
    {
        protected override string PageTitle => "Apprenticeship ambassador network";

        public void VerifyInfluencersApprenticeAmbassadorNetworkPageSubHeadings() => VerifyFiuCards(() => NavigateToApprenticeAmbassadorNetworkPage());
    }
}