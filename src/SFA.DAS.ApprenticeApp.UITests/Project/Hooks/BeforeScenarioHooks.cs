using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Hooks
{
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 40)]
        public void AppSetupHelpers()
        {
            var configSection = context.Get<ConfigSection>();
            context.SetAppSupportUserConfig(configSection.GetConfigSection<AppSupportUserConfig>());
            //context.SetAppSupportUser(configSection.GetConfigSection<AppSupportUser>());
        }
    }

    public class AppSupportUserConfig
    {
        public string AppSupportUserEmail { get; set; }
        public string AppSupportUserStubId { get; set; }
    }
}
