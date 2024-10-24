using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

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
            configSection.GetConfigSection<EPRAddRequestUser>()
        ]);
    }
}
