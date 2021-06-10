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

        public void UpdateCertificateForSubmission(string uln)
        {
            ExecuteSqlCommand($"UPDATE [Certificates] SET Status = 'Draft', CertificateReference = '00012129' WHERE Uln = {uln}");
        }

        public void UpdateCertificateReferenceEPA(string uln)
        {
            ExecuteSqlCommand($"UPDATE [Certificates] SET CertificateReference = '00012123' WHERE Uln = {uln}");
        }

        public void UpdateCertificateReferenceCert(string uln)
        {
            ExecuteSqlCommand($"UPDATE [Certificates] SET CertificateReference = '00012127' WHERE Uln = {uln}");
        }

        public void UpdateCertificateReferenceDelete(string uln)
        {
            ExecuteSqlCommand($"UPDATE [Certificates] SET CertificateReference = '00012125' WHERE Uln = {uln}");
        }

        public void UpdateCertificateReferenceDeleteCert(string uln)
        {
            ExecuteSqlCommand($"UPDATE [Certificates] SET CertificateReference = '00012128' WHERE Uln = {uln}");
        }

        public string GetEPAreferenceAfterAPI(string uln) => GetData($"SELECT CertificateReference FROM [Certificates] WHERE Uln = {uln}");

        public string GetCertificateStatus(string uln) => GetData($"SELECT Status FROM [Certificates] WHERE Uln = {uln}");

        public string GetCertificateLogAction(string uln) => GetData($"SELECT Action from CertificateLogs c1 WHERE CertificateId IN (SELECT Id FROM [Certificates] WHERE uln = {uln}) and EventTime = (select max(EventTime) from CertificateLogs c2 where c1.CertificateId = c2.CertificateId)");


        public string GetLearnerUln(string uln) => GetData($"SELECT Uln FROM [Ilrs] WHERE Uln = {uln}");
    }
}

