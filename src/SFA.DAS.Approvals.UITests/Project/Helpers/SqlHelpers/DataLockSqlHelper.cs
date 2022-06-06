using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public partial class DataLockSqlHelper : SqlDbHelper
    {
        private readonly ApprenticeDataHelper _dataHelper;

        private readonly ApprenticeCourseDataHelper _coursedataHelper;

        private readonly string _title;

        private int _apprenticeshipId;

        public DataLockSqlHelper(DbConfig dBConfig, ApprenticeDataHelper dataHelper, ApprenticeCourseDataHelper coursedataHelper, string title) : base(dBConfig.CommitmentsDbConnectionString)
        {
            _title = title;
            _dataHelper = dataHelper;
            _coursedataHelper = coursedataHelper;
        }

        public int GetDatalocksResolvedStatus() => Convert.ToInt32(GetDataAsObject($"SELECT IsResolved from [dbo].[DataLockStatus] WHERE ApprenticeshipId = '{_apprenticeshipId}'"));

        private string ExistingRecordOnDataLockStatusTable(int apprenticeshipId) => GetNullableData($"SELECT Id from [dbo].[DataLockStatus] WHERE ApprenticeshipId = '{apprenticeshipId}'");
        
        public void SubmitILRWithPriceMismatch() => SubmitILRMismatch("PriceDataLock");

        public void SubmitILRWithCourseMismatch() => SubmitILRMismatch("CourseDataLock");

        public void SubmitILRWithCourseAndPriceMismatch() => SubmitILRMismatch("CourseAndPriceDataLock");

        private void SubmitILRMismatch(string type)
        {
            string sqlQueryFromFile = FileHelper.GetSql(type);

            _apprenticeshipId = _dataHelper.ApprenticeshipId(_title);

            bool DoesRecordExistOnDataLockStatusTable = (ExistingRecordOnDataLockStatusTable(_apprenticeshipId) == "") ? false : true;
            
            string priceEpisodeIdentifier = (DoesRecordExistOnDataLockStatusTable) ? "455-3-1-01-01-2019" : "455-3-1-01-01-2018";
            int month = (DoesRecordExistOnDataLockStatusTable) ? _coursedataHelper.CourseStartDate.Month + 1 : _coursedataHelper.CourseStartDate.Month;
            string price = (DoesRecordExistOnDataLockStatusTable) ? (Convert.ToInt32(_dataHelper.TrainingCost) + 500).ToString() : _dataHelper.TrainingCost;

            string courseStartDate = Convert.ToString(_coursedataHelper.CourseStartDate.Year) + "-" + Convert.ToString(month) + "-01";

            Dictionary<string, string> sqlParameters = new Dictionary<string, string>
            {
                { "@MaxDataLockEventId", Convert.ToString(DataLockEventIdSqlHelper.GetMaxDataLockEventId(connectionString)) },
                { "@PriceEpisode", priceEpisodeIdentifier},
                { "@CurrentApprenticeshipId", Convert.ToString(_apprenticeshipId) },
                { "@StartDate", courseStartDate },
                { "@TrainingPrice", price}
            };

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(sqlQueryFromFile, connectionString, sqlParameters);
        }
    }
}
