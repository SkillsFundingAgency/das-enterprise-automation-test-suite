using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeshipsSqlDbHelper : SqlDbHelper
    {
        public ApprenticeshipsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeshipsDbConnectionString)
        {
        }

        public (string isPilot, string actualStartDate, string plannedStartDate, string plannedEndDate, string agreedPrice, string FundingType, string FundingBandMax) GetEarningsApprenticeshipDetails(string uln)
        {
            string query = $" SELECT apprv.[FundingPlatform], apprv.[ActualStartDate], apprv.[PlannedStartDate], apprv.[PlannedEndDate], apprv.[AgreedPrice], apprv.[FundingType], apprv.[FundingBandMaximum] " +
               $"FROM [dbo].[Approval] apprv " +
               $"JOIN [dbo].[Apprenticeship] apprn ON apprv.ApprenticeshipKey = apprn.[Key]" +
               $"WHERE Uln = '{uln}'";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
        }

        public bool VerifyUlnIsUnique(string uln)
        {
            string query = $"SELECT COUNT(*)" +
               $"FROM [dbo].[Approval] apprv " +
               $"JOIN [dbo].[Apprenticeship] apprn ON apprv.ApprenticeshipKey = apprn.[Key]" +
               $"WHERE Uln = '{uln}'" +
               $"AND rownum = 1";

            waitForResults = true;
            var returnValue = GetDataAsInteger(query);
            return returnValue == 0;
        }
    }
}