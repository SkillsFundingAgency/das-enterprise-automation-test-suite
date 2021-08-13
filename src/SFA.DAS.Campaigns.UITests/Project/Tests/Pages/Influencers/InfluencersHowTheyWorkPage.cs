using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersHowTheyWorkPage : InfluencersBasePage
    {
        protected override string PageTitle => "How they work";

        public InfluencersHowTheyWorkPage(ScenarioContext context) : base(context) { }

        public void VerifyInfluencersHowTheyWorkPageSubHeadings() => VerifyFiuCards(() => NavigateToHowDoTheyWorkPage());
    }
}