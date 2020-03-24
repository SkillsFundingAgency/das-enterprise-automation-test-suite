using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOSqlDataHelper
    {
        private readonly string _connectionString;

        public EPAOSqlDataHelper(EPAOConfig ePAOConfig) => _connectionString = ePAOConfig.EPAOAssessorDbConnectionString;

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

        public void DeleteStandardPreambleApplicication(string standardReference, string organisationId) => ExecuteSqlCommand($"DELETE Applications WHERE JSON_VALUE (ApplicationData, '$.StandardReference') = {standardReference} and ApplyingOrganisationId = {organisationId}");

        private void ExecuteSqlCommand(string queryToExecute) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, queryToExecute);

        private string GetDataFromDb(string queryToExecute) => Convert.ToString(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, _connectionString)[0][0]);
    }
}
