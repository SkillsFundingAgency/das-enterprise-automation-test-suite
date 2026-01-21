using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpAdminSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.RoatpDatabaseConnectionString)
    {
        public void DeleteTrainingProvider(string ukprn)
        {
            var sql = $@"DECLARE @OrgId UNIQUEIDENTIFIER;
        SELECT @OrgId = Id FROM Organisations WHERE UKPRN = '{ukprn}';
        DELETE FROM OrganisationCourseTypes WHERE OrganisationId = @OrgId;
        DELETE FROM Organisations WHERE Id = @OrgId;";
        ExecuteSqlCommand(sql);
        }
    }
}
