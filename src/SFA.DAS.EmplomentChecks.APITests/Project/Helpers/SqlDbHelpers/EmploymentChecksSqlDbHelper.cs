using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmploymentChecksSqlDbHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;
        private int employmentCheckId;

        public EmploymentChecksSqlDbHelper(DbConfig dbConfig) : base(dbConfig.EmploymentCheckDbConnectionString) { _dbConfig = dbConfig; }

        public async Task<int> InsertData(string checkType, long uln, long accountId, DateTime minDate, DateTime maxDate)
        {

            // Insert a new EmploymentCheck record in DB and get its Id
            var now = DateTime.Now;

            var check = new EmploymentChecksDb
            {
                CorrelationId = Guid.NewGuid(),
                CheckType = checkType,
                Uln = uln,
                ApprenticeshipId = 100012,
                AccountId = accountId,
                MinDate = minDate,
                MaxDate = maxDate,
                Employed = null,
                CreatedOn = now,
                LastUpdatedOn = now
            };

            employmentCheckId = await SqlDatabaseConnectionHelper.Insert(check, _dbConfig.EmploymentCheckDbConnectionString);

            return employmentCheckId;
        }

        internal int GetEmploymentCheckCacheRequestId(int employmentStatus)
        {
            string query = $" select top(1) Id from [Cache].[EmploymentCheckCacheRequest] " +
                $" where ApprenticeEmploymentCheckId = {employmentCheckId} and Employed = {employmentStatus}";

            return Convert.ToInt32(GetDataAsString(query));
        }

        internal int? getEmploymentCheckStatus()
        {
            int count = 0;
            int i;

            string query = $" select RequestCompletionStatus from [Business].[EmploymentCheck] " +
                $" where Id = {employmentCheckId} ";

            string completionStatus = GetDataAsString(query);

            // Completion status [null] signifies that the record has not been processed yet.
            // give it a max of 10 seconds for it to be picked up by the orchestrator

            while (String.IsNullOrEmpty(completionStatus) && count < 5)
            {
                Thread.Sleep(2000);
                count++;

                completionStatus = GetDataAsString(query);
            }

            if (int.TryParse(completionStatus, out i)) return i;

            return null;
        }

        internal int GetCheckFromEmploymentCheckTable(string checkType)
        {
            string query = $"SELECT * from [Business].[EmploymentCheck] " +
                $" where CheckType = '{checkType}'";

            var queryResult = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            return queryResult.Count;
        }

        internal List<object[]> getHmrcRequestCompletionStatuses(int Id)
        {
            string query = $"select RequestCompletionStatus from [Cache].[EmploymentCheckCacheRequest] " +
                $" where ApprenticeEmploymentCheckId = {employmentCheckId} and Id > {Id}";

            List<object[]> completionStatuses = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            return completionStatuses;
        }

        internal int getHmrcRequestCompletionStatus(int Id)
        {
            string query = $"select RequestCompletionStatus from [Cache].[EmploymentCheckCacheRequest] " +
                $" where ApprenticeEmploymentCheckId = {employmentCheckId} and Id = {Id}";

            return Convert.ToInt16(GetDataAsString(query));
        }

        internal int getNumberOfHmrcCallsAfterId(int EmploymentCheckCacheRequestId)
        {
            string query = $" select COUNT(*) from[Cache].[EmploymentCheckCacheResponse] " +
                $" where ApprenticeEmploymentCheckId = {employmentCheckId} and EmploymentCheckCacheRequestId > {EmploymentCheckCacheRequestId} ";

            return Convert.ToInt16(GetDataAsString(query));
        }

        internal bool? VerifyEmploymentStatusAgainstPayeScheme(int numberOfPayeScheme)
        {
            int count = 0;
            bool? employed = null;

            string query = $"select top 1 * from " +
                $" (select top({numberOfPayeScheme}) employed from [Cache].[EmploymentCheckCacheResponse]" +
                $" where ApprenticeEmploymentCheckId = {employmentCheckId} " +
                $" order by Id desc) z";

            List<object[]> queryResult = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            while (queryResult.Count == 0 && count < 15)
            {
                Thread.Sleep(2000);
                count++;

                queryResult = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);
            }

            if (queryResult.Count == 0) return (null);

            if (bool.TryParse(queryResult[0][0].ToString(), out bool parsedEmploymentStatus)) employed = parsedEmploymentStatus;

            return employed;
        }

        public void DeleteEmploymentCheck(long uln, long accountId)
        {
            string query =
                $"DECLARE @Id bigint;" +
                $"SELECT top 1 @Id = [Id] FROM[Business].[EmploymentCheck]" +
                $"WHERE CheckType = 'EC_API' AND Uln = {uln} AND AccountId = {accountId};" +

                $"DELETE FROM [Business].[EmploymentCheck] WHERE Id = @Id;" +
                $"DELETE FROM [Cache].[AccountsResponse] WHERE ApprenticeEmploymentCheckId = @Id;" +
                $"DELETE FROM [Cache].[DataCollectionsResponse] WHERE ApprenticeEmploymentCheckId = @Id;" +
                $"DELETE FROM [Cache].[EmploymentCheckCacheRequest] WHERE ApprenticeEmploymentCheckId = @Id;" +
                $"DELETE FROM [Cache].[EmploymentCheckCacheResponse] WHERE ApprenticeEmploymentCheckId = @Id;";

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(query, _dbConfig.EmploymentCheckDbConnectionString);
        }

        internal void DeleteEmploymentCheck(string checkType)
        {
            string query = $"BEGIN TRAN " +
                $" DECLARE @Id bigint; " +
                $" SELECT top 1 @Id = [Id] FROM [Business].[EmploymentCheck] " +
                $" WHERE CheckType = '{checkType}'; " +
                $" DELETE FROM[Business].[EmploymentCheck] WHERE Id = @Id; " +
                $" DELETE FROM[Cache].[AccountsResponse] WHERE ApprenticeEmploymentCheckId = @Id; " +
                $" DELETE FROM[Cache].[DataCollectionsResponse] WHERE ApprenticeEmploymentCheckId = @Id; " +
                $" DELETE FROM[Cache].[EmploymentCheckCacheRequest] WHERE ApprenticeEmploymentCheckId = @Id; " +
                $" DELETE FROM[Cache].[EmploymentCheckCacheResponse] WHERE ApprenticeEmploymentCheckId = @Id; " +
                $" COMMIT";

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(query, _dbConfig.EmploymentCheckDbConnectionString);
        }

        public (string nino, string payeScheme) GetEnrichmentData()
        {
            int count = 0;

            string query = $"SELECT ar.PayeSchemes, dcr.NiNumber FROM [Cache].[AccountsResponse] ar " +
                $"INNER JOIN [Cache].[DataCollectionsResponse] dcr ON dcr.ApprenticeEmploymentCheckId = ar.ApprenticeEmploymentCheckId " +
                $"WHERE ar.ApprenticeEmploymentCheckId = {employmentCheckId}";

            List<object[]> enrichedData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            // count variable is added to stop the infinite loop incase CreateEmploymentCheckCacheRequestsOrchestrator has crashed
            while (enrichedData.Count == 0 && count < 15)
            {
                Thread.Sleep(2000);
                count++;

                enrichedData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);
            }

            if (enrichedData.Count == 0) return (null, null);

            var paye = enrichedData[0][0].ToString() == "" ? null : enrichedData[0][0].ToString().Trim(' ');
            var nino = enrichedData[0][1].ToString() == "" ? null : enrichedData[0][1].ToString().Trim(' ');

            return (nino, paye);
        }

        internal int GetNumberOfEmploymentCheckRequests()
        {
            string query = $"SELECT * FROM [Cache].[EmploymentCheckCacheRequest] WHERE ApprenticeEmploymentCheckId = {employmentCheckId}";

            var result = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            return result.Count;
        }

        public (bool? isEmployed, string returnCode, string returnMessage) GetEmploymentCheckResults()
        {
            int count = 0;

            string query = $"SELECT Employed, HttpStatusCode, HttpResponse FROM [Cache].[EmploymentCheckCacheResponse] WHERE ApprenticeEmploymentCheckId = {employmentCheckId}";

            List<object[]> result = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            // count variable is added to stop the infinite loop incase ProcessEmploymentCheckRequestsWithRateLimiterOrchestrator has crashed
            while (result.Count == 0 && count < 15)
            {
                Thread.Sleep(2000);
                count++;

                result = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);
            }

            if (result.Count == 0) return (null, null, null);

            bool? employed = null;

            if (bool.TryParse(result[0][0].ToString(), out bool parsedEmploymentStatus)) employed = parsedEmploymentStatus;

            return (employed, result[0][1].ToString() == "" ? null : result[0][1].ToString(), result[0][2].ToString());
        }

        internal List<object[]> getEmploymentCheckCacheRequestRows()
        {
            int count = 0;

            string query = $"SELECT PayeScheme from [Cache].[EmploymentCheckCacheRequest] where ApprenticeEmploymentCheckId = {employmentCheckId}";

            List<object[]> result = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            // count variable is added to stop the infinite loop incase CreateEmploymentCheckCacheRequestsOrchestrator has crashed
            while (result.Count == 0 && count < 15)
            {
                Thread.Sleep(2000);
                count++;

                result = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);
            }

            return result;
        }
    }
}
