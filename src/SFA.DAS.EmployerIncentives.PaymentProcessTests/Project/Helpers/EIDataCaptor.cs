using Dapper.Contrib.Extensions;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EIDataCaptor : IEIDataCaptor
    {
        private readonly string _connectionString;
        private EIDataCaptor(DbConfig config)
        {
            _connectionString = config.IncentivesDbConnectionString;
        }

        public async Task TakeDataSnapshot()
        {
            var fileName = $"c:/temp/ei_data_snapshot_{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.xlsx";

            await using var dbConnection = new SqlConnection(_connectionString);
            {
                var excel = new ExcelDataWriter(fileName);

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
            }
        }

        public static IEIDataCaptor Create(DbConfig dbConfig)
        {
#if DEBUG
            return new EIDataCaptor(dbConfig);
#else
            return new LazyDataCaptor();
#endif
        }
    }

    public interface IEIDataCaptor
    {
        Task TakeDataSnapshot();
    }

    public class LazyDataCaptor : IEIDataCaptor
    {
        public Task TakeDataSnapshot()
        {
            return Task.CompletedTask;
        }
    }
}
