using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOSqlDataHelper
    {
        private readonly SqlDatabaseConnectionHelper _sqlDatabase;
        private readonly string _connectionString;

        public EPAOSqlDataHelper(EPAOConfig ePAOConfig, SqlDatabaseConnectionHelper sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
            _connectionString = ePAOConfig.EPAOAssessorDbConnectionString;
        }

        public void DeleteCertificate(String uln)
        {
            ExecuteSqlCommand($"DELETE FROM [CertificateLogs] WHERE CertificateId IN (SELECT Id FROM [Certificates] WHERE ULN = '{uln}')");
            ExecuteSqlCommand($"DELETE FROM [Certificates] WHERE ULN = '{uln}'");
        }

        private void ExecuteSqlCommand(string queryToExecute) => _sqlDatabase.ExecuteSqlCommand(_connectionString, queryToExecute);
    }
}
