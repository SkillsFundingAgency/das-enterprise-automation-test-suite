global using OpenQA.Selenium;
global using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using System.Linq;
global using TechTalk.SpecFlow;
global using SFA.DAS.TestDataExport.Helper;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

[Binding]
public class AANHooks(ScenarioContext context) : AANBaseHooks(context)
{
    [BeforeScenario(Order = 32)]
    public void SetUpDataHelpers()
    {
        context.Set(new AANSqlHelper(context.Get<ObjectContext>(), context.Get<DbConfig>()));

        context.Set(new AANDataHelpers());
    }
}
