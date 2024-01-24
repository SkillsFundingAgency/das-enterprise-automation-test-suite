using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersHowTheyWorkPage(ScenarioContext context) : InfluencersBasePage(context)
    {
        protected override string PageTitle => "How they work";

        public void VerifyInfluencersHowTheyWorkPageSubHeadings() => VerifyFiuCards(() => NavigateToHowDoTheyWorkPage());
    }
}