using System;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class EarningsSqlDbHelper : SqlDbHelper
    {
        private static int _currentAcademicYear;

        public EarningsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.EarningsDbConnectionString)
        {
            _currentAcademicYear = AcademicYearDatesHelper.GetCurrentAcademicYear();
        }

        public (string monthlyOnProgramPayment, string totalOnProgramPayment, string numberOfDeliveryMonths) GetEarnings(string uln, bool waitForResults)
        {
            string query = $"SELECT TOP 1 Amount AS MonthlyOnProgramPayment, SUM(Amount) AS 'TotalOnProgramPayment', COUNT(DeliveryPeriod) AS 'NumberOfDeliveryMonths' " +
                $"FROM [Query].[Earning] " +
                $"WHERE Uln = '{uln}' " +
                $"GROUP BY Amount";

            this.waitForResults = waitForResults;

            var data = GetData(query);

            return (data[0], data[1], data[2]);
        }

        public (string totalEarnings, string levyEarnings, string nonLevyEarnings) GetApprenticeshipIndicativeEarnings(string ukprn)
        {
            string totalEarnings, levyEarnings, nonLevyEarnings;
            totalEarnings = levyEarnings = nonLevyEarnings = "0.00";

            string query = $" BEGIN TRANSACTION Earnings; " +
                $" DECLARE @Ukprn int = {ukprn} " +
                $" DECLARE @AcademicYear int = {_currentAcademicYear} " +
                $" SELECT A.TotalEarnings, B.LevyEarnings, C.NonLevyEarnings " +
                $" FROM " +
                $" ( " +
                $" SELECT Ukprn, SUM (Amount) as TotalEarnings FROM [Query].[Earning] " +
                $" WHERE UKPRN = @Ukprn AND AcademicYear = @AcademicYear " +
                $" GROUP BY UKPRN, AcademicYear " +
                $" ) A, " +
                $" ( " +
                $" SELECT Ukprn, SUM(Amount) as LevyEarnings FROM [Query].[Earning] " +
                $" WHERE UKPRN = @Ukprn AND AcademicYear = @AcademicYear AND AcademicYear = @AcademicYear AND FundingType in ('Levy','Transfer') " +
                $" GROUP BY UKPRN, AcademicYear " +
                $" ) B," +
                $" ( " +
                $" SELECT Ukprn, SUM(Amount) as NonLevyEarnings FROM [Query].[Earning] " +
                $" WHERE UKPRN = @Ukprn AND AcademicYear = @AcademicYear AND FundingType = 'NonLevy' GROUP BY UKPRN, AcademicYear " +
                $" )C " +
                $" WHERE A.Ukprn=B.Ukprn AND A.Ukprn=C.Ukprn " +
                $" COMMIT TRANSACTION;";

            var data = GetData(query);

            if (!string.IsNullOrWhiteSpace(data[0])) totalEarnings = string.Format("{0:n}", (double.Parse(data[0])));
            if (!string.IsNullOrWhiteSpace(data[1])) levyEarnings = string.Format("{0:n}", (double.Parse(data[1])));
            if (!string.IsNullOrWhiteSpace(data[2])) nonLevyEarnings = string.Format("{0:n}", (double.Parse(data[2])));

            return (totalEarnings, levyEarnings, nonLevyEarnings);
        }
    }
}
