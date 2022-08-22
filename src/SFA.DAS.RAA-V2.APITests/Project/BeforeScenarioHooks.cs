global using NUnit.Framework;
global using RestSharp;
global using SFA.DAS.API.Framework;
global using SFA.DAS.API.Framework.Configs;
global using SFA.DAS.API.Framework.RestClients;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.RAA_V2.APITests.Project.Helpers.SqlDbHelpers;
global using System.Net;
global using TechTalk.SpecFlow;
global using SFA.DAS.FrameworkHelpers;
global using System.Collections.Generic;

namespace SFA.DAS.RAA_V2.APITests.Project;

[Binding]
public class BeforeScenarioHooks
{
    private readonly ScenarioContext _context;

    public BeforeScenarioHooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        _context.SetRestClient(new Outer_EmployerAccountLegalEntitiesApiClient(_context.Get<ObjectContext>(), _context.GetOuter_ApiAuthTokenConfig()));

        _context.Set(new EmployerLegalEntitiesSqlDbHelper(_context.Get<DbConfig>()));
    }
}
