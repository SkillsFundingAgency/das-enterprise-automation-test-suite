using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using NUnit.Framework;
using SFA.DAS.EmployerIncentives.UITests.Models;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EISqlHelper : SqlDbHelper
    {
        int actualAmount, expectedAmount, actualPeriodNumber, expectedPeriodNumber, actualPaymentYear, expectedPaymentYear, startMonth, startYear;
        string actualDueDate, expectedDueDate, actualEarningType, expectedEarningType, query;

        public EISqlHelper(EIConfig eIConfig) : base(eIConfig.EI_IncentivesDbConnectionString) { }

        public void DeleteIncentiveApplication(string accountid)
        {
            var nullValue = "NULL";
            query =
                $"DELETE FROM[incentives].[Payment] WHERE AccountId = {accountid};" +
                $"DELETE FROM[incentives].[PendingPaymentValidationResult] WHERE PendingPaymentId in (SELECT Id FROM[incentives].[PendingPayment] where AccountId = {accountid});" +
                $"DELETE FROM [incentives].[PendingPayment] WHERE AccountId = {accountid};" +
                $"DELETE FROM [incentives].[ApprenticeshipIncentive] WHERE AccountId = {accountid};" +
                $"DELETE FROM [dbo].[IncentiveApplicationApprenticeship] WHERE IncentiveApplicationId IN (SELECT Id FROM IncentiveApplication WHERE AccountId = {accountid});" +
                $"DELETE FROM [dbo].[IncentiveApplication] WHERE AccountId = {accountid};" +
                $"UPDATE [dbo].[Accounts] SET VrfVendorId = {nullValue}, VrfCaseId = {nullValue}, VrfCaseStatus = {nullValue}, VrfCaseStatusLastUpdatedDateTime = {nullValue} WHERE Id = {accountid}";
            ExecuteSqlCommand(query);
        }

        public void VerifyEarningData(string email, int startMonth, int startYear, string ageCategory)
        {
            this.startMonth = startMonth; this.startYear = startYear;
            query = $"SELECT AccountId FROM [dbo].[IncentiveApplication] WHERE SubmittedByEmail = '{email}'";
            var accountId = FetchIntegerQueryData(0);

            expectedEarningType = "FirstPayment";
            FetchActualQueryDataFromPaymentsTable(accountId, expectedEarningType);
            CalculateExpectedQueryData(ageCategory, expectedEarningType);
            AssertQueryData();

            expectedEarningType = "SecondPayment";
            FetchActualQueryDataFromPaymentsTable(accountId, expectedEarningType);
            CalculateExpectedQueryData(ageCategory, expectedEarningType);
            AssertQueryData();
        }

        public async Task CreateAccount(long accountId, long accountLegalEntityId)
        {
            using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync("INSERT INTO Accounts (Id, AccountLegalEntityId, LegalEntityId, LegalEntityName, HasSignedIncentivesTerms, SignedAgreementVersion, VrfVendorId) VALUES (@accountId, @accountLegalEntityId, 123456, 'Test', 1, 5, 'ABC123')", new { accountId, accountLegalEntityId });
        }

        public async Task SetActiveCollectionPeriod(byte periodNumber, short academicYear)
        {
            using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync("UPDATE incentives.CollectionCalendar SET Active = 0");
            await dbConnection.ExecuteAsync("UPDATE incentives.CollectionCalendar SET Active = 1 WHERE AcademicYear = @academicYear AND PeriodNumber = @periodNumber", new { academicYear, periodNumber });
        }

        public async Task CreateIncentiveApplication(IncentiveApplication incentiveApplication)
        {
            using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.InsertAsync(incentiveApplication);
            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                await dbConnection.InsertAsync(apprenticeship);
            }
        }

        public async Task<bool> VerifyLearningRecordsExist(Guid apprenticeshipIncentiveId)
        {
            using var dbConnection = new SqlConnection(connectionString);
            var count = await dbConnection.ExecuteScalarAsync<int>($"SELECT COUNT(1) FROM incentives.Learner WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });

            return count >= 1;
        }

        public async Task<bool> VerifyPaymentRecordsExist(Guid apprenticeshipIncentiveId)
        {
            using var dbConnection = new SqlConnection(connectionString);
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

            using var dbConnection = new SqlConnection(connectionString);

            while (!cts.Token.IsCancellationRequested)
            {
                var apprenticeshipIncentiveId = await dbConnection.ExecuteScalarAsync<Guid>("SELECT Id FROM incentives.ApprenticeshipIncentive WHERE IncentiveApplicationApprenticeshipId = @apprenticeshipId", new { apprenticeshipId });
                if (apprenticeshipIncentiveId != Guid.Empty)
                {
                    return apprenticeshipIncentiveId;
                }

                await Task.Delay(TimeSpan.FromMilliseconds(100));
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

            using var dbConnection = new SqlConnection(connectionString);

            while (!cts.Token.IsCancellationRequested)
            {
                var count = await dbConnection.ExecuteScalarAsync<int>($"SELECT COUNT(1) FROM incentives.PendingPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });
                if(count == 2)
                {
                    return;
                }

                await Task.Delay(TimeSpan.FromMilliseconds(100));
            }

            throw new Exception("Earnings not found!");
        }

        public async Task CleanUpAccount(long accountId)
        {
            using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync("DELETE FROM Accounts WHERE Id = @accountId", new { accountId });
        }

        public async Task CleanUpApprenticeshipIncentive(Guid apprenticeshipIncentiveId)
        {
            using var dbConnection = new SqlConnection(connectionString);
            await dbConnection.ExecuteAsync("DELETE FROM incentives.PendingPaymentValidationResult WHERE PendingPaymentId IN (SELECT Id FROM incentives.PendingPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId)", new { apprenticeshipIncentiveId });
            await dbConnection.ExecuteAsync("DELETE FROM incentives.Payment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });
            await dbConnection.ExecuteAsync("DELETE FROM incentives.ApprenticeshipDaysInLearning WHERE LearnerId IN (SELECT Id FROM incentives.Learner WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId)", new { apprenticeshipIncentiveId });
            await dbConnection.ExecuteAsync("DELETE FROM incentives.LearningPeriod WHERE LearnerId IN (SELECT Id FROM incentives.Learner WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId)", new { apprenticeshipIncentiveId });
            await dbConnection.ExecuteAsync("DELETE FROM incentives.Learner WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });
            await dbConnection.ExecuteAsync("DELETE FROM incentives.PendingPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });
            await dbConnection.ExecuteAsync("DELETE FROM incentives.ApprenticeshipIncentive WHERE Id = @apprenticeshipIncentiveId", new { apprenticeshipIncentiveId });
        }

        public async Task CleanUpIncentiveApplication(IncentiveApplication incentiveApplication)
        {
            using var dbConnection = new SqlConnection(connectionString);
            foreach (var apprenticeship in incentiveApplication.Apprenticeships)
            {
                await dbConnection.DeleteAsync(apprenticeship);
            }
            await dbConnection.DeleteAsync(incentiveApplication);
        }

        private void FetchActualQueryDataFromPaymentsTable(int accountId, string expectedEarningType)
        {
            var searchOrder = expectedEarningType.Equals("FirstPayment") ? "asc" : "desc";
            query = $"SELECT DueDate, Amount, PeriodNumber, PaymentYear, EarningType FROM [incentives].[PendingPayment] WHERE AccountId = {accountId} order by CalculatedDate {searchOrder}";
            actualDueDate = DateTime.Parse(FetchStringQueryData(0)).ToString("yyyy-MM-dd HH:mm:ss.fff");
            actualAmount = FetchIntegerQueryData(1);
            actualPeriodNumber = FetchIntegerQueryData(2);
            actualPaymentYear = FetchIntegerQueryData(3);
            actualEarningType = FetchStringQueryData(4);
        }

        private void CalculateExpectedQueryData(string ageCategory, string expectedEarningType)
        {
            expectedDueDate = CalculatedDueDate(expectedEarningType);
            expectedAmount = ageCategory.Equals("Aged16to24") ? 1000 : 750;

            query = $"SELECT TOP 1 Id FROM [incentives].[CollectionCalendar] WHERE CensusDate >= '{actualDueDate}' order by Id asc";
            var id = FetchIntegerQueryData(0);

            query = $" SELECT PeriodNumber, AcademicYear FROM [incentives].[CollectionCalendar] where Id = {id}";
            expectedPeriodNumber = FetchIntegerQueryData(0);
            expectedPaymentYear = FetchIntegerQueryData(1);
        }

        private string CalculatedDueDate(string expectedEarningType)
        {
            var monthDays = DateTime.DaysInMonth(startYear, startMonth);
            DateTime expectedDueDate;
            expectedDueDate = new DateTime(startYear, startMonth, monthDays);
            expectedDueDate = expectedEarningType.Equals("FirstPayment") ? expectedDueDate.AddDays(89) : expectedDueDate.AddDays(364);
            return expectedDueDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private void AssertQueryData()
        {
            Assert.AreEqual(expectedDueDate, actualDueDate, $"DueDate AssertionFailed. Expected: '{expectedDueDate}' Found: '{actualDueDate}'");
            Assert.AreEqual(expectedAmount, actualAmount, $"AmountDue AssertionFailed. Expected: '{expectedAmount}' Found: '{actualAmount}'");
            Assert.AreEqual(expectedPeriodNumber, actualPeriodNumber, $"PeriodNumber AssertionFailed. Expected: '{expectedPeriodNumber}' Found: '{actualPeriodNumber}'");
            Assert.AreEqual(expectedPaymentYear, actualPaymentYear, $"PaymentYear AssertionFailed. Expected: '{expectedPaymentYear}' Found: '{actualPaymentYear}'");
            Assert.AreEqual(expectedEarningType, actualEarningType, $"EarningType AssertionFailed. Expected: '{expectedEarningType}' Found: '{actualEarningType}'");
        }

        private int FetchIntegerQueryData(int columnIndex) => Convert.ToInt32(SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString)[0][columnIndex]);

        private string FetchStringQueryData(int columnIndex) => SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString)[0][columnIndex].ToString();
    }
}
