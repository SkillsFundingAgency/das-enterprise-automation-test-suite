using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FrameworkHelpers
{
    public abstract class InvitationsSqlDbHelper : SqlDbHelper
    {
        public InvitationsSqlDbHelper(ObjectContext objectContext, string connectionString) : base(objectContext, connectionString) { }

        public string GetId(string email) => GetNullableData($"select Id FROM [LoginService].[Invitations] where email = '{email}'");

        public void DeleteUser(string email) => ExecuteSqlCommand($"DELETE FROM [IdentityServer].[aspnetusers] where email = '{email}'");

        public void DeleteAspNetUsersTableDataForCMAD(string apprenticeId) => ExecuteSqlCommand($"DELETE FROM [IdentityServer].[aspnetusers] where ApprenticeId = '{apprenticeId}'");

        public string DeleteUserLogsTableData(string email) => GetNullableData($"DELETE [LoginService].[UserLogs] where email = '{email}'");

        public string GetApprenticeIdFromAspNetUsersTable(string email) => GetDataAsString($"SELECT ApprenticeId FROM [IdentityServer].[AspNetUsers] WHERE Email = '{email}'");
    }
}
