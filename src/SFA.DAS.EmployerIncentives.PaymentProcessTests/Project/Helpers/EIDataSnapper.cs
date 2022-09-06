using System;
using Dapper.Contrib.Extensions;
using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class IEDataSnapper : IEIDataSnapper
    {
        private readonly string _connectionString;

        private IEDataSnapper(DbConfig config)
        {
            _connectionString = config.IncentivesDbConnectionString;
        }

        public async Task TakeDataSnapshot()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), $"EI_data_snapshot_{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.xlsx");

            await WriteToExcel(file);

            TestContext.AddTestAttachment(file);
        }

        private async Task WriteToExcel(string file)
        {
            await using var dbConnection = new SqlConnection(_connectionString);
            var excel = new ExcelDataWriter(file);

            await excel.TakeDataSnapshot(dbConnection.GetAll<IncentiveApplicationApprenticeship>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<ApprenticeshipIncentive>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<PendingPayment>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<PendingPaymentValidationResult>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<Learner>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<LearningPeriod>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<ApprenticeshipDaysInLearning>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<Payment>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<ClawbackPayment>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<ChangeOfCircumstance>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<ApprenticeshipBreakInLearning>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<ArchivedPendingPayment>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<ArchivedPayment>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<ArchivedPendingPaymentValidationResult>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<Models.EmploymentCheck>());
            await excel.TakeDataSnapshot(dbConnection.GetAll<EmploymentCheckArchive>());
        }

        public static IEIDataSnapper Create(DbConfig dbConfig)
        {
#if DEBUG
            return new LazyDataSnapper();
#else
            return new IEDataSnapper(dbConfig);
#endif
        }
    }

    public interface IEIDataSnapper
    {
        Task TakeDataSnapshot();
    }

    public class LazyDataSnapper : IEIDataSnapper
    {
        public Task TakeDataSnapshot()
        {
            return Task.CompletedTask;
        }
    }
}
