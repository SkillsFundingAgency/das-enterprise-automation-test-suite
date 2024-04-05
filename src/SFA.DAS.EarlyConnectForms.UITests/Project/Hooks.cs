using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 21)]
        public void FirstBeforeScenario()
        {
            context.Set(new EarlyConnectDataHelper());

            context.Get<TabHelper>().GoToUrl(UrlConfig.EarlyConnect_BaseUrl());
            
        }
    }
}