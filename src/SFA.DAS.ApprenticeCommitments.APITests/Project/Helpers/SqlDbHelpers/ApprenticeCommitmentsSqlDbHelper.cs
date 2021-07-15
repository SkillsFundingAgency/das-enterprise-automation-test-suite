using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeCommitmentsSqlDbHelper : SqlDbHelper
    {
        public ApprenticeCommitmentsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentDbConnectionString) { }

        public void DeleteApprentice(string email) => ExecuteSqlCommand(
            $"DELETE FROM CommitmentStatement WHERE ApprenticeshipId in (SELECT Id from Apprenticeship WHERE ApprenticeId in (SELECT ApprenticeId from Registration WHERE Email = '{email}'))" +
            $"DELETE FROM Apprenticeship WHERE ApprenticeId in (SELECT ApprenticeId from [Registration] WHERE Email = '{email}')" +
            $"DELETE FROM ApprenticeEmailAddressHistory WHERE ApprenticeId in (SELECT ApprenticeId from [Registration] WHERE Email = '{email}')" +
            $"DELETE FROM Apprentice WHERE Email = '{email}'" +
            $"DELETE FROM Registration WHERE Email = '{email}'");

        public (string apprenticeId, string userIdentityid) GetRegistrationId(string email)
        {
            var data = GetData($"select ApprenticeId, UserIdentityId from Registration where Email = '{email}'", 2);
            return (data[0], data[1]);
        }

        public string GetApprenticeId(string email) => GetData($"select Id from Apprentice where Email ='{email}'");

        public string GetApprenticeshipId(string apprenticeId) => GetData($"select Id from Apprenticeship where ApprenticeId ='{apprenticeId}'");

        public string GetApprenticeEmail(string id) => GetData($"select Email from Apprentice where Id = '{id}'");

        public void UpdateConfirmBeforeFieldInCommitmentStatementTable(string email)
        {
            var confirmBeforeDate = DateTime.Now.AddDays(13).AddHours(23).ToString("yyyy-MM-dd HH:mm:ss.fffffff");
            ExecuteSqlCommand($"UPDATE[CommitmentStatement] SET ConfirmBefore = '{confirmBeforeDate}' WHERE CommitmentsApprenticeshipId = (SELECT CommitmentsApprenticeshipId from Registration WHERE Email = '{email}')");
        }
    }
}
