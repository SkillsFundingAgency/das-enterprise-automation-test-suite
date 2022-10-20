global using Newtonsoft.Json;
global using Newtonsoft.Json.Linq;
global using NUnit.Framework;
global using RestSharp;
global using SFA.DAS.API.Framework.Configs;
global using SFA.DAS.API.Framework.Helpers;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.TestDataExport;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Net;
global using TechTalk.SpecFlow;

namespace SFA.DAS.API.Framework;

[Binding]
public class ApiFrameworkConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public ApiFrameworkConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

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
        inner_ApiFrameworkConfig.config.EmployerAccountsAppServiceName += _appServiceResourceSuffix;
        inner_ApiFrameworkConfig.config.EmployerAccountsLegacyAppServiceName += _appServiceResourceSuffix;

        _context.Set(inner_ApiFrameworkConfig);

        _context.Set(_configSection.GetConfigSection<Outer_ApiAuthTokenConfig>());

        _context.Set(_configSection.GetConfigSection<ApprenticeCommitmentsJobsAuthTokenConfig>());
    }

    [BeforeScenario(Order = 4)]
    public void SetUpHelpers() => _context.Replace(new RetryAssertHelper(_context.ScenarioInfo));
}