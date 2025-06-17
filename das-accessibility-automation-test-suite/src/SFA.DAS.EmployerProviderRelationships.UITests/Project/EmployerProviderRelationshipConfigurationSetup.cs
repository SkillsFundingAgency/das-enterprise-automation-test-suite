global using NUnit.Framework;
global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;
global using SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.Login.Service.Project;
global using SFA.DAS.Login.Service.Project.Helpers;
global using SFA.DAS.ProviderLogin.Service.Project;
global using SFA.DAS.ProviderLogin.Service.Project.Helpers;
global using SFA.DAS.Registration.UITests.Project;
global using SFA.DAS.Registration.UITests.Project.Helpers;
global using SFA.DAS.Registration.UITests.Project.Tests.Pages;
global using SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;
global using SFA.DAS.TestDataExport.Helper;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using System.Linq;
global using TechTalk.SpecFlow;
global using SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Employer;
global using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
global using System.Collections.Generic;


namespace SFA.DAS.EmployerProviderRelationships.UITests.Project;

[Binding]
public class EmployerProviderRelationshipConfigurationSetup(ScenarioContext context)
{
    [BeforeScenario(Order = 2)]
    public void SetUpEmployerProviderRelationshipConfiguration()
    {
        var configSection = context.Get<ConfigSection>();

        context.SetEasLoginUser(
        [
            configSection.GetConfigSection<EPRLevyUser>(),
            configSection.GetConfigSection<EPRNonLevyUser>(),
            configSection.GetConfigSection<EPRAcceptRequestUser>(),
            configSection.GetConfigSection<EPRDeclineRequestUser>(),
            configSection.GetConfigSection<EPRMultiAccountUser>(),
            configSection.GetConfigSection<EPRMultiOrgUser>()
        ]);
    }
}
