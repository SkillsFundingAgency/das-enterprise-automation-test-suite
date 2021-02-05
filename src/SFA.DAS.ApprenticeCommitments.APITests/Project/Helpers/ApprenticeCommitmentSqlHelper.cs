using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentSqlHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public ApprenticeCommitmentSqlHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { _dbConfig = dbConfig; }

        public (long accountid, long apprenticeshipid, string orgname) GetEmployerData()
        {
            var query = "SELECT TOP 1 c.EmployerAccountId, a.id  from dbo.Apprenticeship a JOIN dbo.Commitment c ON a.CommitmentId = c.Id ORDER BY NEWID()";

            List<object[]> employerData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.CommitmentsDbConnectionString);

            var accountid = employerData[0][0].ToString();

            var apprenticeshipid = employerData[0][1].ToString();

            query = $"SELECT [NAME] from employer_account.Account WHERE id = {accountid}";

            List<object[]> OrgNameData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString);

            if (OrgNameData.Count == 0)
                return (0, 0, string.Empty);
            else
            {
                return (long.Parse(accountid), long.Parse(apprenticeshipid), OrgNameData[0][0].ToString());
            }
        }
    }
}
