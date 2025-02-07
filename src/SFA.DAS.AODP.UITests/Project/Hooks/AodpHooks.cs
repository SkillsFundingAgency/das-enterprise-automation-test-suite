using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Hooks
{
    [Binding]
    public class AodpHooks(ScenarioContext context)
    {
        private readonly TabHelper _tabHelper = context.Get<TabHelper>();
        [BeforeScenario]
        public void Navigate() => _tabHelper.GoToUrl(UrlConfig.AAN_Admin_BaseUrl);
    }






}