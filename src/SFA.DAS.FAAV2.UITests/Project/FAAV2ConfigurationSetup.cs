using SFA.DAS.RAA.DataGenerator.Project.Config;

namespace SFA.DAS.FAAV2.UITests.Project;

[Binding]
public class FAAV2ConfigurationSetup(ScenarioContext context)
{
    private const string FAAApplyUsersConfig = "FAAApplyUsersConfig";

    [BeforeScenario(Order = 2)]
    public void SetUpFAAV2Configuration()
    {
        var listOfFAAApplyUsers = new MultiConfigurationSetupHelper(context).SetMultiConfiguration<FAAApplyUsers>(FAAApplyUsersConfig);

        var fAAApplyUsers = RandomDataGenerator.GetRandomElementFromListOfElements(listOfFAAApplyUsers);

        var selectedUser = RandomDataGenerator.GetRandomElementFromListOfElements(fAAApplyUsers.ListofUser);

        var faaApplyUser = new FAAApplyUser { Username = $"{selectedUser}@{fAAApplyUsers.Domain}" };

        context.SetFAAPortaluser([faaApplyUser]);

        var faaUser = context.GetUser<FAAApplyUser>();

        context.SetFAAConfig(new FAAUserConfig { FAAUserName = faaUser.Username, FAAPassword = faaUser.IdOrUserRef, FAAFirstName = faaUser.FirstName, FAALastName = faaUser.LastName });
    }
}
