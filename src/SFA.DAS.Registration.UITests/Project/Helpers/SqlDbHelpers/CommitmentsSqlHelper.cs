using System.Collections.Generic;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers.SqlDbHelpers
{
    public class CommitmentsSqlHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.CommitmentsDbConnectionString)
    {
        public (string trainingName, string traningDate) GetTrainingNameAndStartDate(string email)
        {
            Dictionary<string, string> sqlParameters = new()
            {
                { "@Email", email }
            };
            var query = "SELECT TrainingName, StartDate From Apprenticeship WHERE Email = @Email";
            var data = GetData(query, sqlParameters);
            return (data[0], data[1]);
        }

        public int GetNumberOfCohortsReadyToReview(string employerAccountId)
        {
            Dictionary<string, string> sqlParameters = new()
            {
                { "@EmployerAccountId", employerAccountId }
            };

            string query = @"WITH CohortsFiltered AS (
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
									(([c].[EmployerAccountId] = @EmployerAccountId))
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

            return (int)GetDataAsObject(query, sqlParameters);
        }

        public int GetNumberOfTransferRequestToReview(string employerAccountId)
        {
            Dictionary<string, string> sqlParameters = new()
            {
                { "@EmployerAccountId", employerAccountId }
            };

            string query = @"WITH TransferRequestsFiltered AS (
                                SELECT [t].Id
                                FROM [TransferRequest] AS [t]
                                    INNER JOIN
                                    (
                                        SELECT [c].[Id],
                                               [c].[EmployerAccountId],
                                               [c].[Reference],
                                               [c].[TransferSenderId]
                                        FROM [Commitment] AS [c]
                                        WHERE [c].[IsDeleted] = CAST(0 AS bit)
                                    ) AS [t0]
                                        ON [t].[CommitmentId] = [t0].[Id]
                                WHERE [t0].[TransferSenderId] = @EmployerAccountId
                                      and [t].Status = 0
                                )
                                SELECT COUNT(*) AS TotalRequests
                                FROM TransferRequestsFiltered;
							";

            return (int)GetDataAsObject(query, sqlParameters);
        }

        public int GetNumberOfApprenticesToReview(string employerAccountId)
        {
            Dictionary<string, string> sqlParameters = new()
            {
                { "@EmployerAccountId", employerAccountId }
            };

            string query = @"select COUNT(aup.Id)
                            from [dbo].[ApprenticeshipUpdate] aup
                                inner join [dbo].[Apprenticeship] app
                                    on app.Id = aup.ApprenticeshipId
                                inner join [dbo].[Commitment] comm
                                    on comm.Id = app.CommitmentId
                            where comm.EmployerAccountId = @EmployerAccountId
                                  AND aup.Status = 0
                                  AND aup.Originator = 1
							";

            return (int)GetDataAsObject(query, sqlParameters);
        }



        public void UpdateEmailForApprenticeshipRecord(string email, long apprenticeshipid) => ExecuteSqlCommand($"UPDATE [Apprenticeship] SET Email = '{email}' WHERE Id = {apprenticeshipid}");

        public void ResetEmailForApprenticeshipRecord(string email) => ExecuteSqlCommand($"UPDATE [Apprenticeship] SET Email = NULL, EmailAddressConfirmed = NULL WHERE Email = '{email}'");

    }
}
