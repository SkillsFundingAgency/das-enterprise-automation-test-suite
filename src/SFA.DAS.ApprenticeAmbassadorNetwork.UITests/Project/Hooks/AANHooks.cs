global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using TechTalk.SpecFlow;
global using System.Linq;
global using SFA.DAS.UI.Framework;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

[Binding]
public class AANHooks
{
    private readonly ScenarioContext _context;
    
    public AANHooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 31), Scope(Tag = "@aanaprentice")]
    public void Navigate_Apprentice() => _context.Get<TabHelper>().GoToUrl(UrlConfig.AAN_Apprentice_BaseUrl);

    [BeforeScenario(Order = 32)]
    public void SetUpDataHelpers()
    {
        _context.Set(new AANSqlDataHelper(_context.Get<DbConfig>()));

        _context.Set(new AANDataHelpers());
    }

}
