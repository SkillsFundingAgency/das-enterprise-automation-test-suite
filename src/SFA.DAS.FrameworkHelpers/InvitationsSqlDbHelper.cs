namespace SFA.DAS.FrameworkHelpers
{
    public abstract class InvitationsSqlDbHelper(ObjectContext objectContext, string connectionString) : SqlDbHelper(objectContext, connectionString)
    {
        public void DeleteAspNetUsersTableDataForCMAD(string apprenticeId) => ExecuteSqlCommand($"DELETE FROM [IdentityServer].[aspnetusers] where ApprenticeId = '{apprenticeId}'");

        public string DeleteUserLogsTableData(string email) => GetNullableData($"DELETE [LoginService].[UserLogs] where email = '{email}'");

        public string GetApprenticeIdFromAspNetUsersTable(string email) => GetDataAsString($"SELECT ApprenticeId FROM [IdentityServer].[AspNetUsers] WHERE Email = '{email}'");
    }
}
