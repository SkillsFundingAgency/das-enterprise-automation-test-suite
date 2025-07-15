using SFA.DAS.Login.Service.Project;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.RAA.DataGenerator.Project.Config;
using SFA.DAS.TestDataExport.Helper;

namespace SFA.DAS.FAA.UITests.Project;

[Binding]
public class FAAConfigurationSetup(ScenarioContext context)
{
    private const string FAAApplyUsersConfig = "FAAApplyUsersConfig";
    private const string FAAFoundationUsersConfig = "FAAFoundationUsersConfig";

    [BeforeScenario(Order = 2)]
    public void SetUpFAAConfiguration()
    {
        var listOfFAAApplyUsers = new MultiConfigurationSetupHelper(context).SetMultiConfiguration<FAAApplyUsers>(FAAApplyUsersConfig);
        var listOfFAAFoundationUsers = new MultiConfigurationSetupHelper(context).SetMultiConfiguration<FAAApplyUsers>(FAAFoundationUsersConfig);

        var fAAApplyUsers = RandomDataGenerator.GetRandomElementFromListOfElements(listOfFAAApplyUsers);
        var fAAFoundationUsers = RandomDataGenerator.GetRandomElementFromListOfElements(listOfFAAFoundationUsers);

        var userList = fAAApplyUsers.ListofUser.ToList();
        var random = new Random();
        int firstIndex = random.Next(userList.Count);
        int secondIndex;
        do
        {
            secondIndex = random.Next(userList.Count);
        } while (secondIndex == firstIndex);

        var foundationUserList = fAAFoundationUsers.ListofUser.ToList();
        int index = random.Next(foundationUserList.Count);

        var selectedUser1 = userList[firstIndex];
        var selectedUser2 = userList[secondIndex];
        var selectedFoundationUser = foundationUserList[index];

        var faaApplyUser = new FAAApplyUser { Username = $"{selectedUser1}@{fAAApplyUsers.Domain}" };
        var FAAApplySecondUser = new FAAApplySecondUser { Username = $"{selectedUser2}@{fAAApplyUsers.Domain}" };
        var FAAApplyFoundationUser = new FAAFoundationUser { Username = $"{selectedFoundationUser}@{fAAFoundationUsers.Domain}" };

        context.SetFAAPortaluser([faaApplyUser]);
        context.SetFAAPortaluser2([FAAApplySecondUser]);
        context.SetFAAPortalFoundationuser([FAAApplyFoundationUser]);

        var faaUser = context.GetUser<FAAApplyUser>();

        context.SetFAAConfig(new FAAUserConfig { FAAUserName = faaUser.Username, FAAPassword = faaUser.IdOrUserRef, FAAFirstName = faaUser.FirstName, FAALastName = faaUser.LastName });
    }

    private MailosaurApiHelper mailosaurApiHelper;

    [BeforeScenario(Order = 12)]
    public void SetUpMailosaurApiHelper() => context.Set(mailosaurApiHelper = new MailosaurApiHelper(context));
}
