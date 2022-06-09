global using System;
global using System.Collections.Generic;
global using OpenQA.Selenium;
global using TechTalk.SpecFlow;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
global using SFA.DAS.FAT_V2.UITests.Project.Helpers;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;
global using SFA.DAS.Mailinator.Service.Project.Helpers;
global using SFA.DAS.ProviderLogin.Service.Helpers;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;
global using SFA.DAS.ProviderLogin.Service.Project.Helpers;
global using SFA.DAS.ProviderLogin.Service.Pages;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.ProviderLogin.Service;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 21)]
    public void SetUpHelpers() => _context.Set(new AedDataHelper());
}
