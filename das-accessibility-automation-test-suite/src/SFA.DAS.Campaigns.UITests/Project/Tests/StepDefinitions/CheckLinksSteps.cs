using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CheckLinksSteps(ScenarioContext context)
    {
        [Then(@"the links are not broken")]
        public void ThenTheLinksAreNotBroken() => new CampaingnsVerifyLinks(context, false).VerifyLinks();

        [Then(@"the video links are not broken")]
        public void ThenTheVideoLinksAreNotBroken() => new CampaingnsVerifyLinks(context, false).VerifyVideoLinks();
    }
}
