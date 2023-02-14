global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
global using SFA.DAS.UI.Framework.TestSupport;
global using TechTalk.SpecFlow;
global using SFA.DAS.EsfaAdmin.Service.Project.Helpers;
global using SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

namespace SFA.DAS.EsfaAdmin.Service.Project;

[Binding]
public class EsfaAdminConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public EsfaAdminConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpRoatpConfigConfiguration() => _context.SetEsfaAdminConfig(_configSection.GetConfigSection<EsfaAdminConfig>());
}
