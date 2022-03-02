using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly TabHelper _tabHelper;

        public Hooks(ScenarioContext context) => _tabHelper = context.Get<TabHelper>();

        [BeforeScenario(Order = 21)]
        public void NavigateToFATHomepage() => _tabHelper.GoToUrl(UrlConfig.FATV2_BaseUrl);
    }
}
