global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.Login.Service;
global using SFA.DAS.Login.Service.Project.Helpers;
global using SFA.DAS.ProvideFeedback.UITests.Project;
global using SFA.DAS.ProvideFeedback.UITests.Project.Helpers;
global using SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;
global using SFA.DAS.Registration.UITests.Project.Helpers;
global using SFA.DAS.TestDataExport.Helper;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using TechTalk.SpecFlow;

namespace SFA.DAS.ProvideFeedback.UITests.Project;

[Binding]
public class ProvideFeedbackConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public ProvideFeedbackConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpProvideFeedbackConfigConfiguration()
    {
        _context.SetProvideFeedbackConfig(_configSection.GetConfigSection<ProvideFeedbackConfigurationSetup>());

        _context.SetEasLoginUser(new List<EasAccountUser>()
        {
            _configSection.GetConfigSection<ProvideFeedbackUser>()
        });
    }
}
