global using NUnit.Framework;
global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.Login.Service;
global using SFA.DAS.Login.Service.Project.Helpers;
global using SFA.DAS.SupportConsole.UITests.Project.Helpers;
global using SFA.DAS.SupportConsole.UITests.Project.Models;
global using SFA.DAS.SupportConsole.UITests.Project.Helpers.SqlHelpers;
global using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using System;
global using System.Collections.Generic;
global using TechTalk.SpecFlow;
global using TechTalk.SpecFlow.Assist;
global using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
global using System.Linq;
global using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.SupportConsole.UITests.Project;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;
    private readonly string[] _tags;

    public Hooks(ScenarioContext context)
    {
        _context = context;
        _tags = _context.ScenarioInfo.Tags;
    }
    

    [BeforeScenario(Order = 21)]
    public void Navigate() => _context.Get<TabHelper>().GoToUrl(UrlConfig.SupportConsole_BaseUrl);

    [BeforeScenario(Order = 22)]
    public void SetUpHelpers()
    {
        var config = _context.GetSupportConsoleConfig<SupportConsoleConfig>();

        var accsqlHelper = new AccountsSqlDataHelper(_context.Get<DbConfig>());

        var comtsqlHelper = new CommitmentsSqlDataHelper(_context.Get<DbConfig>());

        var updatedConfig = new SupportConsoleSqlDataHelper(accsqlHelper, comtsqlHelper).GetUpdatedConfig(config);

        switch (true)
        {
            case bool _ when _tags.Contains("pendingchanges"):
                {
                    var ls = comtsqlHelper.GetApprenticeshipWithPendingChanges(updatedConfig.HashedAccountId);
                    updatedConfig.CohortRef = ls[0];
                    updatedConfig.Uln = ls[1];
                    break;
                } 
            case bool _ when _tags.Contains("changeofprovider"):
                {
                    var ls = comtsqlHelper.GetApprenticeshipWithTrainingProviderHistory(updatedConfig.HashedAccountId);
                    updatedConfig.CohortRef = ls[0];
                    updatedConfig.Uln = ls[1];
                    break;
                    
                } 
            default: break;
        };
        

        _context.ReplaceSupportConsoleConfig(updatedConfig);

        _context.Get<ObjectContext>().Set("SupportConsoleConfig", updatedConfig);

        _context.Set(accsqlHelper);

        _context.Set(comtsqlHelper);
    }
}