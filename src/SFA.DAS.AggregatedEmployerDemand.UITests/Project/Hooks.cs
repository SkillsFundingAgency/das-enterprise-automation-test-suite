global using System;
global using System.Collections.Generic;
global using OpenQA.Selenium;
global using TechTalk.SpecFlow;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
global using SFA.DAS.FAT_V2.UITests.Project.Helpers;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;
global using SFA.DAS.ProviderLogin.Service.Helpers;
global using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;
global using SFA.DAS.ProviderLogin.Service.Project.Helpers;
global using SFA.DAS.ProviderLogin.Service.Pages;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.MailinatorAPI.Service.Project.Helpers;
using SFA.DAS.TestDataExport;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 21)]
    public void SetUpHelpers()
    {
        var emailDomain = _context.Get<MailinatorApiHelper>().GetDomain();

        var datahelper = new AedDataHelper(emailDomain);

        _context.Set(datahelper);

        _context.Get<ObjectContext>().SetDebugInformation($"'{datahelper.Email}' is used");
    }
}
