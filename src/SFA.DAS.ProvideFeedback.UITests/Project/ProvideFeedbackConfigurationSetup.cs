global using OpenQA.Selenium;
global using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.Login.Service.Project.Helpers;
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
using SFA.DAS.Login.Service.Project;

namespace SFA.DAS.ProvideFeedback.UITests.Project;

[Binding]
public class ProvideFeedbackConfigurationSetup(ScenarioContext context)
{
    [BeforeScenario(Order = 2)]
    public void SetUpProvideFeedbackConfigConfiguration()
    {
        var configSection = context.Get<ConfigSection>();

        context.SetEasLoginUser(
        [
            configSection.GetConfigSection<EmployerFeedbackUser>()
        ]);

        context.SetApprenticeAccountsPortalUser(
        [
           configSection.GetConfigSection<ApprenticeFeedbackUser>(),
        ]);
    }
}
