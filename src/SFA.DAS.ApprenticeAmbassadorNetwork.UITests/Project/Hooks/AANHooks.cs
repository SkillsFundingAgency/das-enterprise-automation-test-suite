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
    private readonly TabHelper _tabHelper;

    public AANHooks(ScenarioContext context)
    {
        _context = context;
        _tabHelper = _context.Get<TabHelper>();
    }

    [BeforeScenario(Order = 31), Scope(Tag = "@aanaprentice")]
    public void Navigate_Apprentice() => _tabHelper.GoToUrl(UrlConfig.AAN_Apprentice_BaseUrl);

    [BeforeScenario(Order = 31), Scope(Tag = "@aanemployer")]
    public void Navigate_Employer() => _tabHelper.GoToUrl("https://employer-aan.test-eas.apprenticeships.education.gov.uk/accounts/ddff");

    [BeforeScenario(Order = 31), Scope(Tag = "@aanadmin")]
    public void Navigate_Admin() => _tabHelper.GoToUrl("https://test-adminaan.apprenticeships.education.gov.uk/");

    [BeforeScenario(Order = 32)]
    public void SetUpDataHelpers()
    {
        _context.Set(new AANSqlDataHelper(_context.Get<DbConfig>()));

        _context.Set(new AANDataHelpers());
    }

}
