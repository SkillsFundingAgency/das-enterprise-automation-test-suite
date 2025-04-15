using SFA.DAS.Login.Service.Project;
using SFA.DAS.RAA.DataGenerator.Project.Config;

namespace SFA.DAS.FAA.UITests.Project;

[Binding]
public class FAAConfigurationSetup(ScenarioContext context)
{
    private const string FAAApplyUsersConfig = "FAAApplyUsersConfig";

    [BeforeScenario(Order = 2)]
    public void SetUpFAAConfiguration()
    {
        var listOfFAAApplyUsers = new MultiConfigurationSetupHelper(context).SetMultiConfiguration<FAAApplyUsers>(FAAApplyUsersConfig);

        var fAAApplyUsers = RandomDataGenerator.GetRandomElementFromListOfElements(listOfFAAApplyUsers);

        var selectedUser = RandomDataGenerator.GetRandomElementFromListOfElements(fAAApplyUsers.ListofUser);

        var faaApplyUser = new FAAApplyUser { Username = $"{selectedUser}@{fAAApplyUsers.Domain}" };

        var faaConfigList = new MultiConfigurationSetupHelper(context)
            .SetMultiConfiguration<FAAConfig>("FAAConfig");

        var faaConfig = faaConfigList.FirstOrDefault();
        context.Set(faaConfig);

        context.SetFAAPortaluser([faaApplyUser]);

        var faaUser = context.GetUser<FAAApplyUser>();

        context.SetFAAConfig(new FAAUserConfig { FAAUserName = faaUser.Username, FAAPassword = faaUser.IdOrUserRef, FAAFirstName = faaUser.FirstName, FAALastName = faaUser.LastName});
    }
}
