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
            var query = $"select LegalName, TradingName from Organisations where UKPRN = {providerId}";

            List<object[]> providerData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.RoatpDatabaseConnectionString);

            var legalName = providerData[0][0].ToString();

            var tradingName = providerData[0][1].ToString();

            if (providerData.Count == 0)
                return (string.Empty, string.Empty);
            else
            {
                return (legalName, tradingName);
            }
        }

        public (long accountid, long apprenticeshipid, string firstname, string lastname, string trainingname, string empname, long legalEntityId, long providerId) GetEmployerData()
        {
            var query = "SELECT TOP 1 Commitment.EmployerAccountId, Apprenticeship.id, FirstName, LastName, TrainingName, Commitment.AccountLegalEntityId, Commitment.ProviderId " +
                "FROM[dbo].[Apprenticeship] as Apprenticeship " +
                "INNER JOIN Commitment on Apprenticeship.CommitmentId = Commitment.Id " +
                "INNER JOIN Accounts on Accounts.Id = Commitment.EmployerAccountId " +
                "INNER JOIN AccountLegalEntities on Commitment.AccountLegalEntityId = AccountLegalEntities.Id " +
                "WHERE IsApproved in (0, 1) and IsDeleted = 0 and AccountLegalEntityId is not null and AccountLegalEntities.Deleted is null " +
                "ORDER BY NEWID()";

            List<object[]> apprenticeData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.CommitmentsDbConnectionString);

            var accountid = apprenticeData[0][0].ToString();

            var apprenticeshipid = apprenticeData[0][1].ToString();

            var apprenticeFirstName = apprenticeData[0][2].ToString();

            var apprenticeLastName = apprenticeData[0][3].ToString();

            var apprenticeTrainingName = apprenticeData[0][4].ToString();

            var apprenticelegalEntityId = apprenticeData[0][5].ToString();

            var apprenticeProviderId = apprenticeData[0][6].ToString();

            List<object[]> empNameData = SqlDatabaseConnectionHelper.ReadDataFromDataBase($"SELECT [NAME] from employer_account.Account WHERE id = {accountid}", connectionString);

            if (empNameData.Count == 0)
                return (0, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0);
            else
            {
                return (long.Parse(accountid), long.Parse(apprenticeshipid), apprenticeFirstName, apprenticeLastName, apprenticeTrainingName, empNameData[0][0].ToString(), long.Parse(apprenticelegalEntityId), long.Parse(apprenticeProviderId));
            }
        }
    }
}