using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;


namespace SFA.DAS.AssessorCertification.APITests.Project.Helpers.SqlDbHelpers
{
    public class AssessorCertificationSqlDbHelper : SqlDbHelper
    {
       public AssessorCertificationSqlDbHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }

        
        public void DeleteCertificate(string uln)
        {
            ExecuteSqlCommand($"DELETE FROM [CertificateLogs] WHERE CertificateId IN (SELECT Id FROM [Certificates] WHERE Uln = {uln})");
            ExecuteSqlCommand($"DELETE FROM [Certificates] WHERE Uln = {uln}");
        }

        public string GetEPAreferenceAfterAPI(string uln) => GetData($"SELECT CertificateReference FROM [Certificates] WHERE Uln = {uln}");
        
        
          
    }
}
