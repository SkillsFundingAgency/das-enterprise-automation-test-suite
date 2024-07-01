using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;

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

        public (string ActualStartDate, string Reason, string RequestStatus) GetChangeOfStartDateRequestData (string uln)
        {
            string query = $"SELECT top (1) st.ActualStartDate, st.Reason, st.RequestStatus " +
                $" FROM [dbo].[StartDateChange] st " +
                $" JOIN [dbo].[Apprenticeship] apprn ON st.ApprenticeshipKey = apprn.[Key] " +
                $" WHERE Uln = '{uln}' order by CreatedDate desc";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1], data[2]);
        }

        public (string ActualStartDate, string PlannedEndDate) GetApprenticeshipTrainingDates (string uln)
        {
            string query = $"select ActualStartDate, PlannedEndDate " +
                $" from [dbo].[Apprenticeship] " +
                $" where Uln = '{uln}'";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1]);
        }

        public bool GetProviderPaymentStatus (string uln)
        {
            string query = $"SELECT top (1) Unfrozen FROM [dbo].[FreezeRequest] fr " +
                $" JOIN [dbo].[Apprenticeship] apprn ON fr.ApprenticeshipKey = apprn.[Key] " +
                $" WHERE Uln = '{uln}' order by FrozenDateTime desc";

            waitForResults = true;

            var data = GetData(query);

            return Convert.ToBoolean(data[0]);
        }
    }
}