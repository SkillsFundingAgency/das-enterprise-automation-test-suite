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

[Binding, Scope(Tag = "aan")]
public class AANHooks
{
    private readonly ScenarioContext _context;
    
    public AANHooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 31)]
    public void Navigate() => _context.Get<TabHelper>().GoToUrl(UrlConfig.AAN_BaseUrl);

    [BeforeScenario(Order = 32)]
    public void SetUpDataHelpers()
    {
        _context.Set(new AANSqlDataHelper(_context.Get<DbConfig>()));

        _context.Set(new AANDataHelpers());
    }

}
