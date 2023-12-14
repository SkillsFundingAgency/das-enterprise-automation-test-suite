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
public class BeforeScenarioHooks(ScenarioContext context)
{
    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        var objectContext = context.Get<ObjectContext>();

        context.SetRestClient(new Outer_RecruitApiClient(objectContext, context.GetOuter_ApiAuthTokenConfig()));

        context.Set(new EmployerLegalEntitiesSqlDbHelper(objectContext, context.Get<DbConfig>()));
    }
}
