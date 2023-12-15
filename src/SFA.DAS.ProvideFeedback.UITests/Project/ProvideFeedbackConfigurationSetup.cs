global using OpenQA.Selenium;
global using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
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
global using System.Collections.Generic;
global using System.Linq;
global using TechTalk.SpecFlow;

namespace SFA.DAS.ProvideFeedback.UITests.Project;

[Binding]
public class ProvideFeedbackConfigurationSetup(ScenarioContext context)
{
    private readonly ConfigSection _configSection = context.Get<ConfigSection>();

    [BeforeScenario(Order = 2)]
    public void SetUpProvideFeedbackConfigConfiguration()
    {
        context.SetEasLoginUser(
        [
            _configSection.GetConfigSection<EmployerFeedbackUser>()
        ]);

        context.SetNonEasLoginUser(_configSection.GetConfigSection<ApprenticeFeedbackUser>());
    }
}
