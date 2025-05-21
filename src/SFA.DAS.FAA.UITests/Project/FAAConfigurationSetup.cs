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
        Console.WriteLine("🚀 Running SetUpFAAConfiguration");

        var listOfFAAApplyUsers = new MultiConfigurationSetupHelper(context).SetMultiConfiguration<FAAApplyUsers>(FAAApplyUsersConfig);

        var fAAApplyUsers = RandomDataGenerator.GetRandomElementFromListOfElements(listOfFAAApplyUsers);

        var userList = fAAApplyUsers.ListofUser.ToList();
        var random = new Random();
        int firstIndex = random.Next(userList.Count);
        int secondIndex;
        do
        {
            secondIndex = random.Next(userList.Count);
        } while (secondIndex == firstIndex);

        var selectedUser1 = userList[firstIndex];
        var selectedUser2 = userList[secondIndex];

        //var selectedUser = RandomDataGenerator.GetRandomElementFromListOfElements(fAAApplyUsers.ListofUser);

        var faaApplyUser = new FAAApplyUser { Username = $"{selectedUser1}@{fAAApplyUsers.Domain}" };
        var FAAApplySecondUser = new FAAApplySecondUser { Username = $"{selectedUser2}@{fAAApplyUsers.Domain}" };

        context.SetFAAPortaluser([faaApplyUser]);
        context.SetFAAPortaluser2([FAAApplySecondUser]);

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
        Console.WriteLine($"[DEBUG] FAAConfigKey: {FAAConfigKey}");
        Console.WriteLine($"[DEBUG] faaConfig.ClosedFaaVacancyReferenceNumber: {faaConfig?.ClosedFaaVacancyReferenceNumber}");


        context.SetFAAConfig(new FAAUserConfig { FAAUserName = faaUser.Username, FAAPassword = faaUser.IdOrUserRef, FAAFirstName = faaUser.FirstName, FAALastName = faaUser.LastName});
    }
}
