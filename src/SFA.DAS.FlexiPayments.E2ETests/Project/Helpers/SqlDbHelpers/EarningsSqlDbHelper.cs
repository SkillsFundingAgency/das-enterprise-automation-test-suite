using System;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class EarningsSqlDbHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;
        private static DateTime _currentAcademicYearStartDate;

        public EarningsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.EarningsDbConnectionString) 
        { 
            _dbConfig = dbConfig;
            _currentAcademicYearStartDate = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();
        }

        public (string monthlyOnProgramPayment, string totalOnProgramPayment, string numberOfDeliveryMonths) GetEarnings (string uln)
        {
            string query = $"SELECT TOP 1 Amount AS MonthlyOnProgramPayment, SUM(Amount) AS 'TotalOnProgramPayment', COUNT(DeliveryPeriod) AS 'NumberOfDeliveryMonths' " +
                $"FROM [Query].[Earning] " +
                $"WHERE Uln = '{uln}' " +
                $"GROUP BY Amount";

            var data = GetData(query);

            return (data[0], data[1], data[2]);
        }

        public (string totalEarnings, string levyEarnings, string nonLevyEarnings) GetEarningsByFundingType(string uln)
        {
            string totalEarnings, levyEarnings, nonLevyEarnings;
            totalEarnings = levyEarnings = nonLevyEarnings = "0.00";

            string query = $" SELECT FundingType, SUM(Amount) AS 'Earnings' " +
                $" FROM [Query].[Earning] " +
                $" WHERE Ukprn = {uln} and AcademicYear= {GetAcademicYear()} and FundingType in (0,1,2) " +
                $" GROUP by FundingType";

            var data = GetMultipleData(query, _dbConfig.EarningsDbConnectionString);

            if (data == null) return (totalEarnings, levyEarnings, nonLevyEarnings);
            else
            {
                foreach (var item in data)
                {
                    if (item[0] == "0") levyEarnings = String.Format("{0:n}", (double.Parse(data[0][1])));

                    if (item[0] == "1") nonLevyEarnings = String.Format("{0:n}", (double.Parse(data[1][1])));

                    if (item[0] == "2") levyEarnings = String.Format("{0:n}", (double.Parse(levyEarnings) + double.Parse(data[2][1])));
                }
                totalEarnings = String.Format("{0:n}", (double.Parse(levyEarnings) + double.Parse(nonLevyEarnings)));

                return (totalEarnings, levyEarnings, nonLevyEarnings);
            }
        }

        public int GetAcademicYear() => Convert.ToInt32(_currentAcademicYearStartDate.ToString("yy") + _currentAcademicYearStartDate.AddYears(1).ToString("yy"));
    }
}
