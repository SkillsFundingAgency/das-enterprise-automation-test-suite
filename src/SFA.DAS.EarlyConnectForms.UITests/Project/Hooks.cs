using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
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
            var datahelper = new EarlyConnectDataHelper(context.Get<MailosaurUser>());
            context.Set(datahelper);
            context.Get<ObjectContext>().SetDebugInformation($"'{datahelper.Email}' is used");
            context.Get<TabHelper>().GoToUrl(UrlConfig.EarlyConnect_BaseUrl());
        }

    }
}