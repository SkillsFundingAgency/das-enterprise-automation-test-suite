using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeLoginSqlDbHelper : InvitationsSqlDbHelper
    {
        public ApprenticeLoginSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentLoginDbConnectionString) { }

        public void DeleteUserRequests(string email) => ExecuteSqlCommand($"DELETE FROM LoginService.ResetPasswordRequests where email = '{email}'");

        public (string firstname, string lastname) GetApprenticeLoginData(string email) 
            => ProjectSqlDbHelper.ReadDataFromDatabase($"select GivenName, FamilyName from LoginService.Invitations where email = '{email}'", connectionString);

        public (string clientId, string requestId) GetApprenticeResetLoginData(string email) 
            => ProjectSqlDbHelper.ReadDataFromDatabase($"select ClientId, Id from LoginService.ResetPasswordRequests where email = '{email}'", connectionString);
    }
}
