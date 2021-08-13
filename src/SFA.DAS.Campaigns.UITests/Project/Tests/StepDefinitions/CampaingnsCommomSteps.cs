using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaingnsCommomSteps
    {
        private readonly ScenarioContext _context;

        public CampaingnsCommomSteps(ScenarioContext context) => _context = context;

        [Then(@"the user can search for an apprenticeship")]
        public void ThenTheUserCanSearchForAnApprenticeship() => new BrowseApprenticeshipPage(_context).SearchForAnApprenticeship();

    }
}
