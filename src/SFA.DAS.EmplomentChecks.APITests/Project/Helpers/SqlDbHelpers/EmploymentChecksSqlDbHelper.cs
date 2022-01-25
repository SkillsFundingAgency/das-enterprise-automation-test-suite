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

        public async Task<int> InsertData(long uln, long accountId, DateTime minDate, DateTime maxDate)
        {
            // 1. Delete any historic record created from previous runs
            DeleteEmploymentCheck(uln, accountId);

            // 2. Insert a new EmploymentCheck record in DB and get its Id
            var now = DateTime.Now; 

            var check = new EmploymentChecksDb
            {
                CorrelationId = Guid.NewGuid(),
                CheckType = "EC_API",
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

        public (string nino, string payeScheme) GetEnrichmentData()
        {
            string query = $"SELECT ar.PayeSchemes, dcr.NiNumber FROM [Cache].[AccountsResponse] ar " +
                $"INNER JOIN [Cache].[DataCollectionsResponse] dcr ON dcr.ApprenticeEmploymentCheckId = ar.ApprenticeEmploymentCheckId " +
                $"WHERE ar.ApprenticeEmploymentCheckId = {employmentCheckId}";

            List<object[]> enrichedData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            while (enrichedData.Count == 0)
            {
                Thread.Sleep(2000);

                enrichedData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);
            }

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
            string query = $"SELECT Employed, HttpStatusCode, HttpResponse FROM [Cache].[EmploymentCheckCacheResponse] WHERE ApprenticeEmploymentCheckId = {employmentCheckId}";

            List<object[]> result = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            while (result.Count == 0)
            {
                Thread.Sleep(2000);

                result = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);
            }

            bool? employed = null;

            if (bool.TryParse(result[0][0].ToString(), out bool parsedEmploymentStatus)) employed = parsedEmploymentStatus;

            return (employed, result[0][1].ToString() == "" ? null : result[0][1].ToString(), result[0][2].ToString());

        }
    }
}
