using System;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class EarningsSqlDbHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public EarningsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.EarningsDbConnectionString) { _dbConfig = dbConfig; }

        public (string totalOnProgramPayment, string monthlyOnProgramPayment, string numberOfDeliveryMonths) GetEarnings (string uln)
        {
            string query = $"SELECT TOP 1 Amount AS MonthlyOnProgramPayment, SUM(Amount) AS 'TotalOnProgramPayment', COUNT(DeliveryPeriod) AS 'NumberOfDeliveryMonths' " +
                $"FROM [Query].[Earning] " +
                $"WHERE Uln = '{uln}' " +
                $"GROUP BY Amount";

            var data = GetData(query);

            return (data[0], data[1], data[2]);
        }
    }
}
