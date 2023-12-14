using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public partial class DataLockSqlHelper(ObjectContext objectContext, DbConfig dBConfig, ApprenticeDataHelper dataHelper, ApprenticeCourseDataHelper coursedataHelper) : SqlDbHelper(objectContext, dBConfig.CommitmentsDbConnectionString)
    {
        private int _apprenticeshipId;

        public int GetDatalocksResolvedStatus() => Convert.ToInt32(GetDataAsObject($"SELECT IsResolved from [dbo].[DataLockStatus] WHERE ApprenticeshipId = '{_apprenticeshipId}'"));

        private string ExistingRecordOnDataLockStatusTable(int apprenticeshipId) => GetNullableData($"SELECT Id from [dbo].[DataLockStatus] WHERE ApprenticeshipId = '{apprenticeshipId}'");
        
        public void SubmitILRWithPriceMismatch() => SubmitILRMismatch("PriceDataLock");

        public void SubmitILRWithCourseMismatch() => SubmitILRMismatch("CourseDataLock");

        public void SubmitILRWithCourseAndPriceMismatch() => SubmitILRMismatch("CourseAndPriceDataLock");

        private void SubmitILRMismatch(string type)
        {
            string sqlQueryFromFile = FileHelper.GetSql(type);

            _apprenticeshipId = dataHelper.ApprenticeshipId();

            bool DoesRecordExistOnDataLockStatusTable = ExistingRecordOnDataLockStatusTable(_apprenticeshipId) != "";
            
            string priceEpisodeIdentifier = (DoesRecordExistOnDataLockStatusTable) ? "455-3-1-01-01-2019" : "455-3-1-01-01-2018";
            int month = (DoesRecordExistOnDataLockStatusTable) ? coursedataHelper.CourseStartDate.Month + 1 : coursedataHelper.CourseStartDate.Month;
            string price = (DoesRecordExistOnDataLockStatusTable) ? (Convert.ToInt32(dataHelper.TrainingCost) + 500).ToString() : dataHelper.TrainingCost;

            string courseStartDate = Convert.ToString(coursedataHelper.CourseStartDate.Year) + "-" + Convert.ToString(month) + "-01";

            Dictionary<string, string> sqlParameters = new()
            {
                { "@MaxDataLockEventId", Convert.ToString(new DataLockEventIdSqlHelper(objectContext, connectionString).GetMaxDataLockEventId()) },
                { "@PriceEpisode", priceEpisodeIdentifier},
                { "@CurrentApprenticeshipId", Convert.ToString(_apprenticeshipId) },
                { "@StartDate", courseStartDate },
                { "@TrainingPrice", price}
            };

            ExecuteSqlCommand(sqlQueryFromFile, sqlParameters);
        }
    }
}
