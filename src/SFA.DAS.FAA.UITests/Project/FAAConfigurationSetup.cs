using Newtonsoft.Json;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.RAA.DataGenerator.Project.Config;

namespace SFA.DAS.FAA.UITests.Project;

[Binding]
public class FAAConfigurationSetup(ScenarioContext context)
{
    private const string FAAApplyUsersConfig = "FAAApplyUsersConfig";
    private const string FAAConfigKey = "FAAConfig";

    [BeforeScenario(Order = 2)]
    public void SetUpFAAConfiguration()
    {
        var listOfFAAApplyUsers = new MultiConfigurationSetupHelper(context).SetMultiConfiguration<FAAApplyUsers>(FAAApplyUsersConfig);

        var fAAApplyUsers = RandomDataGenerator.GetRandomElementFromListOfElements(listOfFAAApplyUsers);

        var selectedUser = RandomDataGenerator.GetRandomElementFromListOfElements(fAAApplyUsers.ListofUser);

        var faaApplyUser = new FAAApplyUser { Username = $"{selectedUser}@{fAAApplyUsers.Domain}" };

        context.SetFAAPortaluser([faaApplyUser]);

        var faaUser = context.GetUser<FAAApplyUser>();

        var configSection = context.Get<ConfigSection>();

        FAAConfig faaConfig;

        if (Configurator.IsAdoExecution)
        {
            var rawJson = configSection.GetConfigSection<string>(FAAConfigKey);
            faaConfig = JsonConvert.DeserializeObject<FAAConfig>(rawJson);
        }
        else
        {
            faaConfig = configSection.GetConfigSection<FAAConfig>(FAAConfigKey);
        }

        context.Set<FAAConfig>(faaConfig);

        context.SetFAAConfig(new FAAUserConfig { FAAUserName = faaUser.Username, FAAPassword = faaUser.IdOrUserRef, FAAFirstName = faaUser.FirstName, FAALastName = faaUser.LastName});
    }
}
