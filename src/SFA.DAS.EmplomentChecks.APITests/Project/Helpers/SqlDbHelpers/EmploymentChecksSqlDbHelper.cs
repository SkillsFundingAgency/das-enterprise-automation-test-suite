using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using System;
using System.Threading.Tasks;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmploymentChecksSqlDbHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public EmploymentChecksSqlDbHelper(DbConfig dbConfig) : base(dbConfig.EmploymentCheckDbConnectionString) { _dbConfig = dbConfig; }

        public async Task InsertData(string uln, string accountId, DateTime minDate, DateTime maxDate)
        {
            var now = DateTime.Now;

            var check = new EmploymentChecksDb
            {
                ULN = Convert.ToInt64(uln),
                ApprenticeshipId = 100012,
                UKPRN = 100000001,
                AccountId = Convert.ToInt64(accountId),
                MinDate = minDate,
                MaxDate = maxDate,
                CheckType = "StartDate+60",
                IsEmployed = null,
                HasBeenChecked = false,
                CreatedDate = now,
                LastUpdated = now
            };

            var checkId = await SqlDatabaseConnectionHelper.Insert(check, _dbConfig.EmploymentCheckDbConnectionString);
        }
    }
}
