using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public partial class DlockDataHelper
    {
        private readonly ApprovalsConfig _approvalsConfig;

        private readonly FileHelper _fileHelper;

        private readonly ApprenticeDataHelper _dataHelper;

        private readonly ApprenticeCourseDataHelper _coursedataHelper;

        private readonly SqlDatabaseConnectionHelper _sqlDatabase;

        private readonly string _connectionString;

        private int _apprenticeshipId;

        public DlockDataHelper(ApprovalsConfig approvalsConfig, FileHelper filehelper, ApprenticeDataHelper dataHelper, ApprenticeCourseDataHelper coursedataHelper, SqlDatabaseConnectionHelper sqlDatabase)
        {
            _approvalsConfig = approvalsConfig;
            _sqlDatabase = sqlDatabase;
            _fileHelper = filehelper;
            _dataHelper = dataHelper;
            _coursedataHelper = coursedataHelper;
            _connectionString = _approvalsConfig.CommitmentsDbConnectionString;
        }

        public int GetDatalocksResolvedStatus()
        {
            string sqlQueryToGetDatalockResolvedStatus = $"SELECT IsResolved from [dbo].[DataLockStatus] WHERE ApprenticeshipId = '{_apprenticeshipId}'";
            List<object[]> responseData = _sqlDatabase.ReadDataFromDataBase(sqlQueryToGetDatalockResolvedStatus, _connectionString);
            if (responseData.Count == 0)
                throw new Exception("Unable to find the data lock resolved status:"
                + "\n ApprenticeshipId: " + _apprenticeshipId
                + "\n SQL Query: " + sqlQueryToGetDatalockResolvedStatus);
            else
                return Convert.ToInt32(responseData[0][0]);
        }

        public void SubmitILRWithPriceMismatch()
        {
            SubmitILRMismatch("PriceDataLock");
        }

        public void SubmitILRWithCourseMismatch()
        {
            SubmitILRMismatch("CourseDataLock");
        }

        public void SubmitILRWithCourseAndPriceMismatch()
        {
            SubmitILRMismatch("CourseAndPriceDataLock");
        }

        private void SubmitILRMismatch(string type)
        {
            String sqlQueryFromFile = _fileHelper.GetSql(type);
            String courseStartDate = Convert.ToString(_coursedataHelper.CourseStartDate.Year) + "-" + Convert.ToString(_coursedataHelper.CourseStartDate.Month) + "-01";
            _apprenticeshipId = _dataHelper.ApprenticeshipId();
            Dictionary<String, String> sqlParameters = new Dictionary<String, String>
            {
                { "@MaxDataLockEventId", Convert.ToString(DataLockEventId.GetMaxDataLockEventId(_sqlDatabase,_connectionString)) },
                { "@CurrentApprenticeshipId", Convert.ToString(_apprenticeshipId) },
                { "@StartDate", courseStartDate },
                { "@TrainingPrice", _dataHelper.TrainingPrice}
            };
            _sqlDatabase.ExecuteSqlCommand(
                _connectionString,
                sqlQueryFromFile,
                sqlParameters);
        }
    }
}
