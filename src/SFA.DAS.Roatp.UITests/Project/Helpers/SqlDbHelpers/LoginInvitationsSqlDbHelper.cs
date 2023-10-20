using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class LoginInvitationsSqlDbHelper : InvitationsSqlDbHelper
    {
        public LoginInvitationsSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.LoginDatabaseConnectionString) { }
    }
}
