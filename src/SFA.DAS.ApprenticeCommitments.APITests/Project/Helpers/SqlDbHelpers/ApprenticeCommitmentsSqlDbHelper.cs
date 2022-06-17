using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeCommitmentsSqlDbHelper : SqlDbHelper
    {
        public ApprenticeCommitmentsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentDbConnectionString) { }

        public void DeleteApprentice(string email) => ExecuteSqlCommand(
            $"DELETE FROM Revision WHERE ApprenticeshipId in (SELECT Id from Apprenticeship WHERE ApprenticeId in (SELECT Id from [Apprentice] WHERE Email = '{email}'))" +
            $"DELETE FROM Apprenticeship WHERE ApprenticeId in (SELECT Id from [Apprentice] WHERE Email = '{email}')" +
            $"DELETE FROM ApprenticeEmailAddressHistory WHERE ApprenticeId in (SELECT Id from [Apprentice] WHERE Email = '{email}')" +
            $"DELETE FROM Apprentice WHERE Email = '{email}'" +
            $"DELETE FROM Registration WHERE Email = '{email}'");

        public string GetApprenticeshipId(string apprenticeId) => GetDataAsString($"select Id from Apprenticeship where ApprenticeId ='{apprenticeId}'");

        public (string apprenticeId, string firstName, string lastName) GetApprenticeDetails(string email)
        {
            var data = GetData($"select  Id, FirstName, LastName from Apprentice where Email = '{email}'");
            return (data[0], data[1], data[2]);
        }

        public void UpdateConfirmBeforeFieldInCommitmentStatementTable(string email)
        {
            var confirmBeforeDate = DateTime.Now.AddDays(13).AddHours(23).ToString("yyyy-MM-dd HH:mm:ss.fffffff");
            ExecuteSqlCommand($"UPDATE Revision SET ConfirmBefore = '{confirmBeforeDate}' WHERE ApprenticeshipId in {GetRevionTableSubQuery(email)}");
        }

        public void ConfirmApprenticeship(string email)
        {
            ExecuteSqlCommand($"UPDATE Revision set TrainingProviderCorrect = 1, EmployerCorrect = 1, RolesAndResponsibilitiesConfirmations = 7, ApprenticeshipDetailsCorrect = 1, HowApprenticeshipDeliveredCorrect = 1, ConfirmedOn = GETDATE() WHERE ApprenticeshipId in {GetRevionTableSubQuery(email)}");
        }

        public string ConfirmCoCEventHasTriggered(string email, string scenarioTitle) => GetDetails($"SELECT ApprenticeshipDetailsCorrect from Revision WHERE ConfirmedOn is Null and ApprenticeshipId in {GetRevionTableSubQuery(email)}", scenarioTitle);

        public string GetRegistrationId(string email, string scenarioTitle) => GetDetails(GetRegistrationIdQuery(email), scenarioTitle);

        public List<string> GetRegistrationIds(string email) => GetMultipleData(GetRegistrationIdQuery(email)).ListOfArrayToList(0);

        private string GetRegistrationIdQuery(string email) => $"select RegistrationId from Registration where Email ='{email}' order by CreatedOn DESC";

        private string GetRevionTableSubQuery(string email) => $"(SELECT Id FROM Apprenticeship WHERE ApprenticeId in (SELECT Id from [Apprentice] WHERE Email = '{email}'))";

        private string GetDetails(string query, string scenarioTitle) => Convert.ToString(TryGetDataAsObject(query, scenarioTitle));
    }
}
