using Newtonsoft.Json;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project;

[Binding]
public class DfeProviderConfigurationSetup(ScenarioContext context)
{
    private const string DfeProvidersConfig = "DfeProvidersConfig";

    [BeforeScenario(Order = 1)]
    public void SetUpDfeProviderConfiguration()
    {
        var configSection = context.Get<ConfigSection>();

        var dfeProviderList = configSection.GetConfigSection<List<DfeProviderUsers>>(DfeProvidersConfig);

        if (Configurator.IsVstsExecution)
        {
            var dfeProviderList1 = configSection.GetConfigSection<string>(DfeProvidersConfig);

            dfeProviderList = JsonConvert.DeserializeObject<List<DfeProviderUsers>>(dfeProviderList1);
        }

        var dfeframeworkList = new FrameworkList<DfeProviderUsers>();

        dfeframeworkList.AddRange(dfeProviderList);

        context.Set(dfeframeworkList);
    }
}
