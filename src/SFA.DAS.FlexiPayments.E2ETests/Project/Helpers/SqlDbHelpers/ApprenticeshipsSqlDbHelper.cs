using NUnit.Framework.Internal;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeshipsSqlDbHelper : SqlDbHelper
    {
        private readonly DbConfig _dbConfig;

        public ApprenticeshipsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeshipsDbConnectionString) { _dbConfig = dbConfig; }
        
        public (string actualStartDate, string plannedEndDate, string agreedPrice, string FundingType, string FundingBandMax) GetEarningsApprenticeshipDetails (string uln)
        {
            string query = $" SELECT apprv.[ActualStartDate], apprv.[PlannedEndDate], apprv.[AgreedPrice], apprv.[FundingType], apprv.[FundingBandMaximum] " +
                $"FROM [dbo].[Approval] apprv " +
                $"JOIN [dbo].[Apprenticeship] apprn ON apprv.ApprenticeshipKey = apprn.[Key]" +
                $"WHERE Uln = '{uln}'";

            var data = GetData(query);

            return (data[0], data[1], data[2], data[3], data[4]);
        }
    }
}


