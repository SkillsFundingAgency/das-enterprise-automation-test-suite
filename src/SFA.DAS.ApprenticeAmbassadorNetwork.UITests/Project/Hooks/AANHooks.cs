global using OpenQA.Selenium;
global using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using System.Linq;
global using TechTalk.SpecFlow;
using SFA.DAS.TestDataExport.Helper;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

[Binding]
public class AANHooks
{
    private readonly ScenarioContext _context;
    private readonly TabHelper _tabHelper;
    private AANSqlHelper aANSqlHelper;

    public AANHooks(ScenarioContext context)
    {
        _context = context;
        _tabHelper = _context.Get<TabHelper>();
    }

    [BeforeScenario(Order = 31), Scope(Tag = "@aanaprentice")]
    public void Navigate_Apprentice() => _tabHelper.GoToUrl(UrlConfig.AAN_Apprentice_BaseUrl);

    [BeforeScenario(Order = 31), Scope(Tag = "@aanemployer")]
    public void Navigate_Employer()
    {
        var account = "mpbd6m";

        if (_context.ScenarioInfo.Tags.Contains("aanemployeronboardingreset")) account = "n7kry6";

        UrlConfig.AAN_Employer_BaseUrl = $"https://employer-aan.pp-eas.apprenticeships.education.gov.uk/accounts/{account}";

        _tabHelper.GoToUrl(UrlConfig.AAN_Employer_BaseUrl);
    }

    [BeforeScenario(Order = 31), Scope(Tag = "@aanadmin")]
    public void Navigate_Admin() => _tabHelper.GoToUrl(UrlConfig.AAN_Admin_BaseUrl);

    [BeforeScenario(Order = 32)]
    public void SetUpDataHelpers()
    {
        aANSqlHelper = new AANSqlHelper(_context.Get<DbConfig>());

        _context.Set(aANSqlHelper);

        _context.Set(new AANDataHelpers());

        if (_context.ScenarioInfo.Tags.Contains("aanadmincreateevent"))
        {
            _context.Set(new AanAdminDatahelper());
        }
    }

    [AfterScenario(Order = 30), Scope(Tag = "@aanadmin")]
    public void DeleteAdminCreatedEvent() 
    {
        _context.Get<TryCatchExceptionHelper>().AfterScenarioException(() => 
        {
            var eventId = _context.Get<ObjectContext>().GetAanAdminEventId();

            if (_context.ScenarioInfo.Tags.Contains("aanadmincreateevent") && !string.IsNullOrEmpty(eventId))
            {
                aANSqlHelper.DeleteAdminCreatedEvent(eventId);
            }
        });
    }
}
