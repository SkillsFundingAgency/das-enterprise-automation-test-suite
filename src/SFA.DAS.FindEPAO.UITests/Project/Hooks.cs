using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;

        public Hooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 21)]
        public void NavigateToFindEPAOHomepage() => _context.Get<TabHelper>().GoToUrl(UrlConfig.FindEPAO_BaseUrl);
    }
}