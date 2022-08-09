using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class AccountsAndCommitmentsSqlHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public AccountsAndCommitmentsSqlHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { _dbConfig = dbConfig; }

        public (string legalName, string tradingName) GetProviderData(long providerId)
        {
            var providerData = GetData($"select LegalName, TradingName from Organisations where UKPRN = {providerId}", _dbConfig.RoatpDatabaseConnectionString);

            return (providerData[0], providerData[1]);
        }

        public (long accountid, long apprenticeshipid, string firstname, string lastname, DateTime dateOfBirth, string trainingname, string empname, long legalEntityId, long providerId, string startDate, string endDate, string createdOn) GetCommitmentData()
        {
            var query = "SELECT TOP 1 C.EmployerAccountId, App.id, App.FirstName, App.LastName, App.TrainingName, C.AccountLegalEntityId, " +
                "C.ProviderId, App.StartDate, App.EndDate, App.CreatedOn, App.DateOfBirth " +
                "FROM Apprenticeship as App " +
                "INNER JOIN Commitment C on App.CommitmentId = C.Id " +
                "INNER JOIN Accounts A on A.Id = C.EmployerAccountId " +
                "INNER JOIN AccountLegalEntities ALE on C.AccountLegalEntityId = ALE.Id " +
                "INNER JOIN Providers P on C.ProviderId = P.Ukprn " +
                "WHERE App.IsApproved = 1 AND C.IsDeleted = 0 AND C.AccountLegalEntityId IS NOT NULL AND ALE.Deleted IS NULL AND LEN(App.TrainingCode) = 3 AND App.Email IS NULL " +
                "ORDER BY NEWID()";

            var apprenticeData = GetData(query, _dbConfig.CommitmentsDbConnectionString);

            var accountid = apprenticeData[0];
            var apprenticeshipid = apprenticeData[1];
            var apprenticeFirstName = apprenticeData[2];
            var apprenticeLastName = apprenticeData[3];
            var apprenticeTrainingName = apprenticeData[4];
            var apprenticelegalEntityId = apprenticeData[5];
            var apprenticeProviderId = apprenticeData[6];
            var startDate = apprenticeData[7];
            var endDate = apprenticeData[8];
            var createdOn = apprenticeData[9];
            var dateOfBirth = apprenticeData[10];

            List<object[]> empNameData = SqlDatabaseConnectionHelper.ReadDataFromDataBase($"SELECT [NAME] from employer_account.Account WHERE id = {accountid}", connectionString);

            if (empNameData.Count == 0)
                return (0, 0, string.Empty, string.Empty, default, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty, string.Empty);
            else
                return (long.Parse(accountid), long.Parse(apprenticeshipid), apprenticeFirstName, apprenticeLastName, DateTime.Parse(dateOfBirth), apprenticeTrainingName, empNameData[0][0].ToString(), long.Parse(apprenticelegalEntityId), long.Parse(apprenticeProviderId), startDate, endDate, createdOn);
        }

        public (string trainingName, string traningDate) GetTrainingNameAndStartDate(string email)
        {
            var query = $"SELECT TrainingName, StartDate From Apprenticeship WHERE Email = '{email}'";
            var data = GetData(query, _dbConfig.CommitmentsDbConnectionString);
            return (data[0], data[1]);
        }

        public void UpdateEmailForApprenticeshipRecord(string email, long apprenticeshipid) => ExecuteSqlCommand($"UPDATE [Apprenticeship] SET Email = '{email}' WHERE Id = {apprenticeshipid}", _dbConfig.CommitmentsDbConnectionString);

        public void ResetEmailForApprenticeshipRecord(long apprenticeshipid) => ExecuteSqlCommand($"UPDATE [Apprenticeship] SET Email = NULL, EmailAddressConfirmed = NULL WHERE Id = {apprenticeshipid}", _dbConfig.CommitmentsDbConnectionString);
    }
}