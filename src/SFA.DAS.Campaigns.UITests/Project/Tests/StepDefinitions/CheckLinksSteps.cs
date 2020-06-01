using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CheckLinksSteps
    {
        private readonly ScenarioContext _context;

        public CheckLinksSteps(ScenarioContext context) => _context = context;

        [Then(@"the links are not broken")]
        public void ThenTheLinksAreNotBroken() => new CampaingnsPage(_context, false).VerifyLinks();

        [Then(@"the video links are not broken")]
        public void ThenTheVideoLinksAreNotBroken() => new CampaingnsPage(_context, false).VerifyVideoLinks();
    }
}
