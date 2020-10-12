using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly TabHelper tabHelper;

        public Hooks(ScenarioContext context) => tabHelper = context.Get<TabHelper>();

        [BeforeScenario(Order = 21)]
        public void Navigate() => tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_BaseUrl, "/agent");
    }
}