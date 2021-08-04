using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsStepsHelper
    {
       private readonly ScenarioContext _context;

       public CampaignsStepsHelper(ScenarioContext context) => _context = context;

       public CampaingnsHomePage GoToCampaingnsHomePage() => new CampaingnsHomePage(_context).AcceptCookieAndAlert();

       public ApprenticeHubPage GoToApprenticeshipHubPage() => GoToCampaingnsHomePage().NavigateToApprenticeshipHubPage();

       public EmployerHubPage GoToEmployerHubPage() => GoToCampaingnsHomePage().NavigateToEmployerHubPage();
    }
}
