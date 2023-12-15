using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        private readonly TabHelper _tabHelper = context.Get<TabHelper>();

        [BeforeScenario(Order = 21)]
        public void Navigate() => _tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_WebBaseUrl);

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => context.Set(new ConsolidateSupportDataHelper());
    }
}