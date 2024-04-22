using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeshipsSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.ApprenticeshipsDbConnectionString)
    {
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

        public (string TrainingPrice, string AssessmentPrice, string TotalPrice, string EffectiveFromDate, string reason, string status) GetChangeOfPriceRequestData(string uln)
        {
            string query = $"Select top (1) TrainingPrice, AssessmentPrice, TotalPrice, EffectiveFromDate, ChangeReason, PriceChangeRequestStatus from PriceHistory " +
                $" where ApprenticeshipKey in (select [Key] from [dbo].[Apprenticeship] " +
                $" where ULN in ('{uln}')) order by CreatedDate desc";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1], data[2], data[3], data[4], data[5]);
        }
    }
}