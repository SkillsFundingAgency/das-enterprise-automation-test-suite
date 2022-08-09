using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeCommitmentsAccountsSqlDbHelper : SqlDbHelper
    {
        public ApprenticeCommitmentsAccountsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentAccountsDbConnectionString) { }

        public void DeleteEmailAddressHistoryTableData(string apprenticeId) =>
            ExecuteSqlCommand($"DELETE FROM ApprenticeEmailAddressHistory WHERE ApprenticeId = '{apprenticeId}'");

        public void DeleteApprenticeTableData(string apprenticeId) => ExecuteSqlCommand($"DELETE FROM Apprentice WHERE Id = '{apprenticeId}'");

        public (string apprenticeId, string firstName, string lastName) GetApprenticeDetails(string email)
        {
            var data = GetData($"select  Id, FirstName, LastName from Apprentice where Email = '{email}'");
            return (data[0], data[1], data[2]);
        }

        public string GetApprenticeIdFromApprenticeTable (string email) => GetDataAsString($"SELECT Id FROM Apprentice WHERE Email = '{email}'");
    }
}
