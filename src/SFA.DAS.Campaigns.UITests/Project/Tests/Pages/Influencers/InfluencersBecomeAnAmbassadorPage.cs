using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersBecomeAnAmbassadorPage : InfluencersBasePage
    {
        protected override string PageTitle => "Become an ambassador";

        public InfluencersBecomeAnAmbassadorPage(ScenarioContext context) : base(context) { }

        public void VerifyInfluencersBecomeAnAmbassadorPageSubHeadings() => VerifyFiuCards(() => NavigateToBecomeAnAmbassadorPage());
    }
}