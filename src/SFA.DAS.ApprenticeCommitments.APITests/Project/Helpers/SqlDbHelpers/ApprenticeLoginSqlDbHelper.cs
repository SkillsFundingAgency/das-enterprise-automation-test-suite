using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeLoginSqlDbHelper : InvitationsSqlDbHelper
    {
        public ApprenticeLoginSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentLoginDbConnectionString) { }

        public void DeleteUserRequests(string email) => ExecuteSqlCommand($"DELETE FROM LoginService.ResetPasswordRequests where email = '{email}'");

        public (string firstname, string lastname) GetApprenticeLoginData(string email) 
            => ReadDataFromDatabase($"select GivenName, FamilyName from LoginService.Invitations where email = '{email}'");

        public (string clientId, string requestId) GetApprenticeResetLoginData(string email) 
            => ReadDataFromDatabase($"select ClientId, Id from LoginService.ResetPasswordRequests where email = '{email}'");

        private (string firstname, string lastname) ReadDataFromDatabase(string query)
        {
            List<object[]> apprenticeData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString);

            if (apprenticeData.Count == 0) return (string.Empty, string.Empty);
            else
            {
                var item1 = apprenticeData[0][0].ToString();

                var item2 = apprenticeData[0][1].ToString();

                return (item1, item2);
            }
        }
    }
}
