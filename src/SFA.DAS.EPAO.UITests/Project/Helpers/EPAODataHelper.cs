using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    class EPAODataHelper
    {
        private readonly SqlDatabaseConnectionHelper _sqlDatabase;
        private readonly string _connectionString;

        public EPAODataHelper(EPAOConfig ePAOConfig, SqlDatabaseConnectionHelper sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
            _connectionString = ePAOConfig.EPAOAssessorDbConnectionString;
        }

        public void DeleteCertificate(String uln)
        {
            var queryToExecute = $"DELETE FROM [CertificateLogs] WHERE CertificateId IN (SELECT Id FROM [Certificates] WHERE ULN = '{uln}')";
            _sqlDatabase.ExecuteSqlCommand(_connectionString, queryToExecute);

            queryToExecute = $"DELETE FROM [Certificates] WHERE ULN = '{uln}'";
            _sqlDatabase.ExecuteSqlCommand(_connectionString, queryToExecute);
        }
    }
}
