using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers
{
    public class ApprenticeshipsSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.ApprenticeshipsDbConnectionString)
    {
        public (string isPilot, string startDate, string endDate, string agreedPrice, string FundingType, string FundingBandMax) GetEarningsApprenticeshipDetails(string uln)
        {
            string query = $" SELECT ep.FundingPlatform, eppr.StartDate, eppr.EndDate, eppr.TotalPrice, ep.FundingType, eppr.FundingBandMaximum " +
                $" FROM [dbo].[Apprenticeship] app " +
                $" JOIN [dbo].[Episode] ep on app.[Key] = ep.ApprenticeshipKey " +
                $" JOIN [dbo].[EpisodePrice] eppr on ep.[Key] = eppr.[EpisodeKey] " +
                $" WHERE app.uln = '{uln}'";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1], data[2], data[3], data[4], data[5]);
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

        public (string ActualStartDate, string Reason, string RequestStatus) GetChangeOfStartDateRequestData(string uln)
        {
            string query = $"SELECT top (1) st.ActualStartDate, st.Reason, st.RequestStatus " +
                $" FROM [dbo].[StartDateChange] st " +
                $" JOIN [dbo].[Apprenticeship] apprn ON st.ApprenticeshipKey = apprn.[Key] " +
                $" WHERE Uln = '{uln}' order by CreatedDate desc";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1], data[2]);
        }

        public (string StartDate, string EndDate) GetApprenticeshipTrainingDates(string uln)
        {
            string query = $"SELECT eppr.StartDate, eppr.EndDate " +
                $" FROM [dbo].[Apprenticeship] app " +
                $" JOIN [dbo].[Episode] ep on app.[Key] = ep.ApprenticeshipKey " +
                $" JOIN [dbo].[EpisodePrice] eppr on ep.[Key] = eppr.[EpisodeKey] " +
                $" WHERE app.uln = '{uln}'";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1]);
        }

        public bool GetProviderPaymentStatus(string uln)
        {
            string query = $"SELECT top (1) Unfrozen FROM [dbo].[FreezeRequest] fr " +
                $" JOIN [dbo].[Apprenticeship] apprn ON fr.ApprenticeshipKey = apprn.[Key] " +
                $" WHERE Uln = '{uln}' order by FrozenDateTime desc";

            waitForResults = true;

            var data = GetData(query);

            return Convert.ToBoolean(data[0]);
        }

        public (string LearningStatus, string Reason, string LastDayOfLearning) GetWithdrawalRequestData(string uln)
        {
            string query = $" select ep.LearningStatus, wr.Reason, wr.LastDayOfLearning " +
                $" from WithdrawalRequest wr " +
                $" join Episode ep on ep.ApprenticeshipKey = wr.ApprenticeshipKey " +
                $" where ep.ApprenticeshipKey in (select [key] from [dbo].[Apprenticeship] app" +
                $" where app.Uln = {uln})";

            waitForResults = true;

            var data = GetData(query);

            return (data[0], data[1], data[2]);
        }
    }
}