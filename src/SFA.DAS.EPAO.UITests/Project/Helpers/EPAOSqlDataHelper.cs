using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOAdminSqlDataHelper
    {
        private readonly string _connectionString;

        public EPAOAdminSqlDataHelper(EPAOConfig ePAOConfig) => _connectionString = ePAOConfig.EPAOAssessorDbConnectionString;

        public void DeleteUkprn(string ukprn) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, 
            $"DELETE FROM Organisations WHERE EndPointAssessorUkprn = '{ukprn}'");

        public void DeleteContact(string email) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, 
            $"DELETE CONTACTS WHERE EMAIL = '{email}'");

        public void DeleteOrganisationStandard(string standardcode, string epaoid) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, 
            $"DELETE FROM OrganisationStandardDeliveryArea WHERE OrganisationStandardId IN (SELECT ID FROM OrganisationStandard WHERE StandardCode = '{standardcode}' AND EndPointAssessorOrganisationId = '{epaoid}'); DELETE FROM OrganisationStandard WHERE StandardCode = '{standardcode}' AND EndPointAssessorOrganisationId = '{epaoid}'");

        public void UpdateOrgStatusToNew(string status, string epaoid) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, 
            $"Update Organisations Set Status = '{status}' Where EndPointAssessorOrganisationId = '{epaoid}'");

        public void UpdateOrgStandardStatusToNew(string status, string epaoid, string standardcode) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, 
            $"Update OrganisationStandard Set Status = '{status}' where EndPointAssessorOrganisationId = '{epaoid}' AND StandardCode = '{standardcode}'");

        public void UpdateOrgStatusToLive(string status, string epaoid) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, 
            $"Update Organisations Set Status = '{status}' Where EndPointAssessorOrganisationId = '{epaoid}'");
    }

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

        private void ExecuteSqlCommand(string queryToExecute) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, queryToExecute);

        private string GetDataFromDb(string queryToExecute) => Convert.ToString(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, _connectionString)[0][0]);
    }
}
