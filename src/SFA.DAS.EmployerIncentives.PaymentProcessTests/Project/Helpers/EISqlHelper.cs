using Dapper;
using Dapper.Contrib.Extensions;
using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Excel;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EISqlHelper : SqlDbHelper
    {
        public EISqlHelper(DbConfig eIConfig) : base(eIConfig.IncentivesDbConnectionString) { }
        public string ConnectionString => connectionString;

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

        public async Task<bool> VerifyLearningRecordsExist(Guid apprenticeshipIncentiveId)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            var count = await dbConnection.ExecuteScalarAsync<int>($"SELECT COUNT(1) FROM incentives.Learner WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });

            return count >= 1;
        }

        public async Task<bool> VerifyPaymentRecordsExist(Guid apprenticeshipIncentiveId)
        {
            await using var dbConnection = new SqlConnection(connectionString);
            var count = await dbConnection.ExecuteScalarAsync<int>($"SELECT COUNT(1) FROM incentives.Payment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });

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

        public async Task TakeDataSnapshot()
        {
            var fileName = $"c:/temp/data_snapshot_{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.xlsx";
            var ci = new CultureInfo("en-GB");

            await using var dbConnection = new SqlConnection(connectionString);
            {
                using (FileStream fs = File.Create(fileName))
                {
                    ExcelWriter writer = null;
                    writer = new ExcelWriter(fs, "IncentiveApplication", ci, true);
                    await writer.WriteRecordsAsync(dbConnection.GetAll<IncentiveApplication>());

                    writer = new ExcelWriter(fs, "IncentiveApplicationApprtshp", ci, true);
                    await writer.WriteRecordsAsync(dbConnection.GetAll<IncentiveApplicationApprenticeship>());

                    await writer.DisposeAsync();
                }


                //await TakeDataSnapshot<IncentiveApplication>(dbConnection, fileName, nameof(IncentiveApplication));
                //await TakeDataSnapshot<IncentiveApplicationApprenticeship>(dbConnection, fileName, nameof(IncentiveApplicationApprenticeship));
                //await TakeDataSnapshot<PendingPayment>(dbConnection, fileName, nameof(PendingPayment));
                //await TakeDataSnapshot<Payment>(dbConnection, fileName);
                //await TakeDataSnapshot<PendingPaymentValidationResult>(dbConnection, fileName);
                //await TakeDataSnapshot<ClawbackPayment>(dbConnection, fileName);
            }
        }

        public async Task TakeDataSnapshot<T>(SqlConnection dbConnection, string fileName, string sheetName) where T : class
        {
            await using var writer = new ExcelWriter(fileName, sheetName, new CultureInfo("en-GB"));
            await writer.WriteRecordsAsync(dbConnection.GetAll<T>());
        }

        public async Task TakeDataSnapshot<T>(SqlConnection dbConnection, string fileName) where T : class
        {
            await using var writer = new ExcelWriter(fileName, nameof(T), new CultureInfo("en-GB"));
            await writer.WriteRecordsAsync(dbConnection.GetAll<T>());
        }
    }
}
