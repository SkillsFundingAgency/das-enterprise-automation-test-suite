using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

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
                ULN = uln,
                ApprenticeshipId = 100012,
                UKPRN = 100000001,
                AccountId = accountId,
                MinDate = minDate,
                MaxDate = maxDate,
                CheckType = "EC_API",
                IsEmployed = null,
                HasBeenChecked = false,
                CreatedDate = now,
                LastUpdated = now
            };

            employmentCheckId = await SqlDatabaseConnectionHelper.Insert(check, _dbConfig.EmploymentCheckDbConnectionString);

            return employmentCheckId;
        }

        public void DeleteEmploymentCheck(long uln, long accountId)
        {
            string query =
                $"DELETE FROM [dbo].[EmploymentChecks] WHERE ULN = {uln} AND AccountId = {accountId} AND CheckType = 'EC_API'" +
                $"DELETE FROM [dbo].[ApprenticeEmploymentCheckMessageQueueHistory] WHERE [Uln] = {uln}";

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(query, _dbConfig.EmploymentCheckDbConnectionString);
        }

        public (string? nino, string? payeScheme) GetEnrichmentData()
        {
            string query = $"SELECT NationalInsuranceNumber, PayeScheme FROM [dbo].[ApprenticeEmploymentCheckMessageQueueHistory] WHERE EmploymentCheckId = {employmentCheckId}";

            List<object[]> enrichedData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);

            while (enrichedData.Count == 0)
            {
                Thread.Sleep(2000);

                enrichedData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);
            }

            var nino = enrichedData[0][0].ToString() == "" ? null : enrichedData[0][0].ToString();
            var paye = enrichedData[0][1].ToString() == "" ? null : enrichedData[0][1].ToString();

            return (nino, paye);

        }

        public (bool hasBeenChecked, string? isEmployed, string? returnCode, string returnMessage) GetEmploymentCheckResults()
        {
            string query = $"SELECT HasBeenChecked, IsEmployed, ReturnCode, ReturnMessage FROM [dbo].[EmploymentChecks] WHERE Id = {employmentCheckId}";

            List<object[]> result = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, _dbConfig.EmploymentCheckDbConnectionString);


            return ((bool)result[0][0], result[0][1].ToString() == "" ? null : result[0][1].ToString(), 
                result[0][2].ToString() == "" ? null : result[0][2].ToString(), result[0][3].ToString());

        }
    }
}
