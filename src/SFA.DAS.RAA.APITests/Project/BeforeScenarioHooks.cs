global using NUnit.Framework;
global using RestSharp;
global using SFA.DAS.API.Framework;
global using SFA.DAS.API.Framework.Configs;
global using SFA.DAS.API.Framework.RestClients;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.RAA.APITests.Project.Helpers.SqlDbHelpers;
global using System.Collections.Generic;
global using System.Net;
global using TechTalk.SpecFlow;
using System;

namespace SFA.DAS.RAA.APITests.Project;

[Binding]
public class BeforeScenarioHooks(ScenarioContext context)
{
    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        var objectContext = context.Get<ObjectContext>();
        var apiAuthTokenConfig = context.Get<Outer_ApiAuthTokenConfig>();
        string apiBaseUrl;

        if (context.ScenarioInfo.Title.Contains("RAA_API_01_OuterApiGetEmployerAccountLegalEntities_"))
        {
            apiBaseUrl = UrlConfig.OuterApiUrlConfig.Outer_ApiBaseUrl;
        }
        else if (context.ScenarioInfo.Title.Contains("RAA_API_02_Createvacancy"))
        {
            apiBaseUrl = UrlConfig.OuterApiUrlConfig.Outer_RAAApiBaseUrl;
        }
        else
        {
            throw new InvalidOperationException("Unknown scenario title");
        }

        context.SetRestClient(new Outer_RecruitApiClient(objectContext, apiAuthTokenConfig, apiBaseUrl));
        context.Set(new EmployerLegalEntitiesSqlDbHelper(objectContext, context.Get<DbConfig>()));
    }
}
