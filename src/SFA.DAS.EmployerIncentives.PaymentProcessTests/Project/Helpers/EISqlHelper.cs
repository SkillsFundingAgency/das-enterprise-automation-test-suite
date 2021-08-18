using Dapper;
using Dapper.Contrib.Extensions;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EISqlHelper : SqlDbHelper
    {
        public EISqlHelper(DbConfig eIConfig) : base(eIConfig.IncentivesDbConnectionString) { }
        public string ConnectionString => connectionString;

        public List<T> GetAllFromDatabase<T>() where T : class
        {
            using var dbConnection = new SqlConnection(connectionString);
            return dbConnection.GetAll<T>().ToList();
        }

        public T GetFromDatabase<T>(Func<T, bool> predicate) where T : class
        {
            using var dbConnection = new SqlConnection(connectionString);
            return dbConnection.GetAll<T>().Single(predicate);
        }
        public T GetSingleOrDefaultFromDatabase<T>(Func<T, bool> predicate) where T : class
        {
            using var dbConnection = new SqlConnection(connectionString);
            return dbConnection.GetAll<T>().SingleOrDefault(predicate);
        }

        public async Task SetActiveCollectionPeriod(byte periodNumber, short academicYear)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync("UPDATE incentives.CollectionCalendar SET Active = 0");
            await dbConnection.ExecuteAsync("UPDATE incentives.CollectionCalendar SET Active = 1 WHERE AcademicYear = @academicYear AND PeriodNumber = @periodNumber", new { academicYear, periodNumber });
        }

        public async Task CreateIncentiveApplication(IncentiveApplication incentiveApplication)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.InsertAsync(incentiveApplication);
            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                await dbConnection.InsertAsync(apprenticeship);
            }
        }

        public async Task<bool> VerifyLearningRecordsExist(long apprenticeshipId)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            var count = await dbConnection.ExecuteScalarAsync<int>($"SELECT COUNT(1) FROM incentives.Learner WHERE ApprenticeshipId = @apprenticeshipId AND LearningFound = 1", new { apprenticeshipId });

            return count >= 1;
        }

        public async Task<bool> VerifyPaymentRecordsExist(Guid apprenticeshipIncentiveId, bool paymentsSent)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            var sql = $"SELECT COUNT(1) FROM incentives.Payment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId";
            if (paymentsSent)
            {
                sql = $"{sql} AND PaidDate IS NOT NULL AND VrfVendorId IS NOT NULL";
            }
            var count = await dbConnection.ExecuteScalarAsync<int>(sql, new { apprenticeshipIncentiveId });

            return count >= 1;
        }

        public async Task<Guid> GetApprenticeshipIncentiveIdWhenExists(Guid apprenticeshipId, TimeSpan? timeout)
        {
            using var cts = new CancellationTokenSource();
            if (timeout != null)
            {
                cts.CancelAfter(timeout.Value);
            }

            await using var dbConnection = new SqlConnection(connectionString);

            while (!cts.Token.IsCancellationRequested)
            {
                var apprenticeshipIncentiveId = await dbConnection.ExecuteScalarAsync<Guid>("SELECT Id FROM incentives.ApprenticeshipIncentive WHERE IncentiveApplicationApprenticeshipId = @apprenticeshipId", new { apprenticeshipId });
                if (apprenticeshipIncentiveId != Guid.Empty)
                {
                    return apprenticeshipIncentiveId;
                }

                await Task.Delay(TimeSpan.FromMilliseconds(100), cts.Token);
            }

            throw new Exception("Apprenticeship Incentive not found!");
        }

        public async Task WaitUntilEarningsExist(Guid apprenticeshipIncentiveId, TimeSpan? timeout)
        {
            using var cts = new CancellationTokenSource();
            if (timeout != null)
            {
                cts.CancelAfter(timeout.Value);
            }

            await using var dbConnection = new SqlConnection(connectionString);

            while (!cts.Token.IsCancellationRequested)
            {
                var count = await dbConnection.ExecuteScalarAsync<int>($"SELECT COUNT(1) FROM incentives.PendingPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });
                if (count == 2)
                {
                    return;
                }

                await Task.Delay(TimeSpan.FromMilliseconds(100), cts.Token);
            }

            throw new Exception("Earnings not found!");
        }

        public async Task CleanUpAccount(long accountId)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync("DELETE FROM Accounts WHERE Id = @accountId", new { accountId });
        }

        public async Task CreateAccount(long accountId, long accountLegalEntityId)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync(SqlScripts.UpsertAccount, new { accountId, accountLegalEntityId });
        }

        public async Task DeleteIncentiveData(long accountId, long apprenticeshipId)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync(SqlScripts.DeleteIncentiveData, new { accountId, apprenticeshipId });
        }

        public async Task DeleteApplicationData(Guid incentiveApplicationId)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync(SqlScripts.DeleteApplicationData, new { incentiveApplicationId });
        }

        public async Task ResetCalendar()
        {
            await using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync(SqlScripts.ResetCalendar);
        }

        public async Task DeleteAccount((long AccountId, long AccountLegalEntityId) account)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync(SqlScripts.DeleteAccount, new {account.AccountId, account.AccountLegalEntityId});
        }
    }
}
