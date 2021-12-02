using System;
using System.Collections.Generic;
using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EISqlHelper : SqlDbHelper
    {
        int actualAmount, expectedAmount, actualPeriodNumber, expectedPeriodNumber, actualPaymentYear, expectedPaymentYear, startMonth, startYear;
        string actualDueDate, expectedDueDate, actualEarningType, expectedEarningType, query;

        public EISqlHelper(DbConfig dbConfig) : base(dbConfig.IncentivesDbConnectionString) { }

        public void DeleteIncentiveApplication(string accountId)
        {
            TryExecuteSqlCommand(FileHelper.GetSql("DeleteIncentiveApplication"), connectionString, new Dictionary<string, string> { { "@accountid", accountId } });

            SetCaseDetailsToNull(accountId);
        }

        internal void SetSignedAgreementVersion(string accountId) => ExecuteSqlCommand($"Update dbo.Accounts set SignedAgreementVersion = 7 where id = {accountId}");

        public void ResetPeriodEndInProgress()
        {
            query = "UPDATE incentives.CollectionCalendar SET PeriodEndInProgress = 0";
            ExecuteSqlCommand(query);
        }

        public void VerifyEarningData(string email, int startMonth, int startYear, string ageCategory)
        {
            this.startMonth = startMonth; this.startYear = startYear;
            query = $"SELECT accountId FROM [dbo].[IncentiveApplication] WHERE SubmittedByEmail = '{email}'";
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

        public void SetCaseDetailsToNull(string accountId)
        {
            var nullValue = "NULL";
            ExecuteSqlCommand($"UPDATE [dbo].[Accounts] SET VrfVendorId = {nullValue}, VrfCaseId = {nullValue}, VrfCaseStatus = {nullValue}, VrfCaseStatusLastUpdatedDateTime = {nullValue} WHERE Id = {accountId}");
        }

        public void SetCaseDetailsToCompleted(string email)
        {
            var accountId = FetchAccountId(email);
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            ExecuteSqlCommand($"UPDATE [dbo].[Accounts] SET VrfVendorId = 'P{accountId}', VrfCaseId = 'AF{accountId}', VrfCaseStatus = 'Case Request completed', VrfCaseStatusLastUpdatedDateTime = '{dateTime}' WHERE Id = {accountId}");
        }

        public int FetchAccountId(string email)
        {
            query = $"SELECT AccountId FROM [dbo].[IncentiveApplication] WHERE SubmittedByEmail = '{email}'";
            return FetchIntegerQueryData(0);
        }

        private void FetchActualQueryDataFromPaymentsTable(int accountId, string expectedEarningType)
        {
            var searchOrder = expectedEarningType.Equals("FirstPayment") ? "asc" : "desc";
            query = $"SELECT DueDate, Amount, PeriodNumber, PaymentYear, EarningType FROM [incentives].[PendingPayment] WHERE accountId = {accountId} order by CalculatedDate {searchOrder}";
            actualDueDate = DateTime.Parse(FetchStringQueryData(0)).ToString("yyyy-MM-dd");
            actualAmount = FetchIntegerQueryData(1);
            actualPeriodNumber = FetchIntegerQueryData(2);
            actualPaymentYear = FetchIntegerQueryData(3);
            actualEarningType = FetchStringQueryData(4);
        }

        private void CalculateExpectedQueryData(string ageCategory, string expectedEarningType)
        {
            expectedDueDate = CalculatedDueDate(expectedEarningType);
            //expectedAmount = ageCategory.Equals("Aged16to24") ? 1000 : 750; --> This calc was for Phase 1 (£2000 for 24OrLess £1500 for 25OrOver)
            expectedAmount = 1500; //For Phase2 both age categories will be paid £3000, so first and second payment value to be £1500 (per EI-1057)

            query = $"SELECT TOP 1 Id FROM [incentives].[CollectionCalendar] WHERE CensusDate >= '{actualDueDate}' order by Id asc";
            var id = FetchIntegerQueryData(0);

            query = $" SELECT PeriodNumber, AcademicYear FROM [incentives].[CollectionCalendar] where Id = {id}";
            expectedPeriodNumber = FetchIntegerQueryData(0);
            expectedPaymentYear = FetchIntegerQueryData(1);
        }

        private string CalculatedDueDate(string expectedEarningType)
        {

            DateTime startDate = new DateTime(startYear, startMonth, 01);

            var monthDays = DateTime.DaysInMonth(startYear, startMonth);
            DateTime expectedDueDate = new DateTime(startYear, startMonth, monthDays);

            if (expectedEarningType.Equals("FirstPayment"))
            {
                var currentDate = DateTime.Now;

                if (startDate > new DateTime(currentDate.Year, currentDate.Month - 3, 01)) expectedDueDate = expectedDueDate.AddDays(89);
                else expectedDueDate = currentDate.AddDays(21);
            }
            else expectedDueDate = expectedDueDate.AddDays(364);

            return expectedDueDate.ToString("yyyy-MM-dd");
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
