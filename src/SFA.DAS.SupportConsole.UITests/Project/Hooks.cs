global using NUnit.Framework;
global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
global using SFA.DAS.Login.Service;
global using SFA.DAS.Login.Service.Project.Helpers;
global using SFA.DAS.SupportConsole.UITests.Project.Helpers;
global using SFA.DAS.SupportConsole.UITests.Project.Helpers.SqlHelpers;
global using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using TechTalk.SpecFlow;
using Polly;

namespace SFA.DAS.SupportConsole.UITests.Project;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 22)]
    public void Navigate() => _context.Get<TabHelper>().GoToUrl(UrlConfig.SupportConsole_BaseUrl);

    [BeforeScenario(Order = 23)]
    public void SetUpHelpers()
    {
        var config = _context.GetSupportConsoleConfig<SupportConsoleConfig>();

        var objectContext = _context.Get<ObjectContext>();

        var dbConfig = _context.Get<DbConfig>();

        var accsqlHelper = new AccountsSqlDataHelper(objectContext, dbConfig);

        var comtsqlHelper = new CommitmentsSqlDataHelper(objectContext, dbConfig);

        var updatedConfig = new SupportConsoleSqlDataHelper(accsqlHelper, comtsqlHelper).GetUpdatedConfig(config);

        _context.ReplaceSupportConsoleConfig(updatedConfig);

        _context.Get<ObjectContext>().Set("SupportConsoleConfig", updatedConfig);

        _context.Set(accsqlHelper);

        _context.Set(comtsqlHelper);
    }
}