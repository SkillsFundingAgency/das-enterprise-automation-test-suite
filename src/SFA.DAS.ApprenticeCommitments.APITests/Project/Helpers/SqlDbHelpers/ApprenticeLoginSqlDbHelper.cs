using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeLoginSqlDbHelper : InvitationsSqlDbHelper
    {
        public ApprenticeLoginSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentLoginDbConnectionString) { }

        public (string firstname, string lastname) GetApprenticeLoginData(string email)
        {
            var query = $"select GivenName, FamilyName from LoginService.Invitations where email = '{email}'";

            List<object[]> apprenticeData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString);

            if (apprenticeData.Count == 0) return (string.Empty, string.Empty);
            else
            {
                var firstname = apprenticeData[0][0].ToString();

                var lastname = apprenticeData[0][1].ToString();

                return (firstname, lastname);
            }
        }
    }
}
