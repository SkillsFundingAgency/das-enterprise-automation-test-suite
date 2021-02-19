using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeCommitmentsRegistrationSqlDbHelper : SqlDbHelper
    {
        public ApprenticeCommitmentsRegistrationSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentDbConnectionString) { }

        public void DeleteRegistration(string email) => ExecuteSqlCommand($"DELETE FROM Registration WHERE Email ='{email}'");
    }
}
