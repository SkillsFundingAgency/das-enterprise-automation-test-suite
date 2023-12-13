using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers
{
    public class CommitmentsSqlHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.CommitmentsDbConnectionString)
    {
        public (string trainingName, string traningDate) GetTrainingNameAndStartDate(string email)
        {
            var query = $"SELECT TrainingName, StartDate From Apprenticeship WHERE Email = '{email}'";
            var data = GetData(query);
            return (data[0], data[1]);
        }

        public void UpdateEmailForApprenticeshipRecord(string email, long apprenticeshipid) => ExecuteSqlCommand($"UPDATE [Apprenticeship] SET Email = '{email}' WHERE Id = {apprenticeshipid}");

        public void ResetEmailForApprenticeshipRecord(string email) => ExecuteSqlCommand($"UPDATE [Apprenticeship] SET Email = NULL, EmailAddressConfirmed = NULL WHERE Email = '{email}'");

    }
}