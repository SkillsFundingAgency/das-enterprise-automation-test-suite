using System;
using NUnit.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EISqlHelper : SqlDbHelper
    {
        int actualAmount, expectedAmount, actualPeriodNumber, expectedPeriodNumber, actualPaymentYear, expectedPaymentYear, startMonth, startYear;
        string actualDueDate, expectedDueDate, actualEarningType, expectedEarningType;

        public EISqlHelper(EIConfig eIConfig) : base(eIConfig.EI_IncentivesDbConnectionString) { }

        public void DeleteIncentiveApplication(string accountid)
        {
            var nullValue = "NULL";
            var query =
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
            var accountId = ExecuteSqlCommand($"SELECT AccountId FROM [dbo].[IncentiveApplication] WHERE SubmittedByEmail = '{email}'");

            expectedEarningType = "FirstPayment";
            CalculateExpectedData(ageCategory, expectedEarningType);
            FetchActualDataFromPaymentsTable(accountId, expectedEarningType);
            AssertData();

            expectedEarningType = "SecondPayment";
            CalculateExpectedData(ageCategory, expectedEarningType);
            FetchActualDataFromPaymentsTable(accountId, expectedEarningType);
            AssertData();
        }

        private void FetchActualDataFromPaymentsTable(int accountId, string expectedEarningType)
        {
            var searchOrder = expectedEarningType.Equals("FirstPayment") ? "asc" : "desc";
            List<object[]> pendingPaymentData = SqlDatabaseConnectionHelper.ReadDataFromDataBase($"SELECT DueDate, Amount, PeriodNumber, PaymentYear, EarningType FROM [incentives].[PendingPayment] WHERE AccountId = {accountId} order by CalculatedDate {searchOrder}", connectionString);
            actualDueDate = pendingPaymentData[0][0].ToString();
            actualAmount = Convert.ToInt32(pendingPaymentData[0][1]);
            actualPeriodNumber = Convert.ToInt32(pendingPaymentData[0][2]);
            actualPaymentYear = Convert.ToInt32(pendingPaymentData[0][3]);
            actualEarningType = pendingPaymentData[0][4].ToString();
        }

        private void CalculateExpectedData(string ageCategory, string expectedEarningType)
        {
            expectedDueDate = CalculatedDueDate(expectedEarningType);
            expectedAmount = ageCategory.Equals("Aged16to24") ? 1000 : 750;
            var id = ExecuteSqlCommand($"SELECT TOP 1 Id FROM [incentives].[CollectionCalendar] WHERE CensusDate >= {actualDueDate} order by Id asc");
            List<object[]> collectionCalendarData = SqlDatabaseConnectionHelper.ReadDataFromDataBase($" SELECT PeriodNumber, AcademicYear FROM [incentives].[CollectionCalendar] where Id = {id}", connectionString);
            expectedPeriodNumber = Convert.ToInt32(collectionCalendarData[0][0]);
            expectedPaymentYear = Convert.ToInt32(collectionCalendarData[0][1]);
        }

        private string CalculatedDueDate(string expectedEarningType)
        {
            var monthDays = DateTime.DaysInMonth(startYear, startMonth);
            DateTime expectedDueDate;
            expectedDueDate = new DateTime(startYear, startMonth, monthDays);
            expectedDueDate = expectedEarningType.Equals("FirstPayment") ? expectedDueDate.AddDays(89) : expectedDueDate.AddDays(364);
            return expectedDueDate.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        }

        private void AssertData()
        {
            Assert.AreEqual(expectedDueDate, actualDueDate, $"DueDate AssertionFailed. Expected: '{expectedDueDate}' Found: '{actualDueDate}'");
            Assert.AreEqual(expectedAmount, actualAmount, $"AmountDue AssertionFailed. Expected: '{expectedAmount}' Found: '{actualAmount}'");
            Assert.AreEqual(expectedPeriodNumber, actualPeriodNumber, $"PeriodNumber AssertionFailed. Expected: '{expectedPeriodNumber}' Found: '{actualPeriodNumber}'");
            Assert.AreEqual(expectedPaymentYear, actualPaymentYear, $"PaymentYear AssertionFailed. Expected: '{expectedPaymentYear}' Found: '{actualPaymentYear}'");
            Assert.AreEqual(expectedEarningType, actualEarningType, $"EarningType AssertionFailed. Expected: '{expectedEarningType}' Found: '{actualEarningType}'");
        }
    }
}
