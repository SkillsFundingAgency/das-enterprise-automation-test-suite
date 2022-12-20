using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeshipsSqlDbHelper : SqlDbHelper
    {
        public ApprenticeshipsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeshipsDbConnectionString) { }
        
        public (string isPilot, string actualStartDate, string plannedStartDate, string plannedEndDate, string agreedPrice, string FundingType, string FundingBandMax) GetEarningsApprenticeshipDetails (string uln)
        {
            string query = $" SELECT apprv.[IsOnFlexiPaymentPilot], apprv.[ActualStartDate], apprv.[PlannedStartDate], apprv.[PlannedEndDate], apprv.[AgreedPrice], apprv.[FundingType], apprv.[FundingBandMaximum] " +
               $"FROM [dbo].[Approval] apprv " +
               $"JOIN [dbo].[Apprenticeship] apprn ON apprv.ApprenticeshipKey = apprn.[Key]" +
               $"WHERE Uln = '{uln}'";

            waitForResults = true;

            var data = GetMultipleData(query).ListOfArrayToList(0);

            return (data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
        }
    }
}


