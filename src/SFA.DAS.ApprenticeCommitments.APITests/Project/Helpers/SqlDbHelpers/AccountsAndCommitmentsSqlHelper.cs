using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class AccountsAndCommitmentsSqlHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public AccountsAndCommitmentsSqlHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { _dbConfig = dbConfig; }

        public (string legalName, string tradingName) GetProviderData(long providerId)
        {
            var providerData = GetData($"select LegalName, TradingName from Organisations where UKPRN = {providerId}", _dbConfig.RoatpDatabaseConnectionString, 2);

            return (providerData[0], providerData[1]);
        }

        public (long accountid, long apprenticeshipid, string firstname, string lastname, string trainingname, string empname, long legalEntityId, long providerId, string startDate, string endDate) GetEmployerData()
        {
            var query = "SELECT TOP 1 Commitment.EmployerAccountId, Apprenticeship.id, FirstName, LastName, TrainingName, Commitment.AccountLegalEntityId, Commitment.ProviderId, StartDate, EndDate " +
                "FROM[dbo].[Apprenticeship] as Apprenticeship " +
                "INNER JOIN Commitment on Apprenticeship.CommitmentId = Commitment.Id " +
                "INNER JOIN Accounts on Accounts.Id = Commitment.EmployerAccountId " +
                "INNER JOIN AccountLegalEntities on Commitment.AccountLegalEntityId = AccountLegalEntities.Id " +
                "WHERE IsApproved = 1 and IsDeleted = 0 and AccountLegalEntityId is not null and AccountLegalEntities.Deleted is null and TrainingCode NOT like '%-%'" +
                "ORDER BY NEWID()";

            var apprenticeData = GetData(query, _dbConfig.CommitmentsDbConnectionString, 9);

            var accountid = apprenticeData[0];
            var apprenticeshipid = apprenticeData[1];
            var apprenticeFirstName = apprenticeData[2];
            var apprenticeLastName = apprenticeData[3];
            var apprenticeTrainingName = apprenticeData[4];
            var apprenticelegalEntityId = apprenticeData[5];
            var apprenticeProviderId = apprenticeData[6];
            var startDate = apprenticeData[7];
            var endDate = apprenticeData[8];

            List<object[]> empNameData = SqlDatabaseConnectionHelper.ReadDataFromDataBase($"SELECT [NAME] from employer_account.Account WHERE id = {accountid}", connectionString);

            if (empNameData.Count == 0)
                return (0, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
            else
                return (long.Parse(accountid), long.Parse(apprenticeshipid), apprenticeFirstName, apprenticeLastName, apprenticeTrainingName, empNameData[0][0].ToString(), long.Parse(apprenticelegalEntityId), long.Parse(apprenticeProviderId), startDate, endDate);
        }

        public void UpdateEmailForApprenticeshipRecord(string email, long apprenticeshipid)
        {
            var query = $"UPDATE [Apprenticeship] SET Email = '{email}' WHERE Id = {apprenticeshipid}";
            ExecuteSqlCommand(query, _dbConfig.CommitmentsDbConnectionString);
        }
    }
}