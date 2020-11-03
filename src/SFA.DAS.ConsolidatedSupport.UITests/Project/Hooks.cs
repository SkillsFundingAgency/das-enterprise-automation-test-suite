using SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate() => _tabHelper.GoToUrl(UrlConfig.ConsolidatedSupport_BaseUrl, "/agent");

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => _context.Set(new ConsolidateSupportDataHelper());
    }
}