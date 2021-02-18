using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class LoginInvitationsSqlDbHelper : InvitationsSqlDbHelper
    {
        public LoginInvitationsSqlDbHelper(RoatpConfig roatpConfig) : base(roatpConfig.LoginDatabaseConnectionString) { }
    }
}
