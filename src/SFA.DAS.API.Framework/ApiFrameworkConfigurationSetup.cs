global using Newtonsoft.Json;
global using RestSharp;
global using SFA.DAS.API.Framework.Configs;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using System;
global using System.Collections.Generic;
global using System.Net;
global using TechTalk.SpecFlow;

namespace SFA.DAS.API.Framework;

[Binding]
public class ApiFrameworkConfigurationSetup(ScenarioContext context)
{
    private readonly ConfigSection _configSection = context.Get<ConfigSection>();

    [BeforeScenario(Order = 2)]
    public void SetUpApiFrameworkConfiguration()
    {
        string _appServiceResourceSuffix = "-ar";

        var inner_ApiFrameworkConfig = new Inner_ApiFrameworkConfig(_configSection.GetConfigSection<Inner_ApiAuthTokenConfig>())
        {
            IsVstsExecution = Configurator.IsVstsExecution,
        };

        inner_ApiFrameworkConfig.config.ApprenticeAccountsAppServiceName += _appServiceResourceSuffix;
        inner_ApiFrameworkConfig.config.CoursesAppServiceName += _appServiceResourceSuffix;
        inner_ApiFrameworkConfig.config.CommitmentsAppServiceName += _appServiceResourceSuffix;
        inner_ApiFrameworkConfig.config.EmployerFinanceAppServiceName += _appServiceResourceSuffix;
        inner_ApiFrameworkConfig.config.EmployerAccountsAppServiceName += _appServiceResourceSuffix;
        inner_ApiFrameworkConfig.config.EmployerAccountsLegacyAppServiceName += _appServiceResourceSuffix;

        context.Set(inner_ApiFrameworkConfig);

        context.Set(_configSection.GetConfigSection<Outer_ApiAuthTokenConfig>());

        context.Set(_configSection.GetConfigSection<ApprenticeCommitmentsJobsAuthTokenConfig>());
    }

    [BeforeScenario(Order = 4)]
    public void SetUpHelpers() => context.Replace(new RetryAssertHelper(context.ScenarioInfo, context.Get<ObjectContext>()));
}