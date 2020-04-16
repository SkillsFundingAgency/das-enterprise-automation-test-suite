using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public partial class DataLockSqlHelper : SqlDbHelper
    {
        private readonly ApprenticeDataHelper _dataHelper;

        private readonly ApprenticeCourseDataHelper _coursedataHelper;

        private int _apprenticeshipId;

        public DataLockSqlHelper(ApprovalsConfig approvalsConfig, ApprenticeDataHelper dataHelper, ApprenticeCourseDataHelper coursedataHelper) : base(approvalsConfig.CommitmentsDbConnectionString)
        {
            _dataHelper = dataHelper;
            _coursedataHelper = coursedataHelper;
        }

        public int GetDatalocksResolvedStatus() => Convert.ToInt32(GetData($"SELECT IsResolved from [dbo].[DataLockStatus] WHERE ApprenticeshipId = '{_apprenticeshipId}'"));

        public void SubmitILRWithPriceMismatch() => SubmitILRMismatch("PriceDataLock");

        public void SubmitILRWithCourseMismatch() => SubmitILRMismatch("CourseDataLock");

        public void SubmitILRWithCourseAndPriceMismatch() => SubmitILRMismatch("CourseAndPriceDataLock");

        private void SubmitILRMismatch(string type)
        {
            string sqlQueryFromFile = FileHelper.GetSql(type);

            string courseStartDate = Convert.ToString(_coursedataHelper.CourseStartDate.Year) + "-" + Convert.ToString(_coursedataHelper.CourseStartDate.Month) + "-01";

            _apprenticeshipId = _dataHelper.ApprenticeshipId();

            Dictionary<string, string> sqlParameters = new Dictionary<string, string>
            {
                { "@MaxDataLockEventId", Convert.ToString(DataLockEventIdSqlHelper.GetMaxDataLockEventId(connectionString)) },
                { "@CurrentApprenticeshipId", Convert.ToString(_apprenticeshipId) },
                { "@StartDate", courseStartDate },
                { "@TrainingPrice", _dataHelper.TrainingPrice}
            };

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(
                connectionString,
                sqlQueryFromFile,
                sqlParameters);
        }
    }
}
