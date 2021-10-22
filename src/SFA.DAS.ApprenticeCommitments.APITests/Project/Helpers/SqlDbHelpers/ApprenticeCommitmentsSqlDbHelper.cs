using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
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

        public (string apprenticeId, string userIdentityid) GetApprenticeIdFromRegistrationTable(string email)
        {
            var data = GetData($"select ApprenticeId, UserIdentityId from Registration where Email = '{email}'", 2);
            return (data[0], data[1]);
        }

        public string GetApprenticeId(string email) => GetData($"select Id from Apprentice where Email ='{email}'");

        public string GetApprenticeshipId(string apprenticeId) => GetData($"select Id from Apprenticeship where ApprenticeId ='{apprenticeId}'");

        public string GetApprenticeEmail(string id) => GetData($"select Email from Apprentice where Id = '{id}'");

        public (string firstName, string lastName) GetApprenticeName(string email)
        {
            var data = GetData($"select FirstName, LastName from Registration where email = '{email}'", 2);
            return (data[0], data[1]);
        }

        public void UpdateConfirmBeforeFieldInCommitmentStatementTable(string email)
        {
            var confirmBeforeDate = DateTime.Now.AddDays(13).AddHours(23).ToString("yyyy-MM-dd HH:mm:ss.fffffff");
            ExecuteSqlCommand($"UPDATE Revision SET ConfirmBefore = '{confirmBeforeDate}' WHERE ApprenticeshipId in {GetRevionTableSubQuery(email)}");
        }

        public void ConfirmApprenticeship(string email)
        {
            ExecuteSqlCommand($"UPDATE Revision set TrainingProviderCorrect = 1, EmployerCorrect = 1, RolesAndResponsibilitiesCorrect = 1, ApprenticeshipDetailsCorrect = 1, HowApprenticeshipDeliveredCorrect = 1, ConfirmedOn = GETDATE() WHERE ApprenticeshipId in {GetRevionTableSubQuery(email)}");
        }

        public string ConfirmCoCEventHasTriggered(string email, string scenarioTitle) => GetDetails($"SELECT ApprenticeshipDetailsCorrect from Revision WHERE ConfirmedOn is Null and ApprenticeshipId in {GetRevionTableSubQuery(email)}", scenarioTitle);

        public string GetRegistrationId(string email, string scenarioTitle) => GetDetails(GetRegistrationIdQuery(email), scenarioTitle);

        public List<string> GetRegistrationIds(string email) => GetMultipleData(GetRegistrationIdQuery(email), 1).ListOfArrayToList(0);

        private string GetRegistrationIdQuery(string email) => $"select RegistrationId from Registration where Email ='{email}' order by CreatedOn DESC";

        private string GetRevionTableSubQuery(string email) => $"(SELECT Id FROM Apprenticeship WHERE ApprenticeId in (SELECT Id from [Apprentice] WHERE Email = '{email}'))";

        private string GetDetails(string query, string scenarioTitle) => Convert.ToString(TryGetDataAsObject(query, scenarioTitle));
    }
}
