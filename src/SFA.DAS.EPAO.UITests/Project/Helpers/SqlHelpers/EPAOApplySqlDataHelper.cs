using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers
{
    public class EPAOApplySqlDataHelper : SqlDbHelper
    {
        public EPAOApplySqlDataHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }

        public void DeleteCertificate(string uln)
        {
            ExecuteSqlCommand($"DELETE FROM [CertificateLogs] WHERE CertificateId IN (SELECT Id FROM [Certificates] WHERE ULN = '{uln}')");
            ExecuteSqlCommand($"DELETE FROM [Certificates] WHERE ULN = '{uln}'");
        }

        public void ResetApplyUserOrganisationId(string applyUserEmail)
        {
            var organisationId = GetData($"SELECT OrganisationId from Contacts where Email = '{applyUserEmail}'");
            if (organisationId.Equals("")) return;
            ExecuteSqlCommand($"UPDATE Contacts SET OrganisationID = null WHERE Email = '{applyUserEmail}'");
            ExecuteSqlCommand($"DELETE from Apply where OrganisationId = '{organisationId}'");
        }

        public void DeleteAnyOtherOrganisationId(string applyUserEmail)
        {
            ExecuteSqlCommand($"DELETE from Contacts where OrganisationId = " +
                $"(select id from Organisations where EndPointAssessorOrganisationId = " +
                $"(select EndPointAssessorOrganisationId from Contacts where Email = '{applyUserEmail}') " +
                $"and Email != '{applyUserEmail}')");
        }

        public void ResetApplyUserEPAOId(string applyUserEmail) => ExecuteSqlCommand($"update Contacts set EndPointAssessorOrganisationId = null, [Status] = 'New' where Email = '{applyUserEmail}'");

        public void DeleteStandardApplicication(string standardcode, string organisationId, string userid) => ExecuteSqlCommand($"DELETE from [Apply] where OrganisationId = (select Id from Organisations WHERE EndPointAssessorOrganisationId = '{organisationId}') and CreatedBy = (select Id from Contacts where Email = '{userid}') and StandardCode = {standardcode}");
    }
}