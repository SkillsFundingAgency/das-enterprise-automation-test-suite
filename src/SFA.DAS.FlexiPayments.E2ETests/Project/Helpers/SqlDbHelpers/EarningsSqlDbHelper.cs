using System;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class EarningsSqlDbHelper : SqlDbHelper
    {
        private static int _currentAcademicYear;

        public EarningsSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.EarningsDbConnectionString)
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

        public (string totalEarnings, string levyEarnings, string nonLevyEarnings, string nonLevyGovernmentContribution, string nonLevyEmployerContribution) GetApprenticeshipIndicativeEarnings(string ukprn)
        {
            string totalEarnings, levyEarnings, nonLevyEarnings, nonLevyGovernmentContribution, nonLevyEmployerContribution;
            totalEarnings = levyEarnings = nonLevyEarnings = nonLevyGovernmentContribution = nonLevyEmployerContribution = "0.00";

            string query = $" BEGIN TRANSACTION Earnings; " +
                $" DECLARE @Ukprn int = {ukprn} " +
                $" DECLARE @AcademicYear int = {_currentAcademicYear} " +
                $" SELECT A.TotalEarnings, B.LevyEarnings, C.NonLevyEarnings, C.NonLevyGovernmentContribution, C.NonLevyEmployerContribution " +
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
                $" SELECT Ukprn, SUM(Amount) as NonLevyEarnings, SUM(Amount) * 0.95 as NonLevyGovernmentContribution, SUM(Amount) * 0.05 as NonLevyEmployerContribution " +
                $" FROM [Query].[Earning] " +
                $" WHERE UKPRN = @Ukprn AND AcademicYear = @AcademicYear AND FundingType = 'NonLevy' GROUP BY UKPRN, AcademicYear " +
                $" )C " +
                $" WHERE A.Ukprn=B.Ukprn AND A.Ukprn=C.Ukprn " +
                $" COMMIT TRANSACTION;";

            var data = GetData(query);

            if (!string.IsNullOrWhiteSpace(data[0])) totalEarnings = string.Format("{0:C}", (decimal.Parse(data[0])));
            if (!string.IsNullOrWhiteSpace(data[1])) levyEarnings = string.Format("{0:C}", (decimal.Parse(data[1])));
            if (!string.IsNullOrWhiteSpace(data[2])) nonLevyEarnings = string.Format("{0:C}", (decimal.Parse(data[2])));
            if (!string.IsNullOrWhiteSpace(data[2])) nonLevyGovernmentContribution = string.Format("{0:C}", (decimal.Parse(data[3])));
            if (!string.IsNullOrWhiteSpace(data[2])) nonLevyEmployerContribution = string.Format("{0:C}", (decimal.Parse(data[4])));

            return (totalEarnings, levyEarnings, nonLevyEarnings, nonLevyGovernmentContribution, nonLevyEmployerContribution);
        }
    }
}
