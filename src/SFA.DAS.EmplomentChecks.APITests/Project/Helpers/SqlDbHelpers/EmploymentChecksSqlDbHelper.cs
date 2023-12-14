using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;

public class EmploymentChecksSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.EmploymentCheckDbConnectionString)
{
    private int employmentCheckId;
    private Guid correlationId;

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

        employmentCheckId = await DapperSqlHelper.Insert(check, connectionString);

        return employmentCheckId;
    }

    internal async Task InsertData(EmploymentChecksDb record)
    {
        await DapperSqlHelper.Insert(record, connectionString);
    }

    internal void InsertEmploymentCheckRecordWithNino(long uln, string nino, long accountId, string checkType)
    {
        var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        correlationId = Guid.NewGuid();

        string query = $"BEGIN TRAN " +
            $" INSERT INTO [Business].[EmploymentCheck] " +
            $" ([CorrelationId], [CheckType], [Uln], [ApprenticeshipId], [AccountId], [MinDate], [MaxDate], [CreatedOn]) " +
            $" VALUES " +
            $" ('{correlationId}', '{checkType}', {uln}, 456, {accountId}, '2020-01-01', '2020-01-31', '{now}')" +
            $" INSERT INTO [Cache].[DataCollectionsResponse] " +
            $" ([ApprenticeEmploymentCheckId], [CorrelationId], [Uln], [NiNumber], [CreatedOn]) " +
            $" SELECT top 1 ec.id, ec.CorrelationId, ec.uln, '{nino}', '{now}' " +
            $" FROM [Business].[EmploymentCheck] ec " +
            $" where ec.uln = {uln} and ec.CheckType = '{checkType}' " +
            $" order by CreatedOn desc " +
            $" COMMIT";

        ExecuteSqlCommand(query);
    }

    internal string GetErrorTypeFromEmploymentCheckTable()
    {
        string query = $"select ErrorType from [Business].[EmploymentCheck] where Id = {employmentCheckId}";

        return GetDataAsString(query);

    }

    internal int GetCountFromDataCollectionResponse(long uln)
    {
        string query = $" SELECT COUNT(*) FROM [Cache].[DataCollectionsResponse] " +
            $" WHERE CorrelationId = '{correlationId}' AND Uln = '{uln}'";

        Thread.Sleep(10000);

        return int.Parse(GetDataAsString(query));
    }

    internal int GetEmploymentCheckCacheRequestId(int employmentStatus)
    {
        string query = $" select top(1) Id from [Cache].[EmploymentCheckCacheRequest] " +
            $" where ApprenticeEmploymentCheckId = {employmentCheckId} and Employed = {employmentStatus}";

        return Convert.ToInt32(GetDataAsString(query));
    }

    internal int? GetEmploymentCheckStatusWithId()
    {
        int count = 0;

        string query = $" select RequestCompletionStatus from [Business].[EmploymentCheck] " +
            $" where Id = {employmentCheckId} ";

        string completionStatus = GetDataAsString(query);

        // Completion status [null] signifies that the record has not been processed yet.
        // give it a max of 10 seconds for it to be picked up by the orchestrator

        while (string.IsNullOrEmpty(completionStatus) && count < 5)
        {
            Thread.Sleep(2000);
            count++;

            completionStatus = GetDataAsString(query);
        }

        if (int.TryParse(completionStatus, out int i)) return i;

        return null;
    }

    internal int? GetEmploymentCheckStatusWithCorrelationId()
    {
        int count = 0;

        string query = $" select RequestCompletionStatus from [Business].[EmploymentCheck] " +
            $" where CorrelationId = '{correlationId}' ";

        string completionStatus = GetDataAsString(query);

        // Completion status [null] signifies that the record has not been processed yet.
        // give it a max of 10 seconds for it to be picked up by the orchestrator

        while (string.IsNullOrEmpty(completionStatus) && count < 10)
        {
            Thread.Sleep(2000);
            count++;

            completionStatus = GetDataAsString(query);
        }

        if (int.TryParse(completionStatus, out int i)) return i;

        return null;
    }

    internal int GetCheckFromEmploymentCheckTable(string checkType)
    {
        string query = $"SELECT * from [Business].[EmploymentCheck] " +
            $" where CheckType = '{checkType}' and CreatedOn >= DATEADD(SECOND,-20,GETDATE())";

        var queryResult = GetListOfData(query);

        return queryResult.Count;
    }

    internal List<object[]> GetHmrcRequestCompletionStatuses(int Id)
    {
        string query = $"select RequestCompletionStatus from [Cache].[EmploymentCheckCacheRequest] " +
            $" where ApprenticeEmploymentCheckId = {employmentCheckId} and Id > {Id}";

        List<object[]> completionStatuses = GetListOfData(query);

        return completionStatuses;
    }

    internal int GetHmrcRequestCompletionStatus(int Id)
    {
        string query = $"select RequestCompletionStatus from [Cache].[EmploymentCheckCacheRequest] " +
            $" where ApprenticeEmploymentCheckId = {employmentCheckId} and Id = {Id}";

        return Convert.ToInt16(GetDataAsString(query));
    }

    internal int GetNumberOfHmrcCallsAfterId(int EmploymentCheckCacheRequestId)
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

        List<object[]> queryResult = GetListOfData(query);

        while (queryResult.Count == 0 && count < 15)
        {
            Thread.Sleep(2000);
            count++;

            queryResult = GetListOfData(query);
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

        ExecuteSqlCommand(query);
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

        ExecuteSqlCommand(query);
    }

    public (string nino, string payeScheme) GetEnrichmentData()
    {
        int count = 0;

        string query = $"SELECT ar.PayeSchemes, dcr.NiNumber FROM [Cache].[AccountsResponse] ar " +
            $"INNER JOIN [Cache].[DataCollectionsResponse] dcr ON dcr.ApprenticeEmploymentCheckId = ar.ApprenticeEmploymentCheckId " +
            $"WHERE ar.ApprenticeEmploymentCheckId = {employmentCheckId}";

        List<object[]> enrichedData = GetListOfData(query);

        // count variable is added to stop the infinite loop incase CreateEmploymentCheckCacheRequestsOrchestrator has crashed
        while (enrichedData.Count == 0 && count < 15)
        {
            Thread.Sleep(2000);
            count++;

            enrichedData = GetListOfData(query);
        }

        if (enrichedData.Count == 0) return (null, null);

        var paye = enrichedData[0][0].ToString() == "" ? null : enrichedData[0][0].ToString().Trim(' ');
        var nino = enrichedData[0][1].ToString() == "" ? null : enrichedData[0][1].ToString().Trim(' ');

        return (nino, paye);
    }

    internal int GetNumberOfEmploymentCheckRequests()
    {
        string query = $"SELECT * FROM [Cache].[EmploymentCheckCacheRequest] WHERE ApprenticeEmploymentCheckId = {employmentCheckId}";

        var result = GetListOfData(query);

        return result.Count;
    }

    public (bool? isEmployed, string returnCode, string returnMessage) GetEmploymentCheckResults()
    {
        int count = 0;

        string query = $"SELECT Employed, HttpStatusCode, HttpResponse FROM [Cache].[EmploymentCheckCacheResponse] WHERE ApprenticeEmploymentCheckId = {employmentCheckId}";

        List<object[]> result = GetListOfData(query);

        // count variable is added to stop the infinite loop incase ProcessEmploymentCheckRequestsWithRateLimiterOrchestrator has crashed
        while (result.Count == 0 && count < 20)
        {
            Thread.Sleep(2000);
            count++;

            result = GetListOfData(query);
        }

        if (result.Count == 0) return (null, null, null);

        bool? employed = null;

        if (bool.TryParse(result[0][0].ToString(), out bool parsedEmploymentStatus)) employed = parsedEmploymentStatus;

        return (employed, result[0][1].ToString() == "" ? null : result[0][1].ToString(), result[0][2].ToString());
    }

    internal List<object[]> GetRelatedsPayeFromEmploymentCheckCacheRequestRows()
    {
        int count = 0;

        string query = $"SELECT PayeScheme from [Cache].[EmploymentCheckCacheRequest] where ApprenticeEmploymentCheckId = {employmentCheckId}";

        List<object[]> result = GetListOfData(query);

        // count variable is added to stop the infinite loop incase CreateEmploymentCheckCacheRequestsOrchestrator has crashed
        while (result.Count == 0 && count < 15)
        {
            Thread.Sleep(2000);
            count++;

            result = GetListOfData(query);
        }

        return result;
    }

    internal List<object[]> GetEmploymentCheckCacheRequestRows()
    {
        int count = 0;

        string query = $" SELECT * from [Cache].[EmploymentCheckCacheRequest] where CorrelationId = '{correlationId}' ";

        List<object[]> result = GetListOfData(query);

        // count variable is added to stop the infinite loop incase CreateEmploymentCheckCacheRequestsOrchestrator has crashed
        while (result.Count == 0 && count < 15)
        {
            Thread.Sleep(2000);
            count++;

            result = GetListOfData(query);
        }

        return result;
    }

    public async Task<EmploymentChecksDb> Get(int id)
    {
        return await DapperSqlHelper.Get<EmploymentChecksDb>(id, connectionString);
    }
}
