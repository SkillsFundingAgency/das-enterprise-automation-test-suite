using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeCommitmentSqlHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public ApprenticeCommitmentSqlHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { _dbConfig = dbConfig; }

        public (long accountid, long apprenticeshipid, string firstname, string lastname, string trainingname, string orgname) GetEmployerData()
        {
            var query = "SELECT TOP 1 Commitment.EmployerAccountId, Apprenticeship.id, FirstName, LastName, TrainingName " +
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

            query = $"SELECT [NAME] from employer_account.Account WHERE id = {accountid}";

            List<object[]> OrgNameData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString);

            if (OrgNameData.Count == 0)
                return (0, 0, string.Empty, string.Empty, string.Empty, string.Empty);
            else
            {
                return (long.Parse(accountid), long.Parse(apprenticeshipid), apprenticeFirstName, apprenticeLastName, apprenticeTrainingName, OrgNameData[0][0].ToString());
            }
        }
    }
}