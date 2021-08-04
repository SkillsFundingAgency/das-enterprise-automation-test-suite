using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersHubPage : HubBasePage
    {
        protected override string PageTitle => "INFLUENCERS";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InfluencersHubPage(ScenarioContext context) : base(context) => _context = context;
    }
}
