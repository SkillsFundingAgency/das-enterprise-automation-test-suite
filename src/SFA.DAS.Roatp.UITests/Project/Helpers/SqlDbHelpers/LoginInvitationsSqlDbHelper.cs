using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class LoginInvitationsSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : InvitationsSqlDbHelper(objectContext, dbConfig.LoginDatabaseConnectionString)
    {
    }
}
