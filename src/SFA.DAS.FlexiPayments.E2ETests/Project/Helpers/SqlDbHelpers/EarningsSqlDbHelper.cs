using System;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class EarningsSqlDbHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;
        private static int _currentAcademicYear;

        public EarningsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.EarningsDbConnectionString)
        {
            _dbConfig = dbConfig;
            _currentAcademicYear = AcademicYearDatesHelper.GetCurrentAcademicYear();
        }

        public (string monthlyOnProgramPayment, string totalOnProgramPayment, string numberOfDeliveryMonths) GetEarnings(string uln)
        {
            string query = $"SELECT TOP 1 Amount AS MonthlyOnProgramPayment, SUM(Amount) AS 'TotalOnProgramPayment', COUNT(DeliveryPeriod) AS 'NumberOfDeliveryMonths' " +
                $"FROM [Query].[Earning] " +
                $"WHERE Uln = '{uln}' " +
                $"GROUP BY Amount";

            var data = GetData(query);

            return (data[0], data[1], data[2]);
        }

        public (string totalEarnings, string levyEarnings, string nonLevyEarnings) GetEarningsByFundingType(string ukprn)
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
                $" WHERE UKPRN = @Ukprn AND AcademicYear = @AcademicYear AND AcademicYear = @AcademicYear AND FundingType in (0,2) " +
                $" GROUP BY UKPRN, AcademicYear " +
                $" ) B," +
                $" ( " +
                $" SELECT Ukprn, SUM(Amount) as NonLevyEarnings FROM [Query].[Earning] " +
                $" WHERE UKPRN = @Ukprn AND AcademicYear = @AcademicYear AND FundingType = 1 GROUP BY UKPRN, AcademicYear " +
                $" )C " +
                $" WHERE A.Ukprn=B.Ukprn AND A.Ukprn=C.Ukprn " +
                $" COMMIT TRANSACTION;";

            var data = GetData(query);

            if (!String.IsNullOrWhiteSpace(data[0])) totalEarnings = String.Format("{0:n}", (double.Parse(data[0])));
            if (!String.IsNullOrWhiteSpace(data[1])) levyEarnings = String.Format("{0:n}", (double.Parse(data[1])));
            if (!String.IsNullOrWhiteSpace(data[2])) nonLevyEarnings = String.Format("{0:n}", (double.Parse(data[2])));

            return (totalEarnings, levyEarnings, nonLevyEarnings);
        }
    }
}
