using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentSqlHelper : SqlDbHelper
    {
        public ApprenticeCommitmentSqlHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        public (string accountid, string apprenticeshipid, string orgname) GetEmployerData()
        {
            var query = "SELECT TOP 1 c.EmployerAccountId, a.id  from dbo.Apprenticeship a JOIN dbo.Commitment c ON a.CommitmentId = c.Id ORDER BY NEWID()";

            List<object[]> employerData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString);

            var accountid = employerData[0][0].ToString();

            var apprenticeshipid = employerData[0][1].ToString();

            query = $"SELECT [NAME] from employer_account.Account WHERE id = {accountid}";

            List<object[]> OrgNameData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString);

            if (OrgNameData.Count == 0)
                return (string.Empty, string.Empty, string.Empty);
            else
            {
                return (accountid, apprenticeshipid, OrgNameData[0][0].ToString());
            }
        }
    }
}
