using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 21)]
        public void NavigateToFindEPAOHomepage() => context.Get<TabHelper>().GoToUrl(UrlConfig.FindEPAO_BaseUrl);
    }
}