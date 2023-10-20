using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeCommitmentsSqlDbHelper : SqlDbHelper
    {
        public ApprenticeCommitmentsSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.ApprenticeCommitmentDbConnectionString) { }

        public void DeleteRevisionAndApprenticeshipTableData(string apprenticeId, string email) => ExecuteSqlCommand(
            $"DELETE FROM Revision WHERE ApprenticeshipId in (SELECT ApprenticeshipId from Registration WHERE Email = '{email}')" +
            $"DELETE FROM Apprenticeship WHERE ApprenticeId = '{apprenticeId}'");

        public void DeleteRegistrationTableData(string email) => ExecuteSqlCommand($"DELETE FROM Registration WHERE Email = '{email}'");

        public string GetApprenticeshipId(string apprenticeId) => GetDataAsString($"select Id from Apprenticeship where ApprenticeId ='{apprenticeId}'");

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

        public string GetPlannedEndDateFromRegistration(string email) => Convert.ToString(GetDataAsObject($"SELECT PlannedEndDate FROM Registration WHERE Email = '{email}'"));

        public string GetEmploymentEndDateFromRegistration(string email) => Convert.ToString(GetDataAsObject($"SELECT EmploymentEndDate FROM Registration WHERE Email = '{email}'"));

        private string GetRegistrationIdQuery(string email) => $"select RegistrationId from Registration where Email ='{email}' order by CreatedOn DESC";

        private string GetRevionTableSubQuery(string email) => $"(SELECT Id FROM Apprenticeship WHERE Id = (SELECT TOP 1 ApprenticeshipId from [Registration] WHERE Email = '{email}' order by ApprenticeshipId desc))";

        private string GetDetails(string query, string scenarioTitle) => Convert.ToString(WaitAndGetDataAsObject(query));
    }
}
