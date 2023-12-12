namespace SFA.DAS.FrameworkHelpers
{
    public abstract class InvitationsSqlDbHelper : SqlDbHelper
    {
        public InvitationsSqlDbHelper(ObjectContext objectContext, string connectionString) : base(objectContext, connectionString) { }

        public void DeleteAspNetUsersTableDataForCMAD(string apprenticeId) => ExecuteSqlCommand($"DELETE FROM [IdentityServer].[aspnetusers] where ApprenticeId = '{apprenticeId}'");

        public string DeleteUserLogsTableData(string email) => GetNullableData($"DELETE [LoginService].[UserLogs] where email = '{email}'");

        public string GetApprenticeIdFromAspNetUsersTable(string email) => GetDataAsString($"SELECT ApprenticeId FROM [IdentityServer].[AspNetUsers] WHERE Email = '{email}'");
    }
}
