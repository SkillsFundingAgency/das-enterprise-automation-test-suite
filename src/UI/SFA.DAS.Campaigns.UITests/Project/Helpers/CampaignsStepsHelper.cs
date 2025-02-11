using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsStepsHelper(ScenarioContext context)
    {
        public CampaingnsHomePage GoToCampaingnsHomePage() => new CampaingnsHomePage(context).AcceptCookieAndAlert();

        public ApprenticeHubPage GoToApprenticeshipHubPage() => GoToCampaingnsHomePage().NavigateToApprenticeshipHubPage();

        public EmployerHubPage GoToEmployerHubPage() => GoToCampaingnsHomePage().NavigateToEmployerHubPage();

        public InfluencersHubPage GoToInfluencersHubPage() => GoToCampaingnsHomePage().NavigateToInfluencersHubPage();
    }
}
