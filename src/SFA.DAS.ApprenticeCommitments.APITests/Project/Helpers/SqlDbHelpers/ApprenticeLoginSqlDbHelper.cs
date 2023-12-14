using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeLoginSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : InvitationsSqlDbHelper(objectContext, dbConfig.ApprenticeCommitmentLoginDbConnectionString)
    {
        public void DeleteResetPasswordRequestsTableData(string email) => ExecuteSqlCommand($"DELETE FROM LoginService.ResetPasswordRequests where email = '{email}'");
            
        public (string clientId, string requestId) GetApprenticeResetLoginData(string email)
        {
            var data = GetData($"select ClientId, Id from LoginService.ResetPasswordRequests where email = '{email}'");

            return (data[0], data[1]);
        }
    }
}
