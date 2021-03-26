using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOAdminSqlDataHelper : SqlDbHelper
    {
        public EPAOAdminSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }

        public string GetEPAOId(string email) => GetData($"SELECT EndPointAssessorOrganisationId from Organisations where id = (select OrganisationId from Contacts where Email = '{email}')");

        public void DeleteOrganisation(string ukprn) => ExecuteSqlCommand($"DELETE FROM Organisations WHERE EndPointAssessorUkprn = '{ukprn}'");

        public void DeleteContact(string email) => ExecuteSqlCommand($"DELETE CONTACTS WHERE EMAIL = '{email}'");

        public void DeleteOrganisationStandard(string standardcode, string epaoid) => ExecuteSqlCommand(
            $"DELETE FROM OrganisationStandardDeliveryArea WHERE OrganisationStandardId IN " +
            $"(select ID FROM OrganisationStandard WHERE StandardCode = '{standardcode}' AND EndPointAssessorOrganisationId = '{epaoid}'); " +
            $"DELETE FROM OrganisationStandard WHERE StandardCode = '{standardcode}' AND EndPointAssessorOrganisationId = '{epaoid}'");

        public void DeleteOrganisationStandardDeliveryArea(string emailid) => ExecuteSqlCommand(
                $"DELETE from OrganisationStandardDeliveryArea where OrganisationStandardId IN " +
                $"(select id from OrganisationStandard where EndPointAssessorOrganisationId IN " +
                $"(select EndPointAssessorOrganisationId from Contacts where Email = '{emailid}'))");

        public void DeleteOrganisationStanard(string emailid) => ExecuteSqlCommand(
            $"DELETE from OrganisationStandard where EndPointAssessorOrganisationId IN " +
            $"(select EndPointAssessorOrganisationId from Contacts where Email = '{emailid}')");


        public void DeleteEPAOOrganisation(string emailid) => ExecuteSqlCommand(
            $" DELETE from Organisations where EndPointAssessorOrganisationId IN" +
                $" (select EndPointAssessorOrganisationId from Contacts where Email = '{emailid}')");

        public void UpdateOrgStatusToNew(string epaoid) => UpdateOrgStatus("New", epaoid);

        public void UpdateOrgStandardStatusToNew(string epaoid, string standardcode) => ExecuteSqlCommand($"Update OrganisationStandard Set Status = 'New' where EndPointAssessorOrganisationId = '{epaoid}' AND StandardCode = '{standardcode}'");

        public void UpdateOrgStatusToLive(string epaoid) => UpdateOrgStatus("Live", epaoid);

        private void UpdateOrgStatus(string status, string epaoid) => ExecuteSqlCommand($"Update Organisations Set Status = '{status}' Where EndPointAssessorOrganisationId = '{epaoid}'");
    }
}