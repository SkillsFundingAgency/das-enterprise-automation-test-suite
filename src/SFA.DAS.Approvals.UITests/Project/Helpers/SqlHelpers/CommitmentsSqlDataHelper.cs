using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class CommitmentsSqlDataHelper : SqlDbHelper
    {
        public CommitmentsSqlDataHelper(DbConfig dBConfig) : base(dBConfig.CommitmentsDbConnectionString) { }

        public void SetHasHadDataLockSuccessTrue(string uln)
        {
            if (uln.Equals(null))
            {
                throw new Exception("ULN is not set");
            }
            string sqlQueryToSetDataLockSuccessStatus = $"UPDATE Apprenticeship SET HasHadDataLockSuccess = 1 WHERE ULN = '{uln}'";

            ExecuteSqlCommand(sqlQueryToSetDataLockSuccessStatus);
        }

        public int GetApprenticeshipId(string uln) => Convert.ToInt32(GetDataAsObject($"SELECT Id from [dbo].[Apprenticeship] WHERE ULN = '{uln}' AND PaymentStatus >= 1"));

        public string GetNewcohortReference(string ULN, string title)
        {
            string query = $@"SELECT Reference FROM Commitment cmt
                                INNER JOIN Apprenticeship app
                                ON cmt.id = app.CommitmentId
                                WHERE app.ULN = '{ULN}'
                                AND app.ContinuationOfId is not null
                                ORDER BY app.CreatedOn DESC";

            return Convert.ToString(TryGetDataAsObject(query, "Index was out of range", title));
        }

        public int? GetProvidersDraftAndReadyForReviewCohortsCount(int ukprn)
        {
            string query = $@"SELECT Count(Reference)
                                FROM [Commitment] AS [cmt]
                                INNER JOIN (
                                    SELECT [ale].*
                                    FROM [AccountLegalEntities] AS [ale]
                                    WHERE [ale].[Deleted] IS NULL
                                            ) AS [t] ON [cmt].[AccountLegalEntityId] = [t].[Id]
                                Where ProviderId = {ukprn}
                                AND cmt.IsDeleted = 0
                                AND cmt.EditStatus = 2
                                And cmt.WithParty = 2
                                AND cmt.ChangeOfPartyRequestId is null";

            return Convert.ToInt32(GetDataAsObject(query));
        }

        public string GetOldestEditableCohortReference(int ukprn, int EmployerAccountId)
        {
            string query = $@"SELECT top (1) Reference
                                  FROM [dbo].[Commitment]
                                  Where ProviderId = {ukprn}
                                  And EmployerAccountId = {EmployerAccountId}
                                  AND IsDeleted = 0
                                  And WithParty = 2
                                  AND ChangeOfPartyRequestId is null
                                  Order by CreatedOn ASC";

            return Convert.ToString(GetDataAsObject(query)).Trim();
        }
    }
}
