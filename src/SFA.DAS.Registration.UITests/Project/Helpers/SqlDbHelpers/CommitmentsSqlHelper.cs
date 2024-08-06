using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers.SqlDbHelpers
{
    public class CommitmentsSqlHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.CommitmentsDbConnectionString)
    {
        public (string trainingName, string traningDate) GetTrainingNameAndStartDate(string email)
        {
            var query = $"SELECT TrainingName, StartDate From Apprenticeship WHERE Email = '{email}'";
            var data = GetData(query);
            return (data[0], data[1]);
        }

        public int GetCohortsToReviewTask(long employerAccountId)
        {
            string query = $@"WITH CohortsFiltered AS (
								SELECT 
								[c].[Id]
							FROM [Commitment] AS [c]
							LEFT JOIN [Accounts] AS [a] ON [c].[TransferSenderId] = [a].[Id]
							INNER JOIN (
								SELECT [a0].[Id]
									,[a0].[Name]
									,[a0].[PublicHashedId]
								FROM [AccountLegalEntities] AS [a0]
								WHERE [a0].[Deleted] IS NULL
								) AS [t] ON [c].[AccountLegalEntityId] = [t].[Id]
							INNER JOIN [Providers] AS [p] ON [c].[ProviderId] = [p].[UkPrn]
							WHERE ([c].[IsDeleted] = CAST(0 AS BIT))
								AND [c].IsDraft = 0
							AND [c].WithParty = 1
								AND (
									(([c].[EmployerAccountId] = {employerAccountId}))
									AND (
										([c].[EditStatus] <> CAST(0 AS SMALLINT))
										OR (
											([c].[TransferSenderId] IS NOT NULL)
											AND ([c].[TransferApprovalStatus] = CAST(0 AS TINYINT))
											)
										)
									)
							)
							SELECT COUNT(*) AS TotalCohorts
							FROM CohortsFiltered;
							";

            return (int)GetDataAsObject(query);
        }



        public void UpdateEmailForApprenticeshipRecord(string email, long apprenticeshipid) => ExecuteSqlCommand($"UPDATE [Apprenticeship] SET Email = '{email}' WHERE Id = {apprenticeshipid}");

        public void ResetEmailForApprenticeshipRecord(string email) => ExecuteSqlCommand($"UPDATE [Apprenticeship] SET Email = NULL, EmailAddressConfirmed = NULL WHERE Email = '{email}'");

    }
}
