using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Hooks
{
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario]
        public void AppSetupHelpers()
        {
            var configSection = context.Get<ConfigSection>();
            context.SetAppSupportUserConfig(configSection.GetConfigSection<AppSupportUserConfig>());
            context.Get<TabHelper>().GoToUrl(UrlConfig.ApprenticeApp_BaseUrl);
            //context.SetAppSupportUser(configSection.GetConfigSection<AppSupportUser>());
        }
    }

    public class AppSupportUserConfig
    {
        public string AppSupportUserEmail { get; set; }
        public string AppSupportUserStubId { get; set; }
    }
}
