using System;
using NUnit.Framework;
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

        public bool VerifyLearningRecordsExist()
        {
            query = $"SELECT COUNT(1) FROM [incentives].[Learner]";
            var count = FetchIntegerQueryData(0);

            return count > 1;
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
