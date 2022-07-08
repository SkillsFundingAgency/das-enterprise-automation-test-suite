global using RestSharp;
global using SFA.DAS.API.Framework.Configs;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using System;
global using System.Net;
global using TechTalk.SpecFlow;
global using SFA.DAS.API.Framework.Helpers;
global using Newtonsoft.Json;
global using System.Collections.Generic;
global using Newtonsoft.Json.Linq;
global using NUnit.Framework;
global using System.Linq;

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
        _context.Set(_configSection.GetConfigSection<Outer_ApiAuthTokenConfig>());

        _context.Set(_configSection.GetConfigSection<ApprenticeCommitmentsJobsAuthTokenConfig>());

        _context.Set(_configSection.GetConfigSection<Inner_CommitmentsApiAuthTokenConfig>());

        _context.Set(_configSection.GetConfigSection<Inner_CoursesApiAuthTokenConfig>());
    }

    [BeforeScenario(Order = 4)]
    public void SetUpHelpers() => _context.Replace(new RetryAssertHelper(_context.ScenarioInfo));
}