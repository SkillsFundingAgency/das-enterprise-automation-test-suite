using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 21)]
        public void NavigateToFATHomepage() => context.Get<TabHelper>().GoToUrl(UrlConfig.FAT_BaseUrl);
    }
}
