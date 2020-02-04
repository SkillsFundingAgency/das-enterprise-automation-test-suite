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

        public void DeleteCertificate(string uln)
        {
            ExecuteSqlCommand($"DELETE FROM [CertificateLogs] WHERE CertificateId IN (SELECT Id FROM [Certificates] WHERE ULN = '{uln}')");
            ExecuteSqlCommand($"DELETE FROM [Certificates] WHERE ULN = '{uln}'");
        }

        public void ResetApplyUser(string applyUserEmail)
        {
            var organisationId = GetDataFromDb($"SELECT OrganisationId from Contacts where Email = '{applyUserEmail}'");
            if (organisationId.Equals("")) return;
            ExecuteSqlCommand($"UPDATE Contacts SET OrganisationID = null WHERE Email = '{applyUserEmail}'");
            ExecuteSqlCommand($"DELETE from Apply where OrganisationId = '{organisationId}'");
        }

        private void ExecuteSqlCommand(string queryToExecute) => _sqlDatabase.ExecuteSqlCommand(_connectionString, queryToExecute);

        private string GetDataFromDb(string queryToExecute) => Convert.ToString(_sqlDatabase.ReadDataFromDataBase(queryToExecute, _connectionString)[0][0]);
    }
}
