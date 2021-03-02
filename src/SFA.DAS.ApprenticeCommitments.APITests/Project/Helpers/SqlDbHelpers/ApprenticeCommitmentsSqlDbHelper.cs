using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeCommitmentsSqlDbHelper : SqlDbHelper
    {
        public ApprenticeCommitmentsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentDbConnectionString) { }

        public void DeleteRegistration(string email) => ExecuteSqlCommand($"DELETE FROM Registration WHERE Email ='{email}'");

        public void DeleteApprentice(string email) => ExecuteSqlCommand(
            $"DELETE FROM Apprenticeship WHERE ApprenticeId = (select Id from Apprentice where Email ='{email}') " +
            $"DELETE FROM Apprentice where Email ='{email}' " +
            $"DELETE FROM ApprenticeEmailAddressHistory where EmailAddress ='{email}'");

        public (string registrationId, string userIdentityid) GetRegistrationId(string email)
            => ProjectSqlDbHelper.ReadDataFromDatabase($"select id, UserIdentityId from Registration where Email = '{email}'", connectionString);

        public long GetApprenticeId(string email) => long.Parse(GetData($"select Id from Apprentice where Email ='{email}'"));

        public string GetApprenticeEmail(long id) => GetData($"select Email from Apprentice where Id = {id}");
    }
}
