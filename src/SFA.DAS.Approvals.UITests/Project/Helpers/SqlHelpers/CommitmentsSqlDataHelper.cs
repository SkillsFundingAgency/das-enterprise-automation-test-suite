using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class CommitmentsSqlDataHelper : SqlDbHelper
    {
        public CommitmentsSqlDataHelper(DbConfig dBConfig) : base(dBConfig.CommitmentsDbConnectionString) { }

        public (string apprenticeshipid, string dob, string fname, string lname, string startDate, string trainningName, string uln, string ukprn) GetDataFromComtDb(string accountid)
        {
            var query = @$"select top 1 a.Id, a.DateOfBirth, a.FirstName, a.LastName, a.StartDate, a.TrainingName, a.ULN, c.ProviderId from dbo.Apprenticeship a
                            JOIN dbo.Commitment c on a.CommitmentId = c.Id where EmployerAccountId = {accountid}";

            var data = GetData(query);

            return (data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7]);
        }

        public void SetHasHadDataLockSuccessTrue(string uln)
        {
            if (uln.Equals(null))
            {
                throw new Exception("ULN is not set");
            }
            string sqlQueryToSetDataLockSuccessStatus = $"UPDATE Apprenticeship SET HasHadDataLockSuccess = 1 WHERE ULN = '{uln}'";

            ExecuteSqlCommand(sqlQueryToSetDataLockSuccessStatus);
        }

        public int GetApprenticeshipId(string uln) => Convert.ToInt32(TryGetDataAsObject($"SELECT Id from [dbo].[Apprenticeship] WHERE ULN = '{uln}' AND PaymentStatus >= 1"));

        public string GetNewcohortReference(string ULN)
        {
            waitForResults = true;

            string query = $@"SELECT Reference FROM Commitment cmt
                                INNER JOIN Apprenticeship app
                                ON cmt.id = app.CommitmentId
                                WHERE app.ULN = '{ULN}'
                                AND app.ContinuationOfId is not null
                                ORDER BY app.CreatedOn DESC";

            var data = GetData(query);
            return Convert.ToString(data[0]);
        }

        public string GetApprenticeshipULN(string reference)
        {
            string query = $@"SELECT top (1) ULN FROM Commitment cmt
                                INNER JOIN Apprenticeship app
                                ON cmt.id = app.CommitmentId
                                WHERE cmt.Reference = '{reference}'
                                ORDER BY app.CreatedOn DESC";

            return Convert.ToString(TryGetDataAsObject(query));
        }

        public int GetApprenticeshipCountFromULN(string ULN)
        {
            string query = $@"SELECT count(*) ID FROM Apprenticeship app
                                WHERE app.ULN = '{ULN}'";

            return Convert.ToInt32(TryGetDataAsObject(query));
        }

        public string GetNewcohortReferenceWithNoContinuation(string ULN, string title)
        {
            string query = $@"SELECT Reference FROM Commitment cmt
                                INNER JOIN Apprenticeship app
                                ON cmt.id = app.CommitmentId
                                WHERE app.ULN = '{ULN}'
                                AND app.ContinuationOfId is null
                                ORDER BY app.CreatedOn DESC";

            return Convert.ToString(TryGetDataAsObject(query));
        }

        public List<decimal> GetExistingApprentices(string cohortRef)
        {
            string query = $@"SELECT app.cost FROM Apprenticeship app
                                INNER JOIN Commitment cmt
                                ON cmt.id = app.CommitmentId
                                WHERE cmt.reference = '{cohortRef}'                                
                                ORDER BY app.CreatedOn DESC";

            return GetListOfDataAsObject(query).Select(c => (decimal)c[0]).ToList();
        }

        public int? GetProvidersDraftAndReadyForReviewCohortsCount(string ukprn)
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

            return Convert.ToInt32(base.GetDataAsObject(query));
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

            return GetDataAsObject(query);
        }

        public string GetProviderCohortWhichIsWithEmployer(int ukprn, int EmployerAccountId)
        {
            string query = $@"SELECT top (1) Reference
                                  FROM [dbo].[Commitment]
                                  Where ProviderId = {ukprn}
                                  And EmployerAccountId = {EmployerAccountId}
                                  AND IsDeleted = 0
                                  And WithParty = 1
                                  AND ChangeOfPartyRequestId is null
                                  Order by CreatedOn DESC";

            return GetDataAsObject(query);
        }

        public string GetProviderCohortWithChangeOfParty(int ukprn, int EmployerAccountId)
        {
            string query = $@"SELECT top (1) Reference
                                  FROM [dbo].[Commitment]
                                  Where ProviderId = {ukprn}
                                  And EmployerAccountId = {EmployerAccountId}
                                  AND IsDeleted = 0
                                  And WithParty = 2
                                  AND ChangeOfPartyRequestId is not null
                                  Order by CreatedOn DESC";

            return GetDataAsObject(query);
        }

        public string GetProviderCohortWithTransferSender(int ukprn)
        {
            string query = $@"SELECT top (1) Reference
                                  FROM [dbo].[Commitment]
                                  Where ProviderId = {ukprn}                                  
                                  AND IsDeleted = 0
                                  And WithParty = 4
                                  AND ChangeOfPartyRequestId is null
                                  AND TransferSenderId is not null
                                  AND TransferApprovalStatus is not null
                                  Order by CreatedOn DESC";

            return GetDataAsObject(query);
        }

        public string getPledgeApplicationId(string reference)
        {
            string query = $@"select PledgeApplicationId from  [dbo].[Commitment] " +
                $" where Reference = '{reference}'";

            return GetDataAsObject(query);
        }

        public (string apprenticeshipid, string dob, string fname, string lname, string startDate, string trainningName, string uln, string ukprn, string cost) GetLatestApprenticeshipForUln(string uln)
        {
            var query = @$"select top 1 a.Id, a.DateOfBirth, a.FirstName, a.LastName, a.StartDate, a.TrainingName, a.ULN, c.ProviderId, a.Cost from dbo.Apprenticeship a
                            JOIN dbo.Commitment c on a.CommitmentId = c.Id where ULN = {uln}
                            order by a.Id desc";

            var data = GetData(query);

            return (data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8]);
        }

        internal (int? status, int? resolutionType) GetOverlappingTrainingDateRequestDetailsForUln(string uln)
        {
            var query = $@"SELECT TOP (1) 
                              [Status]
                             ,[ResolutionType]
                          FROM [dbo].[OverlappingTrainingDateRequest] OLTD
                          Inner Join Apprenticeship A on OLTD.DraftApprenticeshipId = A.Id
                          Where ULN = '{uln}'
                          Order by OLTD.Id desc";

            var data = GetData(query);
            int? status = null;
            int? resolutionType = null;

            if (int.TryParse(data[0], out var statusCheck))
                status = statusCheck;
            if (int.TryParse(data[1], out var resolutionTypeCheck))
                resolutionType = resolutionTypeCheck;

            return (status, resolutionType);
        }

        public (string apprenticeshipid, string dob, string fname, string lname, string startDate, string trainningName, string uln, string ukprn, string cost) GetOverlappingTrainingDateRequest(string uln)
        {
            var query = @$"select top 1 a.Id, a.DateOfBirth, a.FirstName, a.LastName, a.StartDate, a.TrainingName, a.ULN, c.ProviderId, a.Cost from dbo.Apprenticeship a
                            JOIN dbo.Commitment c on a.CommitmentId = c.Id where ULN = {uln}
                            order by a.Id desc";

            var data = GetData(query);

            return (data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8]);
        }

        public (string isPilot, string trainingPrice, string endpointAssessmentPrice, string fromDate, string toDate, string cost) GetFlexiPaymentsCommitmentData (string uln)
        {
            var query = $"SELECT app.IsOnFlexiPaymentPilot, app.TrainingPrice, app.EndPointAssessmentPrice, pr.FromDate, pr.ToDate, pr.Cost " +
                $"FROM [dbo].[Apprenticeship] app " +
                $"JOIN [dbo].[PriceHistory] pr on app.Id = pr.ApprenticeshipId " +
                $"WHERE ULN = '{uln}'";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1], data[2], data[3], data[4], data[5]);
        }

        private new string GetDataAsObject(string queryToExecute) => Convert.ToString(base.GetDataAsObject(queryToExecute)).Trim();

        internal string GetCohortReferenceForDraftApprenitceship(string previousApprenticeshipCohortReference)
        {
            var query = @$"SELECT TOP(1) CAD.Reference
                           FROM[dbo].[OverlappingTrainingDateRequest] OLTD
                           Inner Join Apprenticeship Da on OLTD.DraftApprenticeshipId = Da.Id
                           Inner join Apprenticeship A on OLTD.PreviousApprenticeshipId = A.Id
                           Inner join Commitment CA on A.CommitmentId = CA.Id
                           Inner join Commitment CAD on Da.CommitmentId = CAD.Id
                           Where CA.Reference = '{previousApprenticeshipCohortReference}'
                           Order by OLTD.Id desc";

            var data = GetData(query);

            return data[0];
        }

        internal int UpdateApprentieshipStatusToCompleted(string uln)
        {
            var sql = @$"  Update Apprenticeship
                          set PaymentStatus = 4
                          , CompletionDate = '{DateTime.UtcNow.ToString("MM-dd-yyyy")}'
                          Where ULN = '{uln}'";

            var rowsEffected = ExecuteSqlCommand(sql);
            return rowsEffected;
        }
    }
}