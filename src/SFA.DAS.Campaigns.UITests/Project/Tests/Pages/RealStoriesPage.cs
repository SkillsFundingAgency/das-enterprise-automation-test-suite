using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class RealStoriesPage : CampaingnsBasePage
    {
        protected override string PageTitle => "REAL STORIES";

        public RealStoriesPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

    }
}
